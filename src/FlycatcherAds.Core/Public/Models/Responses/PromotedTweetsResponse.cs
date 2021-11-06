using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class PromotedTweetsResponse
    {
        [JsonProperty("next_cursor")] public string NextCursor { get; set; }
        [JsonProperty("data")] public PromotedTweet[] PromotedTweets { get; set; }
    }
}
