using AutoMapper;
using FluentAssertions;
using MovieStore.DbOperations;
using MovieStore.Entities;
using MovieStore.Operations.CustomerOperations.Commands;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreUnitTests.Operations.CustomerTests.CommandTests.CreateCustomer
{
    public class CreateCustomerCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly ContextMovie context;
        private readonly IMapper mapper;

        public CreateCustomerCommandTests(CommonTestFixture testFixture)
        {
            context = testFixture.context;
            mapper = testFixture.mapper;
        }

        [Fact]
        public void WhenAlreadyExistedCustomerIsGiven_InvalidOperationException_ShouldReturn()
        {
            var customer = new Customer() { CustormerName = "test1", CustormerSurname = "deneme1" };
            context.Add(customer);
            context.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(context,mapper);
            command.Model = new CreateCustomerModel() { CustormerName = "test1", CustormerSurname = "deneme1" };

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Müşteri zaten kayıtlı");
        }
    }
}
