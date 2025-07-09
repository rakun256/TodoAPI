using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Features.Todos.Queries.GetAllTodos;
using Todo.Application.Interfaces;

namespace Todo.Application.Features.Todos.Queries.GetTodoById
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoDto>
    {
        private readonly IApplicationDbContext _context;

        public GetTodoByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems
                .Where(x => x.Id == request.Id)
                .Select(x => new TodoDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    IsCompleted = x.IsCompleted,
                    DueDate = x.DueDate,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new KeyNotFoundException($"Todo with ID {request.Id} not found.");

            return entity;
        }
    }
}
