using FluentValidation;

namespace WebAPI.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(b => b.Id).GreaterThan(0);
        }
    }
}