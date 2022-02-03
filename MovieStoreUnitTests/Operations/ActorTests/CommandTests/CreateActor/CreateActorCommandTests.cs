using AutoMapper;
using FluentAssertions;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.Operations.ActorOperations.Commands;
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
    public class CreateActorCommandTests :IClassFixture<CommonTestFixture>
    {
        private readonly ContextMovie context;
        private readonly IMapper mapper;

        public CreateActorCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenAlreadyExistsActorIsGiven_InvalidOperationException_ShouldBeReturn()
        {           
            CreateActorCommand command = new CreateActorCommand(context,mapper);
            CreateActorModel model = new CreateActorModel() { ActorName = "testadam", ActorSurname = "testsoyad" };
            command.Model = model;

            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var actor = context.Actors.SingleOrDefault(x => x.ActorName == model.ActorName);
            actor.ActorSurname.Should().Be(model.ActorSurname);

        }
        [Fact]
        public void WhenAllValidInputsAreGiven_Actor_ShouldBeCreated()
        {
            CreateActorCommand command = new CreateActorCommand(context, mapper);
            CreateActorModel model = new CreateActorModel() { ActorName = "testadam2", ActorSurname = "testsoyad2" };
            command.Model = model;

            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            var author = context.Actors.SingleOrDefault(x => x.ActorName == model.ActorName);
            author.ActorSurname.Should().Be(model.ActorSurname);

        }
    }
}
