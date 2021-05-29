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
        public async Task<Result<IEnumerable<MatchDTO>>> GetAllMatches()
        {
            var query = new GetMatchesQuery();
            return new Result<IEnumerable<MatchDTO>>(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("matchday")]
        [ProducesResponseType(typeof(IEnumerable<MatchDTO>), 200)]
        [ProducesResponseType(typeof(Exception), 500)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<Result<IEnumerable<MatchDTO>>> GetMatchesFromLastMatchday()
        {
            var query = new GetMatchesFromLastMatchdayQuery();
            return new Result<IEnumerable<MatchDTO>>(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("matchday/last")]
        [ProducesResponseType(typeof(IEnumerable<MatchdayDTO>), 200)]
        [ProducesResponseType(typeof(Exception), 500)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<Result<MatchdayDTO>> GetLastMatchday()
        {
            var query = new GetLastMatchdayQuery();
            return new Result<MatchdayDTO>(await _mediator.Send(query));
        }
    }
}
