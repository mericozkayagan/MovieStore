using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public string DirectorSurname { get; set; }
        public List<Movie> DirectorMovies { get; set; }
    }
}
