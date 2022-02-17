using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.UpdateBook{
    public class UpdateBookCommand{
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public UpdateBookViewModel Modal { get; set; }
        public UpdateBookCommand(BookStoreDbContext dbContext) => _dbContext = dbContext;

        public void Handle(){
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if(book is null) throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı!");
            
            book.GenreId = Modal.GenreId != default ? Modal.GenreId : book.GenreId;
            book.Title = Modal.Title != default ? Modal.Title : book.Title;

            _dbContext.SaveChanges();
            
        }
    }
    
    public class UpdateBookViewModel{
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}
