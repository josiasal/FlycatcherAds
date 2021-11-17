using Newtonsoft.Json;

using FlycatcherAds.Core.JsonConverters;

namespace FlycatcherAds.Models
{
    public class MediaLibraryResponse
    {
        [JsonProperty("next_cursor")] public string NextCursor { get; set; }

        [JsonProperty("data")]
        [JsonConverter(typeof(MediaLibraryConverter))]
        public BaseMediaLibrary[] MediaLibraries { get; set; }
    }
}