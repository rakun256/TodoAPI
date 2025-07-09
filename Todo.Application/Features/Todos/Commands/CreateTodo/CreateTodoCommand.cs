using MediatR;
using System;

namespace Todo.Application.Features.Todos.Commands.CreateTodo
{
    public class CreateTodoCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
