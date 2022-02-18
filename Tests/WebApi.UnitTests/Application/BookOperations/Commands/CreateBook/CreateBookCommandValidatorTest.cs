using FluentAssertions;
using WebApi.Application.BookOperations.CreateBook;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBook{
    public class CreateBookCommandValidatorTests
    {
        [Theory]
        [InlineData("Lord Of the Rings",0,0)]
        [InlineData("Lord Of the Rings",0,1)]
        [InlineData("Lord Of the Rings",100,0)]
        [InlineData("",0,0)]
        [InlineData("",100,1)]
        [InlineData("",0,1)]
        [InlineData("lor",100,1)]
        [InlineData("Lor",0,0)]
        [InlineData("Lord",100,0)]
        [InlineData("Lord",0,1)]
        [InlineData(" ",100,1)]
        public void Validator_HataliGirisTest_HataMesaji(string title, int pageCount, int genreId)
        {
            CreateBookCommand command = new CreateBookCommand(null,null);
            command.Modal = new CreateBookModel(){
                Title = title,
                PageCount = pageCount,
                PublishDate = System.DateTime.Now.Date.AddYears(-1),
                GenreId = genreId
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Validator_HataliTarihTest_TarihHatasiMesaj()
        {
            CreateBookCommand command = new CreateBookCommand(null,null);
            command.Modal = new CreateBookModel(){
                Title = "Lord Of The Rings",
                PageCount = 1100,
                PublishDate = System.DateTime.Now.Date,
                GenreId = 2
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Validator_BasariliGiris_Ok()
        {
            CreateBookCommand command = new CreateBookCommand(null,null);
            command.Modal = new CreateBookModel(){
                Title = "Lord Of The Rings",
                PageCount = 1100,
                PublishDate = System.DateTime.Now.Date.AddYears(-2),
                GenreId = 2
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);
        }
    }    
}
