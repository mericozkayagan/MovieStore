using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public UpdateActorCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int ActorId { get; set; }
        public UpdateActorModel Model { get; set; }

        public void Handle()
        {
            var actor = _context.Actors.FirstOrDefault(x => x.ActorId == ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Oyuncu bulunamadı");
            }
            actor.ActorName = Model.ActorName != default ? Model.ActorName : actor.ActorName;
            actor.ActorSurname = Model.ActorSurname != default ? Model.ActorSurname : actor.ActorSurname;
            _context.SaveChanges();
        }

        public class UpdateActorModel
        {
            public string ActorName { get; set; }
            public string ActorSurname { get; set; }
        }
    }
}
