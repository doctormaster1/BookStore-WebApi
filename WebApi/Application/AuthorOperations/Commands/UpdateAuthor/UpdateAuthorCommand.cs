using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor{
    public class UpdateAuthorCommand{
        private readonly IBookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public UpdateAutherViewModal Modal { get; set; }
        public UpdateAuthorCommand(IBookStoreDbContext dbContext){
            _dbContext = dbContext;
        }

        public void Handle(){
            var author = _dbContext.Authors.SingleOrDefault(a => a.Id == AuthorId);
            if(author is null) throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı");
            author.Name = Modal.Name != default ? Modal.Name : author.Name;
            author.Lastname = Modal.Lastname != default ? Modal.Lastname : author.Lastname;
            _dbContext.SaveChanges();
        }
    }

    public class UpdateAutherViewModal{
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
