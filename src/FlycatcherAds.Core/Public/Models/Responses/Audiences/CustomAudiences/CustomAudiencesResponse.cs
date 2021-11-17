using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class CustomAudiencesResponse
    {
        [JsonProperty("next_cursor")] public string NextCursor { get; set; }
        [JsonProperty("data")] public CustomAudience[] CustomAudiences { get; set; }
    }
}
