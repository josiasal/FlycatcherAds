using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class AsynchronousAnalyticsJobInfo
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("start_time")] public DateTimeOffset StartTime { get; set; }
        [JsonProperty("end_time")] public DateTimeOffset EndTime { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("segementation_type")] public SegmentationType SegementationType { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("entity_ids")] public string[] EntityIds { get; set; }
        [JsonProperty("id_str")] public string IdStr { get; set; }
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("placement")] public Placement Placement { get; set; }
        [JsonProperty("expires_at")] public DateTimeOffset? ExpiresAt { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("entity")] public EntityType Entity { get; set; }
        [JsonProperty("platform")] public string Platform { get; set; }
        [JsonProperty("metric_groups")] public MetricGroup[] MetricGroups { get; set; }
    }
}
