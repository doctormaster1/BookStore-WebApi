using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>{
        public UpdateAuthorCommandValidator(){
            RuleFor(command => command.AuthorId).GreaterThan(0);
            RuleFor(command => command.Modal.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Modal.Lastname).NotEmpty().MinimumLength(4);
        }
    }
}
