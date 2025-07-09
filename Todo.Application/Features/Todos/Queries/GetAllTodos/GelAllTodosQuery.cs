using MediatR;

namespace Todo.Application.Features.Todos.Queries.GetAllTodos
{
    public class GetAllTodosQuery : IRequest<List<TodoDto>>
    {
        public bool? IsCompleted { get; set; }
        public DateTime? DueBefore { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
