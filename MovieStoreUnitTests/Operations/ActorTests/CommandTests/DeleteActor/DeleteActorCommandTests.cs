using AutoMapper;
using FluentAssertions;
using MovieStore.DbOperations;
using MovieStore.Entities;
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
    public class DeleteActorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextMovie context;
        private readonly IMapper mapper;
        public int ActorId { get; set; }

        public DeleteActorCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenActorIdCannotBeFound_InvalidOperationException_ShouldBeReturn()
        {
            var actor = new Actor() { ActorId = 3, ActorName = "test3", ActorSurname = "deneme4" };
            context.Add(actor);
            context.SaveChanges();
            ActorId = 4;

            DeleteActorCommand command = new DeleteActorCommand(context, mapper);

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu bulunamadı");

        }
    }
}
