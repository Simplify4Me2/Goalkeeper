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
    public class MatchController : Controller
    {
        private readonly IMediator _mediator;

        public MatchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<MatchDTO>), 200)]
        [ProducesResponseType(typeof(Exception), 500)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<Result<IEnumerable<MatchDTO>>> GetTeams()
        {
            var query = new GetMatchesQuery();
            return new Result<IEnumerable<MatchDTO>>(await _mediator.Send(query));
        }
    }
}
