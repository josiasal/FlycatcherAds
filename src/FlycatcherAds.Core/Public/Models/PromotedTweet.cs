using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class PromotedTweet
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("line_item_id")] public string LineItemId { get; set; }
        [JsonProperty("tweet_id")] public string TweetId { get; set; }
        [JsonProperty("entity_status")] public string EntityStatus { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("tweet_id_str")] public string TweetIdSt { get; set; }
        [JsonProperty("approval_status")] public string ApprovalStatus { get; set; }
        [JsonProperty("deleted")] public bool Deleted { get; set; }
    }
}