using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlycatcherAds.Models
{
    public class ExtendedMediaEntity : MediaEntity
    {
        [JsonProperty("media")] public List<MediaEntity> Medias { get; set; }
     }
}
