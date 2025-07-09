using MediatR;
using Todo.Application.Features.Todos.Queries.GetAllTodos;

namespace Todo.Application.Features.Todos.Queries.GetTodoById
{
    public class GetTodoByIdQuery : IRequest<TodoDto>
    {
        public int Id { get; set; }
    }
}
