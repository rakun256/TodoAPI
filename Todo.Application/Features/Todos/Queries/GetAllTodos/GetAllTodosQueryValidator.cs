using FluentValidation;

namespace Todo.Application.Features.Todos.Queries.GetAllTodos
{
    public class GetAllTodosQueryValidator : AbstractValidator<GetAllTodosQuery>
    {
        public GetAllTodosQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThan(0);
            RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
        }
    }
}
