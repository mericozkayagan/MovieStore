using AutoMapper;
using FluentAssertions;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.Operations.ActorOperations.Commands.UpdateActor;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static MovieStore.Operations.ActorOperations.Commands.UpdateActor.UpdateActorCommand;

namespace MovieStoreUnitTests.Operations.ActorTests.CommandTests.UpdateActor
{
    public class UpdateActorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0,"","")]
        [InlineData(0,"","a")]
        [InlineData(0,"","aa")]
        [InlineData(0,"a","")]
        [InlineData(0,"aa","")]
        [InlineData(0,"a","a")]
        [InlineData(0,"a","aa")]
        [InlineData(0,"aa","aa")]
        [InlineData(1, "", "")]
        [InlineData(1, "", "a")]
        [InlineData(1, "", "aa")]
        [InlineData(1, "a", "")]
        [InlineData(1, "aa", "")]
        [InlineData(1, "a", "a")]
        [InlineData(1, "a", "aa")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int id, string name, string surname)
        {
            UpdateActorCommand command = new UpdateActorCommand(null, null);
            command.ActorId = id;
            command.Model = new UpdateActorModel() { ActorName = name, ActorSurname = surname };

            UpdateActorCommandValidator validations = new UpdateActorCommandValidator();
            var result = validations.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        
    }
}
