using AutoMapper;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DirectorViewModel> Handle()
        {
            var directorList = _context.Directors.OrderBy(x => x.DirectorId).ToList();
            List<DirectorViewModel> vm = _mapper.Map< List<DirectorViewModel>>(directorList);

            return vm;
        }

        public class DirectorViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
