using System;
using DeveloperQuiz.Domains.Request;
using FluentValidation;

namespace DeveloperQuiz.Validators
{
    public class BookRequestValidator : AbstractValidator<BookRequest>
    {
        public BookRequestValidator()
        {
            RuleFor(x => x.Page).NotEmpty();
            RuleFor(x => x.PageSize).NotEmpty();


        }
    }
}
