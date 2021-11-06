using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlycatcherAds.Models
{
    public class LegacyEntities
    {
        [JsonProperty("hashtags")] public List<HashtagEntity> Hashtags { get; set; }
        [JsonProperty("media")] public List<MediaEntity> Medias { get; set; }
        [JsonProperty("urls")] public List<UrlEntity> Urls { get; set; }
        [JsonProperty("user_mentions")] public List<UserMentionEntity> UserMentions { get; set; }
        [JsonProperty("symbols")] public List<SymbolEntity> Symbols { get; set; }        
    }
}
