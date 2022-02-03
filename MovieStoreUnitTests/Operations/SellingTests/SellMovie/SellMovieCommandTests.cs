using AutoMapper;
using FluentAssertions;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.Operations.SellingOperations.SellMovie;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreUnitTests.Operations.SellingTests.SellMovie
{
    public class SellMovieCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextMovie context;
        private readonly IMapper mapper;

        public SellMovieCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenAlreadyExistedSaleIsGiven_InvalidOperationException_ShouldReturn()
        {
            var sale = new Selling() { CustomerId = 1, MovieId = 1 };
            context.Add(sale);
            context.SaveChanges();

            SellMovieCommand command = new SellMovieCommand(context,mapper);
            command.Model = new SellMovieModel() { CustomerId = 1, MovieId = 1 };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu film bu kullanıcıya daha önce satılmış");


        }
    }
}
