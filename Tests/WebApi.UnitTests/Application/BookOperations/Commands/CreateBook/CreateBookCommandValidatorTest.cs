using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.CreateBook{
    public class CreateBookCommandValidatorTests : IClassFixture<CommandTestFixture>{

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
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId){
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
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError(){
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
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(){
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
