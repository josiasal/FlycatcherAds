using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class StatisticsData
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("id_data")] public Statistics[] Statistics { get; set; }
    }
}