﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Infrastructure.DataModels
{
    public class PlayerDataModel
    {
        public long Id { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string TwoLetterISOCode { get; }

        public int ShirtNumber { get; }

        public string Position { get; }

        public static Domain.Player MapOut(PlayerDataModel player)
        => new Domain.Player(player.Id, player.Firstname, player.Lastname, player.TwoLetterISOCode, new DateTime(1985, 01, 01), DateTime.Today, player.ShirtNumber, player.Position);

        public static IEnumerable<Domain.Player> MapOut(IEnumerable<PlayerDataModel> matches)
        => matches.Select(match => MapOut(match));
    }
}
