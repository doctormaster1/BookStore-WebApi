using FluentValidation;

namespace WebApi.Application.BookOperations.GetBookDetail{
    public class GetBookDetailQueryValidation : AbstractValidator<GetBookDetailQuery>{
        public GetBookDetailQueryValidation(){
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
