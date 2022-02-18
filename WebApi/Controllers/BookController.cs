using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.Application.BookOperations.GetBook;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.Application.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(IBookStoreDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBookQuery query = new GetBookQuery(_context,_mapper);
            List<BooksViewModel> result = new List<BooksViewModel>();

            result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result = new BookDetailViewModel();
            GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
            GetBookDetailQueryValidation validator = new GetBookDetailQueryValidation();

            query.BookId = id;
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            CreateBookCommandValidator validator = new CreateBookCommandValidator();

            command.Modal = newBook;
            validator.ValidateAndThrow(command);  
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookViewModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            UpdateBookCommandValidation validator = new UpdateBookCommandValidation();

            command.BookId = id;
            command.Modal = updatedBook;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();

            command.BookId = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
