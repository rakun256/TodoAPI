using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.Features.Todos.Commands.PatchTodo;

public class PatchTodoCommandHandler : IRequestHandler<PatchTodoCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public PatchTodoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(PatchTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (todo is null)
            throw new Exception($"Todo with ID {request.Id} not found.");

        if (request.Title is not null)
            todo.Title = request.Title;

        if (request.Description is not null)
            todo.Description = request.Description;

        if (request.IsCompleted.HasValue)
            todo.IsCompleted = request.IsCompleted.Value;

        if (request.DueDate.HasValue)
            todo.DueDate = request.DueDate;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
