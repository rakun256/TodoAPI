using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;

namespace Todo.Application.Features.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new KeyNotFoundException($"Todo with ID {request.Id} not found.");

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.IsCompleted = request.IsCompleted;
            entity.DueDate = request.DueDate;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
