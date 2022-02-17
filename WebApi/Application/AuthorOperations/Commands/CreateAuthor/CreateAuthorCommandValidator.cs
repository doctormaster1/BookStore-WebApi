using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>{
        public CreateAuthorCommandValidator(){
            RuleFor(command => command.Modal.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Modal.Lastname).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Modal.Birthdate.Date).NotEmpty().LessThan(DateTime.Now);
        }
    }
}
