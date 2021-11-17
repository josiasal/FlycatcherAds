using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class CustomAudience
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("targetable")] public bool Targetable { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("targetable_types")] public string[] TargetableTypes { get; set; }
        [JsonProperty("audience_type")] public string AudienceType { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("permission_level")] public string PermissionLevel { get; set; }
        [JsonProperty("owner_account_id")] public string OwnerAccountId { get; set; }
        [JsonProperty("reasons_not_targetable")] public string[] ReasonsNotTargetable { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("partner_source")] public string PartnerSource { get; set; }
        [JsonProperty("deleted")] public bool Deleted { get; set; }
        [JsonProperty("audience_size")] public int? AudienceSize { get; set; }
    }
}
