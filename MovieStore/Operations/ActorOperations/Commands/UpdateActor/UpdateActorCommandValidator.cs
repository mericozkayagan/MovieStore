using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x => x.ActorId).GreaterThan(0);
            RuleFor(x => x.Model.ActorName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.ActorSurname).NotEmpty().MinimumLength(2);
        }
    }
}
