using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre{
    public class UpdateGenreCommand{
        private readonly IBookStoreDbContext _dbContext;
        public UpdateGenreViewModal Modal { get; set; }
        public int GenreId { get; set; }
        public UpdateGenreCommand(IBookStoreDbContext dbContext){
            _dbContext = dbContext;
        }

        public void Handle(){
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);

            if(genre is null) throw new InvalidOperationException("Güncellenecek Kitap Türü Bulunamadı!");
            if(_dbContext.Genres.Any(x=> x.Name.ToLower() == Modal.Name.ToLower() && x.Id != GenreId)) throw new InvalidOperationException("Aynı İsimli Kitap Türü Mevcut");
            genre.Name = string.IsNullOrEmpty(Modal.Name.Trim()) ? genre.Name : Modal.Name;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateGenreViewModal{
        public string Name { get; set; }
    }
}
