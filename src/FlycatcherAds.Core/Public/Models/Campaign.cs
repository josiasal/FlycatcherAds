using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class Campaign
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("start_time")] public DateTimeOffset StartTime { get; set; }
        [JsonProperty("reasons_not_servable")] public string[] ReasonsNotServable { get; set; }
        [JsonProperty("servable")] public bool Servable { get; set; }
        [JsonProperty("purchase_order_number")] public string PurchaseOrderNumber { get; set; }
        [JsonProperty("effective_status")] public string EffectiveStatus { get; set; }
        [JsonProperty("daily_budget_amount_local_micro")] public long DailyBudgetAmountLocalMicro { get; set; }
        [JsonProperty("end_time")] public DateTimeOffset? EndTime { get; set; }
        [JsonProperty("funding_instrument_id")] public string FundingInstrumentId { get; set; }
        [JsonProperty("duration_in_days")] public int? DurationInDays { get; set; }
        [JsonProperty("standard_delivery")] public bool StandardDelivery { get; set; }
        [JsonProperty("total_budget_amount_local_micro")] public long? TotalBudgetAmountLocalMicro { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("entity_status")] public string EntityStatus { get; set; }
        [JsonProperty("frequency_cap")] public int? FrequencyCap { get; set; }
        [JsonProperty("currency")] public string Currency { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("deleted")] public bool Deleted { get; set; }
    }
}
