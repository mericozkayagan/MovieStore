using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DbOperations;
using MovieStore.Operations.ActorOperations.Queries.GetActors;
using MovieStore.Operations.MovieOperations.Commands.CreateMovie;
using MovieStore.Operations.MovieOperations.Commands.DeleteMovie;
using MovieStore.Operations.MovieOperations.Commands.UpdateMovie;
using MovieStore.Operations.MovieOperations.Queries.GetMovieDetails;
using MovieStore.Operations.MovieOperations.Queries.GetMovies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : Controller
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public MovieController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetMovieDetails(int id)
        {
            GetMovieDetailsQuery query = new GetMovieDetailsQuery(_context, _mapper);
            query.MovieId = id;
            GetMovieDetailsQueryValidator validations = new GetMovieDetailsQueryValidator();
            validations.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieModel model)
        {
            CreateMovieCommand command = new CreateMovieCommand();
            command.Model = model;
            CreateMovieCommandValidator validations = new CreateMovieCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateMovie([FromBody] UpdateMovieModel updateMovie, int id)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);
            command.MovieId = id;
            command.Model = updateMovie;
            UpdateMovieCommandValidator validations = new UpdateMovieCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = id;
            DeleteMovieCommandValidator validations = new DeleteMovieCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
