using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(x => x.DirectorId).GreaterThan(0);
            RuleFor(x => x.Model.DirectorName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.DirectorSurname).NotEmpty().MinimumLength(2);
        }
    }
}
