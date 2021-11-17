using System;
using System.Collections.Generic;

using Tweetinvi.Parameters;

using FlycatcherAds.Models;

namespace FlycatcherAds.Parameters
{
    public interface ICreateAsynchronousAnalyticsJobParameters : IBaseAnalyticsParameters
    {
        /// <summary>
        /// The specific entities to retrieve data for. Specify a comma-separated
        /// list of entity IDs
        /// </summary>
        HashSet<string> EntityIds { get; set; }

        /// <summary>
        /// Specify how granular the retrieved data should be
        /// </summary>
        FlycatcherAds.Models.Granularity Granularity { get; set; }

        /// <summary>
        /// The specific metrics that should be returned. Specify a comma-separated
        /// list of metric groups. For more information see 
        /// <a href="/en/docs/ads/analytics/overview/metrics-and-segmentation">Metrics and Segmentation</a>
        /// </summary>
        HashSet<MetricGroup> MetricGroups { get; set; }

        /// <summary>
        /// Scopes the retrieved data to a particular placement
        /// Only a single value accepted per request. For entities
        /// with both Twitter and Twitter Audience Platform placement, separate requests
        /// are required, one for each placement value
        /// </summary>
        Placement Placement { get; set; }

        /// <summary>
        /// The country. This is the targeting_value from the
        /// <a href="/en/docs/ads/campaign-management/api-reference/targeting-options#get-targeting-criteria-locations">GET targeting_criteria/locations</a>
        /// endpoint response
        /// Required if segmentation_type is either METROS, POSTAL_CODES, or REGIONS.
        /// </summary>
        string Country { get; set; }

        /// <summary>
        /// The platform type
        /// Required if segmentation_type is either DEVICES or PLATFORM_VERSIONS
        /// <a href="/en/docs/ads/campaign-management/api-reference/targeting-options#get-targeting-criteria-platforms">GET targeting_criteria/platforms</a>
        /// </summary>
        int? PlatformType { get; set; }

        /// <summary>
        /// Specify how the retrieved data should be segmented
        /// Segmentation not supported when requesting analytics for
        /// Media Creatives or organic Tweets.
        /// </summary>
        SegmentationType SegmentationType { get; set; }
    }

    public class CreateAsynchronousAnalyticsJobParameters : BaseAnalyticsParameters, ICreateAsynchronousAnalyticsJobParameters
    {
        public CreateAsynchronousAnalyticsJobParameters()
        {
            EntityIds = new HashSet<string>();
            MetricGroups = new HashSet<MetricGroup>();
        }

        public CreateAsynchronousAnalyticsJobParameters(ICreateAsynchronousAnalyticsJobParameters parameters) : base(parameters)
        {
            EntityIds = new HashSet<string>(parameters.EntityIds);
            MetricGroups = new HashSet<MetricGroup>(parameters.MetricGroups);
            Granularity = parameters.Granularity;
            Placement = parameters.Placement;
            Country = parameters.Country;
            PlatformType = parameters.PlatformType;
            SegmentationType = parameters.SegmentationType;
        }

        public HashSet<string> EntityIds { get; set; }
        public FlycatcherAds.Models.Granularity Granularity { get; set; }
        public HashSet<MetricGroup> MetricGroups { get; set; }
        public Placement Placement { get; set; }
        public string Country { get; set; }
        public int? PlatformType { get; set; }
        public SegmentationType SegmentationType { get; set; }
    }
}
