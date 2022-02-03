using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        private readonly IContext _context;
        public int DirectorId { get; set; }

        public DeleteDirectorCommand(IContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.DirectorId == DirectorId);
            if (director is null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadı");
            }
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}
