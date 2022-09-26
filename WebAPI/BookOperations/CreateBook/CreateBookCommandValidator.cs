using System;
using FluentValidation;

namespace WebAPI.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(b => b.Model.Title).NotEmpty();
            RuleFor(b => b.Model.Title).MinimumLength(4);
            RuleFor(b => b.Model.GenreId).GreaterThan(0);
            RuleFor(b => b.Model.PageCount).GreaterThan(0);
            RuleFor(b => b.Model.PublishDate).NotEmpty();
            RuleFor(b => b.Model.PublishDate).LessThanOrEqualTo(DateTime.Now.Date);
        }
    }
}