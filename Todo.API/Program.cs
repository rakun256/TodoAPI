using FluentValidation;
using FluentValidation.AspNetCore;
using Todo.API.Middlewares;
using Todo.Application;
using Todo.Application.Features.Todos.Commands.CreateTodo;
using Todo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Application & Infrastructure katmanlarýný ekle
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(CreateTodoCommandValidator).Assembly);

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// middleware tanýmlarýný buraya al
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
