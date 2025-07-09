using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;

namespace Todo.Application.Features.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new KeyNotFoundException($"Todo with ID {request.Id} not found.");

            _context.TodoItems.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
