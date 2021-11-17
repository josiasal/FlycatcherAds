using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class AsynchronousAnalyticsJobInfoResponse
    {
        [JsonProperty("data")] public AsynchronousAnalyticsJobInfo AsynchrounousAnalyticsJobInfo { get; set; }
    }
}
