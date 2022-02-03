using AutoMapper;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.SellingOperations.GetSellings
{
    public class GetSellingsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetSellingsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetSellingsModel> Handle()
        {
            var sellingsList = _context.Sellings.OrderBy(x => x.SellId).ToList();
            List<GetSellingsModel> vm = _mapper.Map<List<GetSellingsModel>>(sellingsList);
            return vm;
        }
    }
    public class GetSellingsModel
    {
        public int SellId { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }
}
