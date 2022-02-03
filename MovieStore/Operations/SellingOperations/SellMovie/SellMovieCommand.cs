using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.SellingOperations.SellMovie
{
    public class SellMovieCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public SellMovieModel Model { get; set; }


        public SellMovieCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var sold = _context.Sellings.SingleOrDefault(x => x.CustomerId == Model.CustomerId && x.MovieId == Model.MovieId);
            if (sold is not null)
            {
                throw new InvalidOperationException("Bu film bu kullanıcıya daha önce satılmış");
            }
            sold = _mapper.Map<Selling>(Model);
            _context.Sellings.Add(sold);
            _context.SaveChanges();

        }
    }
    public class SellMovieModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }
}
