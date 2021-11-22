using GoalKeeper.DataCollector.Application.IO.DTOs;
using System.Linq;

namespace GoalKeeper.DataCollector.Application.Mappers
{
    public static class MatchMapper
    {
        public static MatchDTO MapOut(this Domain.Match match)
        {
            return new MatchDTO
            {
                
            };
        }

        public static MatchDTO[] MapOut(this Domain.Match[] matches)
            => matches.Select(match => MapOut(match)).ToArray();

    }
}
