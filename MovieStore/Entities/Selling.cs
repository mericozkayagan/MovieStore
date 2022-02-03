using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class Selling
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SellId { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
    }
}
