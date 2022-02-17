using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor{
    public class CreateAuthorCommand{
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorModal Modal { get; set; }
        public CreateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            var author = _dbContext.Authors.SingleOrDefault(x => x.Name == Modal.Name);
            if(author is not null) throw new InvalidOperationException("Yazar Mevcut");
            author = _mapper.Map<Author>(Modal);
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }
    }

    public class CreateAuthorModal{
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
