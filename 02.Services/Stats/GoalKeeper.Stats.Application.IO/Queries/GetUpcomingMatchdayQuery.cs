﻿using GoalKeeper.Stats.Application.IO.DTOs;
using MediatR;

namespace GoalKeeper.Stats.Application.IO.Queries
{
    public class GetUpcomingMatchdayQuery : IRequest<MatchdayDTO>
    {
        public int Matchday { get; }

        public GetUpcomingMatchdayQuery(int matchday)
        {
            Matchday = matchday;
        }
    }
}
