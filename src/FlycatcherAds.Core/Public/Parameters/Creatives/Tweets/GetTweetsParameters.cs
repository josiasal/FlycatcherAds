using System.Collections.Generic;

using FlycatcherAds.Models;

namespace FlycatcherAds.Parameters
{
    public interface IGetTweetsParameters
    {
        /// <summary>
        /// The identifier for the leveraged account. Appears within the
        /// resource's path and is generally a required parameter for all
        /// Advertiser API requests excluding GET accounts. The specified 
        /// account must be associated with the authenticated user.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// The Tweet type for the specified tweet_ids.
        /// Possible values: DRAFT, PUBLISHED, SCHEDULED
        /// </summary>
        TweetType TweetType { get; set; }
        
        /// <summary>
        /// Specifies the number of records to try and retrieve per distinct request.
        /// </summary>
        int? Count { get; set; }

        /// <summary>
        /// Specifies a cursor to get the next page of results. See Pagination for more information.
        /// </summary>
        string Cursor { get; set; }

        /// <summary>
        /// Whether to filter out mentions and replies from the list of available Tweets.
        /// </summary>
        bool? IncludeMentionsAndReplies { get; set; }

        /// <summary>
        /// Whether to return nullcasted (a.k.a. "Promoted-only") Tweets, organic Tweets, or both.
        /// Possible values: ALL, NULLCAST, ORGANIC
        /// </summary>
        TimelineType TimelineType { get; set; }

        /// <summary>
        /// Whether to exclude the user object in the Tweet response. When enabled,
        /// the only part of the user object that will be returned is the Tweet's
        /// author's user ID.
        /// </summary>
        bool? TrimUser { get; set; }

        /// <summary>
        /// A comma-separated list of identifiers. Up to 200 IDs may be provided.
        /// </summary>
        HashSet<long> TweetIds { get; set; }

        /// <summary>
        /// Specifies the user to scope Tweets to. Defaults to the FULL promotable user
        /// on the account when not set.
        long? UserId { get; set; }
    }

    public class GetTweetsParameters : IGetTweetsParameters
    {
        public GetTweetsParameters()
        {
            TweetIds = new HashSet<long>();
        }

        public string AccountId { get; set; }
        public TweetType TweetType { get; set; }
        public int? Count { get; set; }
        public string Cursor { get; set; }
        public bool? IncludeMentionsAndReplies { get; set; }
        public TimelineType TimelineType { get; set; }
        public bool? TrimUser { get; set; }
        public HashSet<long> TweetIds { get; set; }
        public long? UserId { get; set; }
    }
}
