using System;
using System.Linq;
using AutoMapper;
using WebApi.Entities;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.CreateBook{
    public class CreateBookCommand{
        public CreateBookModel Modal { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommand(IBookStoreDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Modal.Title);
            if(book is not null) throw new InvalidOperationException("Kitap Mevcut");

            book = _mapper.Map<Book>(Modal);          
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
    }
    public class CreateBookModel{
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
