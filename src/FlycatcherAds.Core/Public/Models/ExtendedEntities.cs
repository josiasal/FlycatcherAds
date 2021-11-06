using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlycatcherAds.Models
{
    public class ExtendedEntities
    {
        [JsonProperty("media")] public List<ExtendedMediaEntity> Medias { get; set; }
        [JsonProperty("video_info")] public VideoInfoEntity VideoInfo { get; set; }
    }
}