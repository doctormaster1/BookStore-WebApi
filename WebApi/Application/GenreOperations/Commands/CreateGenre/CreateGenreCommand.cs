using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre{
    public class CreateGenreCommand{
        public CreateGenreViewModel Modal { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateGenreCommand(IBookStoreDbContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Modal.Name);
            if(genre is not null) throw new InvalidOperationException("Kitap Türü Zaten Mevcut");

            genre = _mapper.Map<Genre>(Modal);          
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }
    public class CreateGenreViewModel{
        public string Name { get; set; }
    }    
}
