using AutoMapper;
using FluentAssertions;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.Operations.DirectorOperations.Commands.UpdateDirector;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreUnitTests.Operations.DirectorTests.UpdateDirector
{
    public class UpdateDirectorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextMovie context;
        private readonly IMapper mapper;
        public int DirectorId { get; set; }

        public UpdateDirectorCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenDirectorIdCannotBeFound_InvalidOperationException_ShouldReturn()
        {
            var director = new Director() { DirectorName = "test7", DirectorSurname = "deneme7"};
            context.Add(director);
            context.SaveChanges();

            UpdateDirectorCommand command = new UpdateDirectorCommand(context);
            command.DirectorId = 0;

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen bulunamadı");
        }
    }
}
