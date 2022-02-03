using AutoMapper;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;        

        public GetActorsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetActorModel> Handle()
        {
            var actorList = _context.Actors.OrderBy(x => x.ActorId).ToList();
            List<GetActorModel> vm = _mapper.Map<List<GetActorModel>>(actorList);
            return vm;
        }

        public class GetActorModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
