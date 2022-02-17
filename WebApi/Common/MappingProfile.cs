using AutoMapper;
using WebApi.Entities;
using WebApi.Application.BookOperations.GetBook;
using WebApi.Application.BookOperations.GetBookDetail;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenresDetail;
using WebApi.Application.GenreOperations.Commands.CreateGenre;

namespace WebApi.Common{
    public class MapingProfile : Profile{
        public MapingProfile() {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenresDetailViewModel>();
            CreateMap<CreateGenreViewModel, Genre>();
        }
    }
}
