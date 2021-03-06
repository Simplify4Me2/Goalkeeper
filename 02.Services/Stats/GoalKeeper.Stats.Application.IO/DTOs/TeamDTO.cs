﻿using System.Collections.Generic;

namespace GoalKeeper.Stats.Application.IO.DTOs
{
    public class TeamDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<PlayerDTO> Players { get; set; }
    }
}
