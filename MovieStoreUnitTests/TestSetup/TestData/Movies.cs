using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreUnitTests.TestSetup.TestEntities
{
    public static class Movies
    {
        public static void AddMovies(this ContextMovie context)
        {
            context.Movies.AddRange(
                    new Movie
                    {
                        MovieName = "Fight Club",
                        GenreId=1,
                        MovieDate = DateTime.Now.AddYears(-20),
                        MoviePrice=100,
                        DirectorId=1                        
                    },
                    new Movie
                    {
                        MovieName = "Star Wars",
                        GenreId = 2,
                        MovieDate = DateTime.Now.AddYears(-20),
                        MoviePrice = 150,
                        DirectorId = 2
                    }

                    );
        }
    }
}
