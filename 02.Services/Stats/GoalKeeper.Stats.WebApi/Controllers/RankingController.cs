using GoalKeeper.Common.Application.IO;
using GoalKeeper.Stats.Application.IO.DTOs;
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
    public class RankingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RankingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        //[ProducesResponseType(typeof(RankingDTO), 200)]
        //[ProducesResponseType(typeof(Exception), 500)]
        //[ProducesErrorResponseType(typeof(Exception))]
        //public async Task<Result<RankingDTO>> GetRanking()
        public async Task<IActionResult> GetRanking()
        {
            var query = new GetRankingQuery();
            return Ok(new Result<RankingDTO>(await _mediator.Send(query)));
        }
    }
}
