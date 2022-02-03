using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x => x.Model.DirectorName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.DirectorSurname).NotEmpty().MinimumLength(2);
        }
    }
}
