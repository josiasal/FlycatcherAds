using System;
using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class Tweet
    {
        /// <summary>
        /// Contains details about the location tagged by the user in this Tweet,
        /// if they specified one.
        /// </summary>
        [JsonProperty("coordinates")] public Coordinates Coordinates { get; set; }
        
        /// <summary>
        /// Indicates if the current tweet was retweeted by another user
        /// </summary>
        [JsonProperty("retweeted")] public bool Retweeted { get; set; }

        /// <summary>
        /// who can reply to this Tweet. Anyone mentioned can always reply.
        /// Possible values: EVERYONE, FOLLOWING, MENTIONED_USERS
        [JsonProperty("conversation_settings")] public string ConversationSettings { get; set; }

        /// <summary>
        /// The name of the app the user Tweeted from.
        /// </summary>
        [JsonProperty("source")] public string Source { get; set; }
        [JsonProperty("display_text_range")] public int[] DisplayTextRange { get; set; }
        [JsonProperty("favorite_count")] public int FavoriteCount { get; set; }
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("in_reply_to_status_id")] public long? InReplyToStatusId { get; set; }
        [JsonProperty("in_reply_to_status_id_str")] public string InReplyToStatusIdStr { get; set; }
        [JsonProperty("id_str")] public string IdStr { get; set; }

        /// <summary>
        /// If the represented Tweet is a reply, this field will contain the original Tweet’s author ID.
        /// This will not necessarily always be the user directly mentioned in the Tweet.
        /// </summary>
        [JsonProperty("in_reply_to_user_id")] public string InReplyToUserId { get; set; }
        [JsonProperty("truncated")] public bool Truncated { get; set; }
        [JsonProperty("retweet_count")] public int RetweetCount { get; set; }
        [JsonProperty("scheduled_status")] public string ScheduledStatus { get; set; }

        /// <summary>
        /// This field only surfaces when a Tweet contains a link.
        /// The meaning of the field doesn’t pertain to the Tweet content itself, but instead it is an indicator
        /// that the URL contained in the Tweet may contain content or media identified as sensitive content.
        /// </summary>
        [JsonProperty("possibly_sensitive")] public bool PossiblySensitive { get; set; }

        /// <summary>
        /// Tweets may either be nullcasted (a.k.a. "Promoted-only") or organic
        /// </summary>
        [JsonProperty("nullcast")] public bool NullCast { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("scheduled_at")] public DateTimeOffset ScheduledAt { get; set; }
        [JsonProperty("tweet_type")] public string TweetType { get; set; }
        [JsonProperty("favorited")] public bool Favorited { get; set; }
        [JsonProperty("full_text")] public string FullText { get; set; }
        [JsonProperty("lang")] public string Lang { get; set; }
        [JsonProperty("in_reply_to_screen_name")] public string InReplyToScreenName { get; set; }
        [JsonProperty("in_reply_to_user_id_str")] public string InReplyToUserIdStr { get; set; }
        [JsonProperty("tweet_id")] public string TweetId { get; set; }

        /// <summary>
        /// Entities which have been parsed out of the text of the Tweet.
        /// </summary>
        [JsonProperty("entities")] public LegacyEntities LegacyEntities { get; set; }

        /// <summary>
        /// Extended Entities which have been parsed out of the text of the Tweet.
        /// </summary>
        [JsonProperty("extended_entities")] public ExtendedEntities Entities { get; set; }
    }
}