using GoalKeeper.Common.Application.IO;
using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalKeeper.Stats.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{teamId}")]
        //[ProducesResponseType(typeof(IEnumerable<PlayerDTO>), 200)]
        //[ProducesResponseType(typeof(Exception), 500)]
        //[ProducesErrorResponseType(typeof(Exception))]
        //public async Task<Result<IEnumerable<PlayerDTO>>> GetPlayersByTeamId([FromRoute] long teamId)
        public async Task<IActionResult> GetPlayersByTeamId([FromRoute] long teamId)
        {
            var query = new GetPlayersByTeamIdQuery(teamId);
            return Ok(new Result<IEnumerable<PlayerDTO>>(await _mediator.Send(query)));
        }
    }
}
