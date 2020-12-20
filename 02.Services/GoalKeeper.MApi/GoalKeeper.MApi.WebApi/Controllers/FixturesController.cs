using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoalKeeper.MApi.Application.IO;
using GoalKeeper.MApi.Application.IO.DTOs;
using GoalKeeper.MApi.Application.IO.Queries.Fixtures;
using GoalKeeper.MApi.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalKeeper.MApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FixturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<FixtureDTO>), 200)]
        [ProducesResponseType(typeof(Exception), 500)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<Result<List<FixtureDTO>>> GetFixtures()
        {
            var query = new GetFixturesQuery();
            return new Result<List<FixtureDTO>>(await _mediator.Send(query));
        }

        //[HttpGet]
        //[Route("")]
        //[ProducesResponseType(typeof(Result<List<TabelDefinitieDto>>), 200)]
        //[ProducesResponseType(typeof(ApiError), 400)]
        //[ProducesResponseType(typeof(ApiError), 403)]
        //[ProducesResponseType(typeof(ApiError), 500)]
        //public async Task<Result<List<TabelDefinitieDto>>> GetAllTabellen()
        //{
        //    return new Result<List<TabelDefinitieDto>>(await _mediator.Send(new GetAllTabellenQuery()));
        //}
    }
}
