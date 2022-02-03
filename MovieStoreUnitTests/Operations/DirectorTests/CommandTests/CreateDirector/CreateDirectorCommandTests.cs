using AutoMapper;
using FluentAssertions;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.Operations.DirectorOperations.Commands.CreateDirector;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static MovieStore.Operations.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;

namespace MovieStoreUnitTests.Operations.DirectorTests.CreateDirector
{
   public class CreateDirectorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextMovie context;
        private readonly IMapper mapper;

        public CreateDirectorCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }
        [Fact]
        public void WhenAlreadyExistedDirectorIsGiven_InvalidOperationException_ShouldReturn()
        {
            var director = new Director() { DirectorName = "test1", DirectorSurname = "deneme1" };
            context.Add(director);
            context.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(context, mapper);
            command.Model = new CreateDirectorModel() { DirectorName = "test1", DirectorSurname = "deneme1" };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen zaten mevcut");
        }
    }
}
