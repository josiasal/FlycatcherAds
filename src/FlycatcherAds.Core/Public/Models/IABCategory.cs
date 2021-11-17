using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class IABCategory
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("parent_id")] public string parent_id { get; set; }
        [JsonProperty("name")] public object Name { get; set; }
    }
}
