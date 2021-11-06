using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class ImageLibrary : BaseMediaLibrary
    {
        [JsonProperty("original_width")] public int OriginalWidth { get; set; }
        [JsonProperty("original_height")] public int OriginalHeight { get; set; }
    }
}
