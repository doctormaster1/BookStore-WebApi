using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Controllers{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks(){
            GetBookQuery query = new GetBookQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            try{ 
                BookDetailViewModel result = new BookDetailViewModel();
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                GetBookDetailQueryValidation validator = new GetBookDetailQueryValidation();
                query.BookId = id;
                validator.ValidateAndThrow(query);
                result = query.Handle();
                return Ok(result);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }  
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook){
            try{
                CreateBookCommand command = new CreateBookCommand(_context,_mapper);
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                command.Modal = newBook;
                validator.ValidateAndThrow(command);  
                command.Handle();
                return Ok();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }  
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookViewModel updatedBook){
            try{
                UpdateBookCommand command = new UpdateBookCommand(_context);
                UpdateBookCommandValidation validator = new UpdateBookCommandValidation();
                command.BookId = id;
                command.Modal = updatedBook;
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            try{
                DeleteBookCommand command = new DeleteBookCommand(_context);
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                command.BookId = id;
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }
}
