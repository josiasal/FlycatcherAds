using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class AdsAccount
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("business_name")] public string BusinessName { get; set; }
        [JsonProperty("timezone")] public string Timezone { get; set; }
        [JsonProperty("timezone_switch_at")] public string TimezoneSwitchAt { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("business_id")] public string BusinessId { get; set; }
        [JsonProperty("approval_status")] public string ApprovalStatus { get; set; }
        [JsonProperty("deleted")] public bool Deleted { get; set; }
    }
}
