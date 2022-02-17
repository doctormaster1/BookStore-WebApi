using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenresDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers{

    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase{
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(BookStoreDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres(){
            GetGenresQuery query = new GetGenresQuery(_context,_mapper);
            List<GenresViewModel> result = new List<GenresViewModel>();

            result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            GetGenresDetailQuery query = new GetGenresDetailQuery(_context,_mapper);
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            GenresDetailViewModel result = new GenresDetailViewModel();

            query.GenreId = id;
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreViewModel newGenre){
            CreateGenreCommand command = new CreateGenreCommand(_context,_mapper);
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();

            command.Modal = newGenre;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreViewModal updateGenre){
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();

            command.GenreId = id;
            command.Modal = updateGenre;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id){
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();

            command.GenreId = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
