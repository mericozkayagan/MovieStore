using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x => x.Model.ActorName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.ActorSurname).NotEmpty().MinimumLength(2);
        }
    }
}
