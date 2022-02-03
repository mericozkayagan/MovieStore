using AutoMapper;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public DeleteActorCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int ActorId { get; set; }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.ActorId == ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Oyuncu bulunamadı");
            }
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
       
    }
}
