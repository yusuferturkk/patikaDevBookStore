using FluentValidation;

namespace WebAPI.BookOperations.GetBookDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(b => b.Id).GreaterThan(0);
        }
    }
}