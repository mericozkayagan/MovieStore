using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly IContext _context;

        public DeleteMovieCommand(IContext context)
        {
            _context = context;
        }

        public int MovieId { get; set; }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieId == MovieId);
            if (movie is null)
            {
                throw new InvalidOperationException("Film bulunamadı");
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
