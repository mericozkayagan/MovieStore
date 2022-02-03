using AutoMapper;
using FluentAssertions;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.Operations.ActorOperations.Queries.GetActorDetails;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreUnitTests.Operations.ActorTests.QueryTests.GetActorDetails
{
    public class GetActorDetailsQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextMovie context;
        private readonly IMapper mapper;
        public int ActorId { get; set; }

        public GetActorDetailsQueryTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenActorIdCannotBeFound_InvalidOperationException_ShouldBeReturn()
        {
            var actor = new Actor() { ActorId = 4, ActorName = "test4", ActorSurname = "deneme5" };
            context.Add(actor);
            context.SaveChanges();
            ActorId = 5;

            GetActorDetailsQuery command = new GetActorDetailsQuery(context, mapper);

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu bulunamadı");

        }
    }
}
