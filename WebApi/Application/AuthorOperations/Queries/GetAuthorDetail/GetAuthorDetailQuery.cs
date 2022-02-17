using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail{
    public class GetAuthorDetailQuery{
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorDetailViewModal Handle(){
            var author = _dbContext.Authors.Where(a => a.Id == AuthorId).SingleOrDefault();
            if(author is null) throw new InvalidOperationException("Yazar Bulunamadı!");

            AuthorDetailViewModal vm = _mapper.Map<AuthorDetailViewModal>(author);
            return vm;
        }
    }

    public class AuthorDetailViewModal{
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Birthdate { get; set; }
    }
}
