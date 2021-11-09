using GoalKeeper.Common.Application.IO;
using GoalKeeper.Stats.Application.IO.CommandModels;
using GoalKeeper.Stats.Application.IO.Commands;
using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Exceptions;
using GoalKeeper.Stats.Application.IO.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GoalKeeper.Stats.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly IMediator _mediator;

        public MatchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        //[ProducesResponseType(typeof(IEnumerable<MatchDTO>), 200)]
        //[ProducesResponseType(typeof(Exception), 500)]
        //[ProducesErrorResponseType(typeof(Exception))]
        //public async Task<Result<IEnumerable<MatchDTO>>> GetAllMatches()
        public async Task<IActionResult> GetAllMatches()
        {
            var query = new GetMatchesQuery();
            return Ok(new Result<IEnumerable<MatchDTO>>(await _mediator.Send(query)));
        }

        [HttpGet]
        [Route("matchday/{day}")]
        [ProducesResponseType(typeof(Result<MatchdayDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(Exception), 500)]
        //[ProducesErrorResponseType(typeof(Exception))]
        //public async Task<Result<MatchdayDTO>> GetMatchday([FromRoute] int day)
        public async Task<IActionResult> GetMatchday([FromRoute] int day)
        {
            try
            {
                var query = new GetMatchdayQuery(day);
                return Ok(new Result<MatchdayDTO>(await _mediator.Send(query)));
            }
            catch (MatchdayNotFoundException)
            {
                return NotFound();
            }
        }

        //[HttpGet]
        //[Route("matchday/upcoming/{day}")]
        //[ProducesResponseType(typeof(Result<MatchdayDTO>), 200)]
        //public async Task<IActionResult> GetUpcomingMatchday([FromRoute] int day)
        //{
        //    var query = new GetUpcomingMatchdayQuery(day);
        //    return Ok(new Result<MatchdayDTO>(await _mediator.Send(query)));
        //}

        //[HttpGet]
        //[Route("matchday/last")]
        ////[ProducesResponseType(typeof(Result<MatchdayDTO>), 200)]
        ////[ProducesResponseType(typeof(Exception), 500)]
        ////[ProducesErrorResponseType(typeof(Exception))]
        ////public async Task<Result<MatchdayDTO>> GetLastMatchday()
        //public async Task<IActionResult> GetLastMatchday()
        //{
        //    var query = new GetLastMatchdayQuery();
        //    return Ok(new Result<MatchdayDTO>(await _mediator.Send(query)));
        //}

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(BadRequestResult), 400)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesErrorResponseType(typeof(Exception))]
        //public async Task<Result<bool>> AddMatch([FromBody] MatchPlayedModel model)
        public async Task<IActionResult> AddMatch([FromBody] MatchPlayedModel model)
        {
            MatchPlayedCommand command = model.ToCommand();

            return CreatedAtAction(nameof(AddMatch), new Result<bool>(await _mediator.Send(command)));

            //return Ok(new Result<bool>(await _mediator.Send(command)));
            //return Created(new Uri("dunno what to put here"), model);
        }
    }
}
