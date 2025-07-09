using FluentValidation;

namespace Todo.Application.Features.Todos.Commands.CreateTodo
{
    public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(255);

            RuleFor(x => x.Description)
                .MaximumLength(1024);
        }
    }
}
