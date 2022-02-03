using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DbOperations;
using MovieStore.Operations.ActorOperations.Commands;
using MovieStore.Operations.ActorOperations.Commands.CreateActor;
using MovieStore.Operations.ActorOperations.Commands.DeleteActor;
using MovieStore.Operations.ActorOperations.Commands.UpdateActor;
using MovieStore.Operations.ActorOperations.Queries.GetActorDetails;
using MovieStore.Operations.ActorOperations.Queries.GetActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MovieStore.Operations.ActorOperations.Commands.CreateActorCommand;
using static MovieStore.Operations.ActorOperations.Commands.UpdateActor.UpdateActorCommand;
using static MovieStore.Operations.ActorOperations.Queries.GetActorDetails.GetActorDetailsQuery;
using static MovieStore.Operations.ActorOperations.Queries.GetActors.GetActorsQuery;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : Controller
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public ActorController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorsQuery query = new GetActorsQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetActorDetails(int id)
        {
            ActorDetailModel result;

            GetActorDetailsQuery query = new GetActorDetailsQuery(_context, _mapper);
            query.ActorId = id;
            GetActorDetailQueryValidator validations = new GetActorDetailQueryValidator();
            validations.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorModel newActor)
        {
            CreateActorCommand command = new CreateActorCommand(_context,_mapper);
            command.Model = newActor;

            CreateActorCommandValidator validations = new CreateActorCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateActor([FromBody] UpdateActorModel newModel, int id)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context,_mapper);
            command.Model = newModel;
            command.ActorId = id;
            UpdateActorCommandValidator validations = new UpdateActorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpDelete("id")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context,_mapper);
            command.ActorId = id;
            DeleteActorCommandValidator validations = new DeleteActorCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
