using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        //[ProducesResponseType(typeof(List<FixtureDTO>), 200)]
        [ProducesResponseType(typeof(Exception), 500)]
        [ProducesErrorResponseType(typeof(Exception))]
        public IActionResult GetFixtures()
        {
            return Ok();
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
