using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.DirectorOperations.Queries.GetDirectorDetails
{
    public class GetDirectorDetailsValidator : AbstractValidator<GetDirectorDetailsQuery>
    {
        public GetDirectorDetailsValidator()
        {
            RuleFor(x => x.DirectorId).GreaterThan(0);
        }
    }
}
