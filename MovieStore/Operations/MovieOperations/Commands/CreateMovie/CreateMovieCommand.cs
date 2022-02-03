using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public CreateMovieModel Model { get; set; }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieName == Model.MovieName);
            if (movie is not null)
            {
                throw new InvalidOperationException("Film zaten mevcut");
            }
            movie = _mapper.Map<Movie>(Model);
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
    public class CreateMovieModel
    {        
        public string MovieName { get; set; }
        public DateTime MovieDate { get; set; }
    }
}
