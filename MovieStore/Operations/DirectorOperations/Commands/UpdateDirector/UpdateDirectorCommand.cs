using AutoMapper;
using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly IContext _context;


        public UpdateDirectorCommand(IContext context)
        {
            _context = context;

        }

        public UpdateDirectorModel Model { get; set; }
        public int DirectorId { get; set; }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.DirectorId == DirectorId);
            if (director is null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadı");
            }
            director.DirectorName = Model.DirectorName != default ? Model.DirectorName : director.DirectorName;
            director.DirectorName = Model.DirectorSurname != default ? Model.DirectorSurname : director.DirectorSurname;
            _context.SaveChanges();
        }

        public class UpdateDirectorModel
        {
            public string DirectorName { get; set; }
            public string DirectorSurname { get; set; }
        }
    }
}
