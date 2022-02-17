using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenresDetail{
    public class GetGenresDetailQuery{
        public readonly IBookStoreDbContext _dbContext;
        public readonly IMapper _mapper;
        public int GenreId { get; set; }
        public GetGenresDetailQuery(IBookStoreDbContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenresDetailViewModel Handle(){
            var genre = _dbContext.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if(genre is null) throw new InvalidOperationException("Kitap Türü Bulunamadı!");
            return _mapper.Map<GenresDetailViewModel>(genre);
        }
    }
    public class GenresDetailViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
