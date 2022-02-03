using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.ActorOperations.Commands
{
    public class CreateActorCommand
    {
        public CreateActorModel Model { get; set; }
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.FirstOrDefault(x => x.ActorName == Model.ActorName);
            actor = _mapper.Map<Actor>(Model);
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public class CreateActorModel
        {
            public string ActorName { get; set; }
            public string ActorSurname { get; set; }
        }
    }
}
