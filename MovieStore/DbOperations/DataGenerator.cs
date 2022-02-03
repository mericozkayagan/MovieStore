using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ContextMovie(serviceProvider.GetRequiredService<DbContextOptions<DbOperations.ContextMovie>>()))
            {
                if (context.Actors.Any())
                {
                    return;
                }
                context.Actors.AddRange(
                    new Actor
                    {
                        ActorName = "Meriç",
                        ActorSurname = "Özkaya"
                    },
                    new Actor
                    {
                        ActorName = "Derin",
                        ActorSurname = "Özkaya"
                    }
                    );
                context.Movies.AddRange(
                    new Movie
                    {
                        MovieName = "Fight Club",
                        GenreId = 1,
                        MoviePrice = 100,
                        MovieDate = new DateTime(2001, 12, 3)
                    },
                    new Movie
                    {
                        MovieName = "Godfather",
                        GenreId = 2,
                        MoviePrice = 500,
                        MovieDate = new DateTime(2001, 10, 5)
                    }
                    );
                context.Genres.AddRange(
                    new Genre
                    {
                        GenreName = "Sci Fi"
                    },
                    new Genre
                    {
                        GenreName = "Drama"
                    }
                    );
                context.Directors.AddRange(
                    new Director
                    {
                        DirectorName = "Nuri Bilge",
                        DirectorSurname = "Ceylan"
                    },
                    new Director
                    {
                        DirectorName = "Zeki",
                        DirectorSurname = "Demirkubuz"
                    }
                    );

                context.Customers.AddRange(
                    new Customer
                    {
                       CustormerName="Müşteri",CustormerSurname="Alışveriş"
                    },
                    new Customer
                    {
                        CustormerName = "Alıcı",
                        CustormerSurname = "Test"
                    }
                    );
                context.Sellings.AddRange(
                    new Selling
                    {
                        CustomerId=1,
                        MovieId=1
                    },
                    new Selling
                    {
                        CustomerId = 1,
                        MovieId = 2
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
