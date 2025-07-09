using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;
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
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
