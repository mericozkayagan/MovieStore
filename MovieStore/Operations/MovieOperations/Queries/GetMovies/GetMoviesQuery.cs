using AutoMapper;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movieList = _context.Movies.OrderBy(x => x.MovieId);
            List<MovieViewModel> vm = _mapper.Map<List<MovieViewModel>>(movieList);
            return vm;
        }
    }
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime MovieDate { get; set; }
    }
}
