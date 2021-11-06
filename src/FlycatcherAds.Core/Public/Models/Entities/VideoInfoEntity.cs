using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class VideoInfoEntity
    {
        [JsonProperty("aspect_ratio")] public int[] AspectRatio { get; set; }
        [JsonProperty("duration_millis")] public int DurationInMilliseconds { get; set; }
        [JsonProperty("variants")] public VideoEntityVariant[] Variants { get; set; }
    }
}