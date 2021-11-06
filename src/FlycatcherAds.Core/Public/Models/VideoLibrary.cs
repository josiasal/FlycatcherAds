using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class VideoLibrary : BaseMediaLibrary
    {
        [JsonProperty("duration")] public long Duration { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("poster_media_key")] public string PosterMediaKey { get; set; }
        [JsonProperty("poster_media_url")] public string PosterMediaUrl { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("aspect_ratio")] public string AspectRatio { get; set; }
    }
}
