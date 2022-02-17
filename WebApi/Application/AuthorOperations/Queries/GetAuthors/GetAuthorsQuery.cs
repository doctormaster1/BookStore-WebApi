using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors{
    public class GetAuthorsQuery{
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorsViewModal> Handle(){
            var authorsList = _dbContext.Authors.OrderBy(x => x.Id).ToList<Author>();
            List<AuthorsViewModal> vm = _mapper.Map<List<AuthorsViewModal>>(authorsList);
            return vm;
        }
    }

    public class AuthorsViewModal{
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Birthdate { get; set; }
    }
}
