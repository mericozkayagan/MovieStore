using FluentAssertions;
using MovieStore.Operations.CustomerOperations.Commands;
using MovieStore.Operations.CustomerOperations.Commands.CreateCustomer;
using MovieStoreUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieStoreUnitTests.Operations.CustomerTests.CommandTests.CreateCustomer
{
    public class CreateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","","","")]
        [InlineData("","a","","")]
        [InlineData("","aa","","")]
        [InlineData("a","","","")]
        [InlineData("a","a","","")]
        [InlineData("a","aa","","")]
        [InlineData("aa","aa","","")]
        //
        [InlineData("", "a", "a", "")]
        [InlineData("", "aa", "a", "")]
        [InlineData("a", "", "a", "")]
        [InlineData("a", "a", "a", "")]
        [InlineData("a", "aa", "a", "")]
        [InlineData("aa", "aa", "a", "")]
        //
        [InlineData("", "a", "", "a")]
        [InlineData("", "aa", "", "a")]
        [InlineData("a", "", "", "a")]
        [InlineData("a", "a", "", "a")]
        [InlineData("a", "aa", "", "a")]
        [InlineData("aa", "aa", "", "a")]
        //
        [InlineData("", "a", "a", "a")]
        [InlineData("", "aa", "a", "a")]
        [InlineData("a", "", "a", "a")]
        [InlineData("a", "a", "a", "a")]
        [InlineData("a", "aa", "a", "a")]       
        [InlineData("aa", "a", "a", "a")]       

        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name, string surname, string email, string password)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerModel() { CustormerName = name, CustormerSurname = surname, Email = email, Password = password };

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
