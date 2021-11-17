using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class ActiveEntity
    {
        [JsonProperty("entity_id")] public string EntityId { get; set; }
        [JsonProperty("activity_start_time")] public DateTimeOffset ActivityStartTime { get; set; }
        [JsonProperty("activity_end_time")] public DateTimeOffset ActivityEndTime { get; set; }
        [JsonProperty("placements")] public Placement[] Placements { get; set; }
    }
}
