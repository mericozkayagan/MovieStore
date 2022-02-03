using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly IContext _context;
        public int MovieId { get; set; }
        public UpdateMovieModel Model { get; set; }


        public UpdateMovieCommand(IContext context, AutoMapper.IMapper _mapper)
        {
            _context = context;
        }
        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieId == MovieId);
            if (movie is null)
            {
                throw new InvalidOperationException("Film bulunamadı");
            }

            movie.MovieName = Model.MovieName != default ? Model.MovieName : movie.MovieName;

            _context.SaveChanges();
        }
    }
    public class UpdateMovieModel
    {        
        public string MovieName { get; set; }
        
    }
}
