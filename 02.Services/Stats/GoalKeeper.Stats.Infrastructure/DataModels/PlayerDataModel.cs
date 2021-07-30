using System;
using System.Collections.Generic;
using System.Linq;

namespace GoalKeeper.Stats.Infrastructure.DataModels
{
    public class PlayerDataModel
    {
        public long Id { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public int ShirtNumber { get; }

        public string Position { get; }

        public static Domain.Entities.Player MapOut(PlayerDataModel player)
        => new Domain.Entities.Player(player.Id, player.Firstname, player.Lastname, new DateTime(1985, 01, 01), DateTime.Today, player.ShirtNumber, player.Position);

        public static IEnumerable<Domain.Entities.Player> MapOut(IEnumerable<PlayerDataModel> matches)
        => matches.Select(match => MapOut(match));
    }
}
