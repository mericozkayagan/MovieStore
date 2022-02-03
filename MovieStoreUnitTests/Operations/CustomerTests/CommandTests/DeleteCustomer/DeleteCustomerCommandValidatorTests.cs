using FluentAssertions;
using MovieStore.Operations.CustomerOperations.Commands;
using MovieStore.Operations.CustomerOperations.Commands.DeleteCustomer;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreUnitTests.Operations.CustomerTests.CommandTests.DeleteCustomer
{
    public class DeleteCustomerCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors()
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(null);
            command.CustomerId = 0;

            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
