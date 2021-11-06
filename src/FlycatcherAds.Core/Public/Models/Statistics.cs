using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class Statistics
    {
        [JsonProperty("segment")] public JRaw Segment { get; set; }
        [JsonProperty("metrics")] public Dictionary<string, List<int>> Metrics { get; set; }
    }
}
