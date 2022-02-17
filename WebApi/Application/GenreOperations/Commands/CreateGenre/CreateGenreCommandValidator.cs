using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>{
        public CreateGenreCommandValidator(){
            RuleFor(command => command.Modal.Name).NotEmpty().MinimumLength(4);
        }
    }
}
