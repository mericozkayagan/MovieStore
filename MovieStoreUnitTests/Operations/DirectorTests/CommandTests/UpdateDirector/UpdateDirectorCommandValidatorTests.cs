using FluentAssertions;
using MovieStore.Operations.DirectorOperations.Commands.UpdateDirector;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static MovieStore.Operations.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;

namespace MovieStoreUnitTests.Operations.DirectorTests.CommandTests.UpdateDirector
{
    public class UpdateDirectorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, "", "")]
        [InlineData(0, "", "a")]
        [InlineData(0, "", "aa")]
        [InlineData(0, "a", "")]
        [InlineData(0, "aa", "")]
        [InlineData(0, "a", "a")]
        [InlineData(0, "a", "aa")]
        [InlineData(0, "aa", "aa")]
        [InlineData(1, "", "")]
        [InlineData(1, "", "a")]
        [InlineData(1, "", "aa")]
        [InlineData(1, "a", "")]
        [InlineData(1, "aa", "")]
        [InlineData(1, "a", "a")]
        [InlineData(1, "a", "aa")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int id, string name, string surname)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.DirectorId = id;
            command.Model = new UpdateDirectorModel() { DirectorName = name, DirectorSurname = surname };

            UpdateDirectorCommandValidator validations = new UpdateDirectorCommandValidator();
            var result = validations.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
