using FluentValidation;

namespace Todo.Application.Features.Todos.Commands.UpdateTodo
{
    public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
    {
        public UpdateTodoCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(255);

            RuleFor(x => x.Description)
                .MaximumLength(1024);
        }
    }
}
