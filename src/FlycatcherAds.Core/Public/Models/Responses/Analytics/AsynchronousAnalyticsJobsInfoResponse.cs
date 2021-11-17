using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class AsynchronousAnalyticsJobsInfoResponse
    {
        [JsonProperty("next_cursor")] public string NextCursor { get; set; }
        [JsonProperty("data")] public AsynchronousAnalyticsJobInfo[] AsynchrounousAnalyticsJobs { get; set; }
    }
}
