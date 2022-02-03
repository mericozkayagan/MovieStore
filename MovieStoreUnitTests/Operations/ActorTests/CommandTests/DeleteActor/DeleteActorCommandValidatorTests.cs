using FluentAssertions;
using MovieStore.Operations.ActorOperations.Commands.DeleteActor;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreUnitTests.Operations.ActorTests.CommandTests.DeleteActor
{
    public class DeleteActorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldReturnError()
        {
            DeleteActorCommand command = new DeleteActorCommand(null,null);
            command.ActorId = 0;

            DeleteActorCommandValidator validations = new DeleteActorCommandValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
