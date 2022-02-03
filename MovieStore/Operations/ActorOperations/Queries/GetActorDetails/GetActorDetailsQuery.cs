using AutoMapper;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.ActorOperations.Queries.GetActorDetails
{
    public class GetActorDetailsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetActorDetailsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int ActorId { get; set; }

        public ActorDetailModel Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.ActorId == ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Oyuncu bulunamadı");
            }
            ActorDetailModel model = _mapper.Map<ActorDetailModel>(actor);
            return model;
        }

        public class ActorDetailModel
        {
            public int Name { get; set; }
            public int Surname { get; set; }
        }
    }
}
