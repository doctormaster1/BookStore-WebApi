using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>{
        public UpdateGenreCommandValidator(){
            RuleFor(command => command.GenreId).GreaterThan(0);
            RuleFor(command => command.Modal.Name).NotEmpty().MinimumLength(4).When(x=> x.Modal.Name != string.Empty);
        }
    }
}
