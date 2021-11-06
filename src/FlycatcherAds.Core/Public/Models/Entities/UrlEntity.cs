using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class UrlEntity
    {
        [JsonProperty("expanded_url")] public string ExpandedURL { get; set; }
        [JsonProperty("display_url")] public string DisplayedURL { get; set; }
        [JsonProperty("indices")] public int[] Indices { get; set; }
        [JsonProperty("url")] public string URL { get; set; }
    }
}
