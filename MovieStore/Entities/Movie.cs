using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime MovieDate { get; set; }
        public int GenreId { get; set; }
        public Director MovieDirector { get; set; }
        public int DirectorId { get; set; }
        public List<Actor> MovieActors { get; set; }
        public decimal MoviePrice { get; set; }
        public Genre Genre { get; set; }
    }
}
