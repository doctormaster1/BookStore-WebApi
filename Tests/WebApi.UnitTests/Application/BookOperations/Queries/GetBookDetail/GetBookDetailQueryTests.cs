using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.GetBookDetail;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryTests : IClassFixture<CommandTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validator_BasarisizIdGirisi_HataMesaji(int bookId)
        {
            GetBookDetailQuery query = new GetBookDetailQuery(null, null);
            query.BookId = bookId;

            GetBookDetailQueryValidation validator = new GetBookDetailQueryValidation();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Validator_BasariliGiris_Ok()
        {
            GetBookDetailQuery query = new GetBookDetailQuery(null, null);
            query.BookId = 1;

            GetBookDetailQueryValidation validator = new GetBookDetailQueryValidation();
            var result = validator.Validate(query);
            result.Errors.Count.Should().Equals(0);
        }
    }
}
