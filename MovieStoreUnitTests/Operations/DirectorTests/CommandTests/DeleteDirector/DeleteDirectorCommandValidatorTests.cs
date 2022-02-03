using FluentAssertions;
using MovieStore.Operations.DirectorOperations.Commands.DeleteDirector;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreUnitTests.Operations.DirectorTests.CommandTests.DeleteDirector
{
    public class DeleteDirectorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldReturnErrors()
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(null);
            command.DirectorId = 0;

            DeleteDirectorCommandValidator validations = new DeleteDirectorCommandValidator();
            var result = validations.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
