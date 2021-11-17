using GoalKeeper.Common.Application.IO;
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
    public class TeamController : Controller
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(Result<IEnumerable<TeamDTO>>), 200)]
        public async Task<IActionResult> GetTeams()
        {
            var query = new GetTeamsQuery();
            return Ok(new Result<IEnumerable<TeamDTO>>(await _mediator.Send(query)));
        }

        //[HttpGet]
        //[Route("{id}")]
        //[ProducesResponseType(typeof(TeamDTO), 200)]
        //[ProducesResponseType(typeof(Exception), 500)]
        //[ProducesErrorResponseType(typeof(Exception))]
        //public async Task<Result<TeamDTO>> GetTeamById([FromRoute] long id)
        //{
        //    var query = new GetTeamByIdQuery(id);
        //    return new Result<TeamDTO>(await _mediator.Send(query));
        //}

        /// <summary>
        ///  This is a summary
        /// </summary>
        /// <param name="name">Namediedoo</param>
        /// <returns>Somezing</returns>
        /// <response code="200">Great success</response>
        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(typeof(Result<TeamDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTeamByName([FromRoute] string name)
        {
            try
            {
                var query = new FindTeamByNameQuery(name);
                return Ok(new Result<TeamDTO>(await _mediator.Send(query)));
            }
            // TODO: Refactor to determine api status
            // https://ardalis.com/avoid-using-exceptions-determine-api-status/
            catch (TeamNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
