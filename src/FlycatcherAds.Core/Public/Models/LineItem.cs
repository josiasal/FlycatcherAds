using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class LineItem
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("advertiser_user_id")] public long AdvertiserUserId { get; set; }
        [JsonProperty("campaign_id")] public string CampaignId { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("placements")] public Placement[] Placements { get; set; }
        [JsonProperty("start_time")] public DateTimeOffset? StartTime { get; set; }
        [JsonProperty("bid_amount_local_micro")] public long? BidAmountLocalMicro { get; set; }
        [JsonProperty("advertiser_domain")] public string AdvertiserDomain { get; set; }
        [JsonProperty("target_cpa_local_micro")] public long? TargetCpaLocalMicro { get; set; }
        [JsonProperty("primary_web_event_tag")] public string PrimaryWebEventTag { get; set; }
        [JsonProperty("goal")] public Goal Goal { get; set; }
        [JsonProperty("product_type")] public ProductType ProductType { get; set; }
        [JsonProperty("end_time")] public DateTimeOffset? EndTime { get; set; }
        [JsonProperty("bid_strategy")] public BidStrategy BidStrategy { get; set; }
        [JsonProperty("duration_in_days")] public int? DurationInDays { get; set; }
        [JsonProperty("total_budget_amount_local_micro")] public long? TotalBudgetAmountLocalMicro { get; set; }
        [JsonProperty("objective")] public Objective Objective { get; set; }
        [JsonProperty("entity_status")] public EntityStatus EntityStatus { get; set; }
        [JsonProperty("frequency_cap")] public int? FrequencyCap { get; set; }
        [JsonProperty("android_app_store_identifier")] public string AndroidAppStoreIdentifier { get; set; }
        [JsonProperty("categories")] public IABCategory[] Categories { get; set; }
        [JsonProperty("currency")] public string Currency { get; set; }
        [JsonProperty("pay_by")] public PayBy PayBy { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("ios_app_store_identifier")] public string IosAppStoreIdentifier { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("creative_source")] public string CreativeSource { get; set; }
        [JsonProperty("deleted")] public bool Deleted { get; set; }
    }
}