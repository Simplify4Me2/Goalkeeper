using GoalKeeper.MApi.Application.IO.DTOs;
using MediatR;
using System.Collections.Generic;

namespace GoalKeeper.MApi.Application.IO.Queries.Fixtures
{
    public class GetFixturesQuery : IRequest<List<FixtureDTO>>
    {
    }
}
