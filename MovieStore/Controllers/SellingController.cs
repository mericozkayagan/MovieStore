using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DbOperations;
using MovieStore.Operations.SellingOperations.GetSellings;
using MovieStore.Operations.SellingOperations.SellMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class SellingController : Controller
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public SellingController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSellings()
        {
            GetSellingsQuery query = new GetSellingsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(query);
        }

        [HttpPost]
        public IActionResult SellMovie([FromBody] SellMovieModel model)
        {
            SellMovieCommand command = new SellMovieCommand(_context, _mapper);
            command.Model = model;
            SellMovieCommandValidator validations = new SellMovieCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}
