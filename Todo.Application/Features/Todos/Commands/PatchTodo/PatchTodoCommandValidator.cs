using FluentValidation;

namespace Todo.Application.Features.Todos.Commands.PatchTodo;

public class PatchTodoCommandValidator : AbstractValidator<PatchTodoCommand>
{
    public PatchTodoCommandValidator()
    {
        RuleFor(x => x.Title).MaximumLength(255);
        RuleFor(x => x.Description).MaximumLength(1024);
    }
}
