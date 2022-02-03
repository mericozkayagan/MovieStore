using AutoMapper;
using FluentAssertions;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.Operations.DirectorOperations.Queries.GetDirectorDetails;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreUnitTests.Operations.DirectorTests.QueryTests.GetDirectorDetails
{
    public class GetDirectorDetailsQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextMovie context;
        private readonly IMapper mapper;
        public int DirectorId { get; set; }

        public GetDirectorDetailsQueryTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenDirectorIdCannotBeFound_InvalidOperationException_ShouldReturn()
        {
            var director = new Director() { DirectorName = "test9", DirectorSurname = "deneme9" };
            context.Add(director);
            context.SaveChanges();
            DirectorId = 0;

            GetDirectorDetailsQuery query = new GetDirectorDetailsQuery(context,mapper);

            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen bulunamadı");
        }
    }
}
