using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSetup;
using WebApi.Application.BookOperations.UpdateBook;
using WebApi.DBOperations;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommandTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        public UpdateBookCommandTests(CommandTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void Book_HataUpdateMesaji_GuncelenecekKitapBulunamadi()
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.Modal = new UpdateBookViewModel()
            {
                Title = "Lord Of The Rings",
                GenreId = 2
            };
            command.BookId = 20;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek Kitap Bulunamadı!");
        }
    }
}
