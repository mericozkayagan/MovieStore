using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DbOperations;
using MovieStore.Operations.DirectorOperations.Commands.CreateDirector;
using MovieStore.Operations.DirectorOperations.Commands.DeleteDirector;
using MovieStore.Operations.DirectorOperations.Commands.UpdateDirector;
using MovieStore.Operations.DirectorOperations.Queries.GetDirectorDetails;
using MovieStore.Operations.DirectorOperations.Queries.GetDirectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MovieStore.Operations.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static MovieStore.Operations.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : Controller
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorsQuery query = new GetDirectorsQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("id")]
        public IActionResult GetDirectorDetails(int id)
        {
            GetDirectorDetailsQuery query = new GetDirectorDetailsQuery(_context, _mapper);
            query.DirectorId = id;
            GetDirectorDetailsValidator validations = new GetDirectorDetailsValidator();
            validations.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDirector([FromBody] CreateDirectorModel model)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = model;
            CreateDirectorCommandValidator validations = new CreateDirectorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateDirector([FromBody] UpdateDirectorModel model, int id)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.Model = model;
            command.DirectorId = id;
            UpdateDirectorCommandValidator validations = new UpdateDirectorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;
            DeleteDirectorCommandValidator validations = new DeleteDirectorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
            
        }
















    }
}
