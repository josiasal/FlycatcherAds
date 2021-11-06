using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class BaseMediaLibrary
    {
        [JsonProperty("tweeted")] public bool Tweeted { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("file_name")] public string FileName { get; set; }
        [JsonProperty("media_url")] public string MediaUrl { get; set; }
        [JsonProperty("media_key")] public string MediaKey { get; set; }
        [JsonProperty("created_at")] public DateTime CreatedAt { get; set; }
        [JsonProperty("media_status")] public string MediaStatus { get; set; }
        [JsonProperty("media_type")] public string MediaType { get; set; }
        [JsonProperty("updated_at")] public DateTime UpdatedAt { get; set; }
        [JsonProperty("deleted")] public bool Deleted { get; set; }
    }
}
