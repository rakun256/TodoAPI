using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FluentValidation;

namespace Todo.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                context.Response.ContentType = "application/problem+json";

                var problemDetails = new ValidationProblemDetails
                {
                    Title = "Validation Error",
                    Status = StatusCodes.Status422UnprocessableEntity,
                    Detail = "One or more validation errors occurred.",
                    Instance = context.Request.Path
                };

                foreach (var error in ex.Errors)
                {
                    problemDetails.Errors.Add(error.PropertyName, new[] { error.ErrorMessage });
                }

                var json = JsonSerializer.Serialize(problemDetails);
                await context.Response.WriteAsync(json);
            }
            catch (KeyNotFoundException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/problem+json";

                var problem = new ProblemDetails
                {
                    Title = "Not Found",
                    Status = 404,
                    Detail = ex.Message,
                    Instance = context.Request.Path
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/problem+json";

                var problem = new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Status = 500,
                    Detail = "An unexpected error occurred.",
                    Instance = context.Request.Path
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
        }
    }
}
