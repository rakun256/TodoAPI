using FluentValidation;

namespace Todo.Application.Features.Todos.Queries.GetTodoById
{
    public class GetTodoByIdQueryValidator : AbstractValidator<GetTodoByIdQuery>
    {
        public GetTodoByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
