using AutoMapper;
using WebApi.Entities;
using WebApi.Application.BookOperations.GetBook;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenresDetail;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.UserOperations.CreateUser;

namespace WebApi.Common{
    public class MapingProfile : Profile{
        public MapingProfile() {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenresDetailViewModel>();
            CreateMap<CreateGenreViewModel, Genre>();

            CreateMap<Author, AuthorsViewModal>();
            CreateMap<Author, AuthorDetailViewModal>();
            CreateMap<CreateAuthorModal, Author>();

            CreateMap<CreateUserModel, User>();
        }
    }
}
