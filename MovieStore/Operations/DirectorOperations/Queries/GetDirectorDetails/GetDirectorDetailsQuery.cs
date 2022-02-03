using AutoMapper;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.DirectorOperations.Queries.GetDirectorDetails
{
    public class GetDirectorDetailsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int DirectorId { get; set; }

        public GetDirectorDetailsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetDirectorModel Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.DirectorId==DirectorId);
            if (director is null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadı");
            }
            GetDirectorModel model = _mapper.Map<GetDirectorModel>(director);
            return model;
        }

        public class GetDirectorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
