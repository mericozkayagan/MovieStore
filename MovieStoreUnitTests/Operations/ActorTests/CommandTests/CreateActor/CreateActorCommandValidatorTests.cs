using FluentAssertions;
using MovieStore.Operations.ActorOperations.Commands;
using MovieStore.Operations.ActorOperations.Commands.CreateActor;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static MovieStore.Operations.ActorOperations.Commands.CreateActorCommand;

namespace MovieStoreUnitTests.Operations.ActorTests.CommandTests.CreateActor
{
    public class CreateActorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","")]
        [InlineData("a","")]
        [InlineData("aa","")]
        [InlineData("","a")]
        [InlineData("","aa")]
        [InlineData("a","aa")]
        [InlineData("aa","a")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name, string surname)
        {
            CreateActorCommand command = new CreateActorCommand(null, null);
            command.Model = new CreateActorModel() { ActorName = name, ActorSurname = surname };

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
