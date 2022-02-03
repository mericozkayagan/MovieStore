using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.MovieOperations.Queries.GetMovieDetails
{
    public class GetMovieDetailsQueryValidator : AbstractValidator<GetMovieDetailsQuery>
    {
        public GetMovieDetailsQueryValidator()
        {
            RuleFor(x => x.MovieId).GreaterThan(0);
        }
    }
}
