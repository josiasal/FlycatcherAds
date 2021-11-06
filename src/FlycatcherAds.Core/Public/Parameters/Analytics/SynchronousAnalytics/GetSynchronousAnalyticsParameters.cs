using System;
using System.Collections.Generic;

using Tweetinvi.Parameters;

namespace FlycatcherAds.Parameters
{
    public interface IGetSynchronousAnalyticsParameters : ICustomRequestParameters
    {   
        /// <summary>
        /// The identifier for the leveraged account. Appears within the resource's
        /// path and is generally a required parameter for all Advertiser API requests
        /// excluding GET accounts.
        /// The specified account must be associated with the authenticated user.
        /// </summary>
        string AccountId { get; set; }


        /// <summary>
        /// Scopes the retrieved data to the specified start time, expressed in
        /// <a href="https://en.wikipedia.org/wiki/ISO_8601">ISO 8601</a>.
        /// Note: Must be expressed in whole hours (0 minutes and 0 seconds).
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// Scopes the retrieved data to the specified end time, expressed in
        /// <a href="https://en.wikipedia.org/wiki/ISO_8601">ISO 8601</a>.
        /// Note: Must be expressed in whole hours (0 minutes and 0 seconds).
        /// </summary>
        DateTime EndTime { get; set; }
        
        /// <summary>
        /// The entity type to retrieve data for.
        /// Possible values: 
        ///     ACCOUNT, CAMPAIGN, FUNDING_INSTRUMENT, LINE_ITEM, ORGANIC_TWEET,
        ///     PROMOTED_ACCOUNT, PROMOTED_TWEET, MEDIA_CREATIVE
        /// </summary>
        string EntityType { get; set; }

        /// <summary>
        /// The specific entities to retrieve data for. Specify a comma-separated
        /// list of entity IDs.
        /// Note: Up to 20 entity IDs may be provided.
        /// </summary>
        HashSet<string> EntityIds { get; set; }

        /// <summary>
        /// Specify how granular the retrieved data should be.
        /// Possible values: DAY, HOUR, TOTAL
        string Granularity { get; set; }

        /// <summary>
        /// The specific metrics that should be returned. Specify a comma-separated
        /// list of metric groups. For more information see
        /// <a href="https://developer.twitter.com/en/docs/ads/analytics/overview/metrics-and-segmentation">Metrics and Segmentation.</a>
        HashSet<string>  MetricGroups { get; set; }

        /// <summary>
        /// Scopes the retrieved data to a particular placement.
        /// Note: Only a single value accepted per request. For entities with
        /// both Twitter and Twitter Audience Platform placement, separate 
        /// requests are required, one for each placement value.
        /// Possible values: ALL_ON_TWITTER, PUBLISHER_NETWORK
        string Placement { get; set; }
    }

    public class GetSynchronousAnalyticsParameters : CustomRequestParameters, IGetSynchronousAnalyticsParameters
    {
        public GetSynchronousAnalyticsParameters()
        {
            EntityIds = new HashSet<string>();
            MetricGroups = new HashSet<string>();
        }

        public GetSynchronousAnalyticsParameters(IGetSynchronousAnalyticsParameters parameters) : base(parameters)
        {
            AccountId = parameters.AccountId;
            StartTime = parameters.StartTime;
            EndTime = parameters.EndTime;
            EntityType = parameters.EntityType;
            EntityIds = new HashSet<string>(parameters.EntityIds);
            Granularity = parameters.Granularity;
            MetricGroups = new HashSet<string>(parameters.MetricGroups);
            Placement = parameters.Placement;
        }

        public string AccountId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EntityType { get; set; }
        public HashSet<string> EntityIds { get; set; }
        public string Granularity { get; set; }
        public HashSet<string> MetricGroups { get; set; }
        public string Placement { get; set; }
    }
}