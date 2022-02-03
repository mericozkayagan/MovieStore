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
    public class UpdateActorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextMovie context;
        private readonly IMapper mapper;
        public int ActorId { get; set; }

        public UpdateActorCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenActorIdCannotBeFound_InvalidOperationException_ShouldBeReturn()
        {
            var actor = new Actor() { ActorId = 1, ActorName = "deneme", ActorSurname = "soyad" };
            context.Actors.Add(actor);
            context.SaveChanges();
            ActorId = 2;

            UpdateActorCommand command = new UpdateActorCommand(context, mapper);
            command.Model = new UpdateActorModel() { ActorName = "deneme", ActorSurname = "soyad" };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu bulunamadı");
        }
    }
}
