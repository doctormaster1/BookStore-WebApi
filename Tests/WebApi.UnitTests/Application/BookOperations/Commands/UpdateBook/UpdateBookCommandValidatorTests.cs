using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.UpdateBook;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommandTestFixture>
    {
        [Theory]
        [InlineData("Lord Of the Rings", 0)]
        [InlineData("", 0)]
        [InlineData("", 100)]
        [InlineData("lor", 100)]
        [InlineData("Lor", 0)]
        [InlineData("Lord", 0)]
        [InlineData(" ", 100)]
        public void Validator_HataliGirisTest_HataMesaji(string title, int genreId)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Modal = new UpdateBookViewModel()
            {
                Title = title,
                GenreId = genreId
            };
            command.BookId = 1;

            UpdateBookCommandValidation validator = new UpdateBookCommandValidation();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validator_HataliIdGiris_Ok(int bookId)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Modal = new UpdateBookViewModel()
            {
                Title = "Lord Of The Rings",
                GenreId = 2
            };
            command.BookId = bookId;

            UpdateBookCommandValidation validator = new UpdateBookCommandValidation();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Validator_BasariliIdGiris_Ok()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Modal = new UpdateBookViewModel()
            {
                Title = "Lord Of The Rings",
                GenreId = 2
            };
            command.BookId = 2;

            UpdateBookCommandValidation validator = new UpdateBookCommandValidation();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);
        }

        [Fact]
        public void Validator_BasariliGiris_Ok()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Modal = new UpdateBookViewModel()
            {
                Title = "Lord Of The Rings",
                GenreId = 2
            };

            UpdateBookCommandValidation validator = new UpdateBookCommandValidation();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);
        }
    }
}
