using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenresDetail{
    public class GetGenreDetailQueryValidator:AbstractValidator<GetGenresDetailQuery>{
        public GetGenreDetailQueryValidator(){
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    }
}
