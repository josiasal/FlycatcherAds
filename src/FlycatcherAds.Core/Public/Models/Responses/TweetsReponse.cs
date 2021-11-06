using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class TweetsResponse
    {
        [JsonProperty("next_cursor")] public string NextCursor { get; set; }
        [JsonProperty("data")] public Tweet[] Tweets { get; set; }
    }
}
