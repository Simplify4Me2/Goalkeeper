using GoalKeeper.Common.Application.IO;
using GoalKeeper.Statistics.Application.IO.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Statistics.MApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RankingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<object>), 200)]
        [ProducesResponseType(typeof(Exception), 500)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<Result<List<object>>> GetRanking()
        {
            var query = new GetRankingQuery();
            return new Result<List<object>>(await _mediator.Send(query));
        }
    }
}
