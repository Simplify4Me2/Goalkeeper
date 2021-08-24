using GoalKeeper.Stats.Domain.ValueObjects;

namespace GoalKeeper.Stats.Infrastructure.DataModels
{
    public class StadiumDataModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string PictureUrl { get; set; }

        public static Stadium MapOut(StadiumDataModel stadium)
        {
            return new Stadium(stadium.Id, stadium.Name);
        }
    }
}
