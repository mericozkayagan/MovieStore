using AutoMapper;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.MovieOperations.Queries.GetMovieDetails
{
    public class GetMovieDetailsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }

        public GetMovieDetailsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetMovieModel Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieId == MovieId);
            if (movie is null)
            {
                throw new InvalidOperationException("Film bulunamadı");
            }
            GetMovieModel vm = _mapper.Map<GetMovieModel>(movie);
            return vm;
        }
    }
    public class GetMovieModel
    {
        public string MovieName { get; set; }
    }
}
