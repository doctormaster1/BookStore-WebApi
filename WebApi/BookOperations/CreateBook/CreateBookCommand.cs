using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook{
    public class CreateBookCommand{
        public CreateBookModel Modal { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext) => _dbContext = dbContext;

        public void Handle(){
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Modal.Title);
            if(book is not null) throw new InvalidOperationException("Kitap Mevcut");
            book = new Book();
            book.Title = Modal.Title;
            book.PublishDate = Modal.PublishDate;
            book.PageCount = Modal.PageCount;
            book.GenreId = Modal.GenreId;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
        public class CreateBookModel{
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
