using System;
using FluentValidation;

namespace WebAPI.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
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