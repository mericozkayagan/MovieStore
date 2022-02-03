using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.SellingOperations.SellMovie
{
    public class SellMovieCommandValidator : AbstractValidator<SellMovieCommand>
    {
        public SellMovieCommandValidator()
        {
            RuleFor(x => x.Model.CustomerId).GreaterThan(0);
            RuleFor(x => x.Model.MovieId).GreaterThan(0);
        }
    }
}
