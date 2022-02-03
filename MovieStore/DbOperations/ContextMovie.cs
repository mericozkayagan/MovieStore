using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.DbOperations
{
    public class ContextMovie : DbContext, IContext
    {
        public ContextMovie(DbContextOptions<ContextMovie> options) : base(options)
        {
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Selling> Sellings { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
