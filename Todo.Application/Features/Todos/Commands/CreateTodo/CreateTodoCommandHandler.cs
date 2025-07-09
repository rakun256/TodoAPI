using MediatR;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.Features.Todos.Commands.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate
            };

            _context.TodoItems.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
