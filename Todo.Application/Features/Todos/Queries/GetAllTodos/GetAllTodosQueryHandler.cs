using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;

namespace Todo.Application.Features.Todos.Queries.GetAllTodos
{
    public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, List<TodoDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllTodosQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoDto>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            var query = _context.TodoItems.AsQueryable();

            if (request.IsCompleted.HasValue)
                query = query.Where(x => x.IsCompleted == request.IsCompleted);

            if (request.DueBefore.HasValue)
                query = query.Where(x => x.DueDate != null && x.DueDate < request.DueBefore);

            query = query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            return await query
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
                .ToListAsync(cancellationToken);
        }
    }
}
