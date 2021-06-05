using GoalKeeper.Common.Application.IO;
using GoalKeeper.Stats.Application.IO.DTOs;
using GoalKeeper.Stats.Application.IO.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [ProducesResponseType(typeof(IEnumerable<TeamDTO>), 200)]
        [ProducesResponseType(typeof(Exception), 500)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<Result<IEnumerable<TeamDTO>>> GetTeams()
        {
            var query = new GetTeamsQuery();
            return new Result<IEnumerable<TeamDTO>>(await _mediator.Send(query));
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

        [HttpGet]
        [Route("{name}")]
        [ProducesResponseType(typeof(TeamDTO), 200)]
        [ProducesResponseType(typeof(Exception), 500)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<Result<TeamDTO>> GetTeamByName([FromRoute] string name)
        {
            var query = new GetTeamByNameQuery(name);
            return new Result<TeamDTO>(await _mediator.Send(query));
        }

    }
}
