using FluentAssertions;
using MovieStore.Operations.SellingOperations.SellMovie;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreUnitTests.Operations.SellingTests.SellMovie
{
    public class SellMovieCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(0,1)]
        [InlineData(1,0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int customerId, int movieId)
        {
            SellMovieCommand command = new SellMovieCommand(null, null);
            command.Model = new SellMovieModel() { CustomerId = customerId, MovieId = movieId };

            SellMovieCommandValidator validations = new SellMovieCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
