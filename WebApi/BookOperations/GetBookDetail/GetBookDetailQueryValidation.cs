using FluentValidation;

namespace WebApi.BookOperations.GetBookDetail{
    public class GetBookDetailQueryValidation : AbstractValidator<GetBookDetailQuery>{
        public GetBookDetailQueryValidation(){
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}
