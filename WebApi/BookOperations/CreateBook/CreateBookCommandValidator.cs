using System;
using FluentValidation;

namespace WebApi.BookOperations.CreateBook{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>{
        public CreateBookCommandValidator(){
            RuleFor(command => command.Modal.GenreId).GreaterThan(0).IsInEnum();
            RuleFor(command => command.Modal.PageCount).GreaterThan(0);
            RuleFor(command => command.Modal.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Modal.Title).NotEmpty().MinimumLength(4);
        }
    }
}
