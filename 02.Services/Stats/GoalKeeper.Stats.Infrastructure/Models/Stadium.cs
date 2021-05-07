using Newtonsoft.Json;

namespace GoalKeeper.Stats.Infrastructure.Models
{
    public class Stadium
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "capacity")]
        public int Capacity { get; set; }
    }
}
