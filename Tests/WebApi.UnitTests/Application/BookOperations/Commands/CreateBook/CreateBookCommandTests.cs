using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBook{
    public class CreateBookCommandTests : IClassFixture<CommandTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommandTests(CommandTestFixture testFixture){
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void Book_HataMesajiTesti_KitapMevcut(){
            var book = new Book(){
                Title = "Hata Mesaji Testi", 
                PublishDate = new System.DateTime(1990,01,10), 
                PageCount = 100, 
                GenreId = 1
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Modal = new CreateBookModel(){Title = book.Title};

            FluentActions.Invoking(()=> command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Mevcut");
        }

        [Fact]
        public void Book_BasariliTest_Ok(){
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            CreateBookModel model = new CreateBookModel(){
                Title = "Hobbit",
                PageCount = 1000,
                PublishDate = DateTime.Now.Date.AddYears(-10),
                GenreId = 2
            };
            command.Modal = model;

            FluentActions.Invoking(()=> command.Handle()).Invoke();
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
        }
    }
}
