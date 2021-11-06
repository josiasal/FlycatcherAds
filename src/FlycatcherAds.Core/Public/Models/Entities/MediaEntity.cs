using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlycatcherAds.Models
{
    /// <summary>
    /// Object storing information related with a Media on Twitter
    /// </summary>
    public class MediaEntity
    {
        [JsonProperty("display_url")] public string DisplayURL { get; set; }
        [JsonProperty("expanded_url")] public string ExpandedURL { get; set; }
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("id_str")] public string IdStr { get; set; }
        [JsonProperty("indices")] public int[] Indices { get; set; }
        [JsonProperty("media_url")] public string MediaURL { get; set; }
        [JsonProperty("media_url_https")] public string MediaURLHttps { get; set; }
        [JsonProperty("sizes")] public Dictionary<string, MediaEntitySize> Sizes { get; set; }
        [JsonProperty("source_status_id")] public long? SourceStatusId { get; set; }
        [JsonProperty("source_status_id_str")] public string SourceStatusIdStr { get; set; }
        [JsonProperty("type")] public string MediaType { get; set; }
        [JsonProperty("url")] public string URL { get; set; }
        [JsonProperty("video_info")] public VideoInfoEntity VideoDetails { get; set; }
    }
}
