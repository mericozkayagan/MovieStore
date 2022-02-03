using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string ActorSurname { get; set; }
        public List<Movie> ActorMovies { get; set; }
    }
}
