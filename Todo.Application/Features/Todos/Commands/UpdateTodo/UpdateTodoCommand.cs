﻿using MediatR;
using System;

namespace Todo.Application.Features.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
