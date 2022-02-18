using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.DeleteBook;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTest : IClassFixture<CommandTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validator_HataliIdGiris_Ok(int bookId)
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = bookId;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Validator_BasariliIdGiris_Ok()
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = 2;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);
        }
    }
}
