﻿using GoalKeeper.Stats.Application.IO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Application.Mappers
{
    public static class PlayerMapper
    {
        public static PlayerDTO MapOut(this Domain.Player player)
        {
            return new PlayerDTO
            {
                Id = player.Id,
                FirstName = player.Firstname,
                LastName = player.Lastname,
                Nationality = player.Nationality,
                ShirtNumber = player.ShirtNumber,
                Position = player.Position
            };
        }

        public static IEnumerable<PlayerDTO> MapOut(this IEnumerable<Domain.Player> players)
            => players.Select(player => player.MapOut());
    }
}
