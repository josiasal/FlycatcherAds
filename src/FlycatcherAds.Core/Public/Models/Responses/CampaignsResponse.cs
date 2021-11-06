using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class CampaignsResponse
    {
        [JsonProperty("next_cursor")] public string NextCursor { get; set; }
        [JsonProperty("data")] public Campaign[] Campaigns { get; set; }
    }
}