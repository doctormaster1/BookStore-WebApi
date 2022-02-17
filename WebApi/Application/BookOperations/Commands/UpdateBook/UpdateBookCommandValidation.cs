using FluentValidation;

namespace WebApi.Application.BookOperations.UpdateBook{
    public class UpdateBookCommandValidation : AbstractValidator<UpdateBookCommand>{
        public UpdateBookCommandValidation(){
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Modal.GenreId).GreaterThan(0);
            RuleFor(command => command.Modal.Title).NotEmpty().MinimumLength(0);
        }
    }
}
