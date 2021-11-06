using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class AdsAccountsResponse
    {
        [JsonProperty("next_cursor")] public string NextCursor { get; set; }
        [JsonProperty("data")] public AdsAccount[] Accounts { get; set; }
    }
}