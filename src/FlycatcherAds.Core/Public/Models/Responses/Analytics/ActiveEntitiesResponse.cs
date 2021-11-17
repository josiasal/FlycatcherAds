using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class ActiveEntitiesResponse
    {
        [JsonProperty("data")] public ActiveEntity[] ActiveEntities { get; set; }
    }
}
