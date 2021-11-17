using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class LineItemsResponse
    {
        [JsonProperty("next_cursor")] public string NextCursor { get; set; }
        [JsonProperty("data")] public LineItem[] LineItems { get; set; }
    }
}
