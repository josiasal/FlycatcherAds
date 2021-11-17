using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class AdsAccountResponse
    {
        [JsonProperty("data")] public AdsAccount Account { get; set; }
    }
}