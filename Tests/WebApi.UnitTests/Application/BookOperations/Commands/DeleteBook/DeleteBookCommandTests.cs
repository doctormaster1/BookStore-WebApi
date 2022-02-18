using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.DBOperations;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommandTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public DeleteBookCommandTests(CommandTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void Book_HataMesajiTesti_KitapBulunamadi()
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = 17;
            var book = _context.Books.SingleOrDefault(x=> x.Id == command.BookId);

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek Kitap Bulunamadı!");
        }

        [Fact]
        public void Book_BasariliMesajTesti_Ok()
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = 2;
            var book = _context.Books.SingleOrDefault(x => x.Id == command.BookId);

            FluentActions.Invoking(() => command.Handle()).Invoke();
        }
    }
}
