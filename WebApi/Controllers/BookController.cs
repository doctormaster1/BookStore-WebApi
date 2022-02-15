using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Controllers{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{

        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks(){
            GetBookQuery query = new GetBookQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public Book GetById(int id){
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook){
            try{
                CreateBookCommand command = new CreateBookCommand(_context);
                command.Modal = newBook;
                command.Handle();

                return Ok();
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }  
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook){
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if(book is null) return BadRequest();
            
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if(book is null) return BadRequest();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

    }
}
