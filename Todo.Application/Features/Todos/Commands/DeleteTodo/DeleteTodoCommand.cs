using MediatR;

namespace Todo.Application.Features.Todos.Commands.DeleteTodo
{
    public record DeleteTodoCommand(int Id) : IRequest<Unit>;
}
