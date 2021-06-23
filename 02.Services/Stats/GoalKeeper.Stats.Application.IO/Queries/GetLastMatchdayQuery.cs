﻿using GoalKeeper.Stats.Application.IO.DTOs;
using MediatR;

namespace GoalKeeper.Stats.Application.IO.Queries
{
    public class GetLastMatchdayQuery : IRequest<MatchdayDTO>
    {
    }
}
