using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Model.CustormerName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.CustormerSurname).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Email).NotEmpty();
            RuleFor(x => x.Model.Password).NotEmpty();
        }
    }
}
