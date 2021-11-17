using System;
using System.Collections.Generic;

using Tweetinvi.Parameters;

using FlycatcherAds.Models;

namespace FlycatcherAds.Parameters
{
    public interface IBaseAnalyticsParameters : ICustomRequestParameters
    {
        /// <summary>
        /// The identifier for the leveraged account. Appears within the resource's 
        /// path and is generally a required parameter for all Advertiser API requests excluding
        /// <a href="/en/docs/ads/campaign-management/api-reference/accounts#get-accounts">GET accounts</a>.
        /// The specified account must be associated with the authenticated user
        /// </summary>
        string AccountId { get; set; }
    
        /// Scopes the retrieved data to the specified start time, expressed in
        ///<a href="https://en.wikipedia.org/wiki/ISO_8601">ISO 8601</a>
        /// Must be expressed in whole hours (0 minutes and 0 seconds)
        DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Scopes the retrieved data to the specified end time, expressed in
        /// <a href="https://en.wikipedia.org/wiki/ISO_8601">ISO 8601</a>
        /// </summary>
        DateTimeOffset EndTime { get; set; }

        /// <summary>
        /// The entity type to retrieve data for.
        /// Possible values: 
        ///     ACCOUNT, CAMPAIGN, FUNDING_INSTRUMENT, LINE_ITEM, ORGANIC_TWEET,
        ///     PROMOTED_ACCOUNT, PROMOTED_TWEET, MEDIA_CREATIVE
        /// </summary>
        EntityType EntityType { get; set; }
    }

    public class BaseAnalyticsParameters : CustomRequestParameters, IBaseAnalyticsParameters
    {
        public BaseAnalyticsParameters()
        {
        }

        public BaseAnalyticsParameters(IBaseAnalyticsParameters parameters) : base(parameters)
        {
            AccountId = parameters.AccountId;
            StartTime = parameters.StartTime;
            EndTime = parameters.EndTime;
            EntityType = parameters.EntityType;
        }

        public string AccountId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public EntityType EntityType { get; set; }
    }
}
