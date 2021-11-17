using System;
using System.Collections.Generic;

using Tweetinvi.Parameters;
using FlycatcherAds.Models;

namespace FlycatcherAds.Parameters
{
    public interface IGetSynchronousAnalyticsParameters : IBaseAnalyticsParameters
    {   
        /// <summary>
        /// The specific entities to retrieve data for. Specify a comma-separated
        /// list of entity IDs.
        /// Note: Up to 20 entity IDs may be provided.
        /// </summary>
        HashSet<string> EntityIds { get; set; }

        /// <summary>
        /// Specify how granular the retrieved data should be.
        /// Possible values: DAY, HOUR, TOTAL
        FlycatcherAds.Models.Granularity Granularity { get; set; }

        /// <summary>
        /// The specific metrics that should be returned. Specify a comma-separated
        /// list of metric groups. For more information see
        /// <a href="https://developer.twitter.com/en/docs/ads/analytics/overview/metrics-and-segmentation">Metrics and Segmentation.</a>
        HashSet<MetricGroup>  MetricGroups { get; set; }

        /// <summary>
        /// Scopes the retrieved data to a particular placement.
        /// Note: Only a single value accepted per request. For entities with
        /// both Twitter and Twitter Audience Platform placement, separate 
        /// requests are required, one for each placement value.
        /// Possible values: ALL_ON_TWITTER, PUBLISHER_NETWORK
        Placement Placement { get; set; }
    }

    public class GetSynchronousAnalyticsParameters : BaseAnalyticsParameters, IGetSynchronousAnalyticsParameters
    {
        public GetSynchronousAnalyticsParameters()
        {
            EntityIds = new HashSet<string>();
            MetricGroups = new HashSet<MetricGroup>();
        }

        public GetSynchronousAnalyticsParameters(IGetSynchronousAnalyticsParameters parameters) : base(parameters)
        {
            EntityIds = new HashSet<string>(parameters.EntityIds);
            Granularity = parameters.Granularity;
            MetricGroups = new HashSet<MetricGroup>(parameters.MetricGroups);
            Placement = parameters.Placement;
        }

        public HashSet<string> EntityIds { get; set; }
        public FlycatcherAds.Models.Granularity Granularity { get; set; }
        public HashSet<MetricGroup> MetricGroups { get; set; }
        public Placement Placement { get; set; }
    }
}
