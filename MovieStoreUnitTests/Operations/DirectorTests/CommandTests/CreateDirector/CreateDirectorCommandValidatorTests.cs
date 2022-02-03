using FluentAssertions;
using FluentValidation;
using MovieStore.Operations.DirectorOperations.Commands.CreateDirector;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static MovieStore.Operations.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;

namespace MovieStoreUnitTests.Operations.DirectorTests.CommandTests.CreateDirector
{
    public class CreateDirectorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("", "a")]
        [InlineData("", "aa")]
        [InlineData("aa", "")]
        [InlineData("a", "")]
        [InlineData("a", "a")]
        [InlineData("aa", "a")]
        [InlineData("a", "aa")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name, string surname)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorModel() { DirectorName = name, DirectorSurname = surname };

            CreateDirectorCommandValidator validations = new CreateDirectorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
