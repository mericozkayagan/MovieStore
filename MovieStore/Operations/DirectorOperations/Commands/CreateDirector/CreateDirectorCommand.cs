using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorModel Model { get; set; }

        public CreateDirectorCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _context.Directors.FirstOrDefault(x => x.DirectorName == Model.DirectorName && x.DirectorSurname==Model.DirectorSurname);
            if (director is not null)
            {
                throw new InvalidOperationException("Yönetmen zaten mevcut");
            }
            director=_mapper.Map<Director>(Model);
            _context.Directors.Add(director);
            _context.SaveChanges();
        }

        public class CreateDirectorModel
        {
            public string DirectorName { get; set; }
            public string DirectorSurname { get; set; }
        }
    }
}
