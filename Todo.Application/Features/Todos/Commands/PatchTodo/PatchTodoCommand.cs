using MediatR;

namespace Todo.Application.Features.Todos.Commands.PatchTodo;

public class PatchTodoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }
}
