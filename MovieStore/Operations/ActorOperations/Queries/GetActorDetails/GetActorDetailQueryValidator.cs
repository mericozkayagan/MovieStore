using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.ActorOperations.Queries.GetActorDetails
{
    public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailsQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(x => x.ActorId).GreaterThan(0);
        }
    }
}
