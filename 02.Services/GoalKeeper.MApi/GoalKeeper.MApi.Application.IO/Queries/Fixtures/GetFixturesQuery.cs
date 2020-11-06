using GoalKeeper.MApi.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace GoalKeeper.MApi.Application.IO.Queries.Fixtures
{
    public class GetFixturesQuery : IRequest<List<Fixture>>
    {
    }
}
