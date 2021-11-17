using System;
using System.Collections.Generic;

using Tweetinvi.Parameters;
using FlycatcherAds.Models;

namespace FlycatcherAds.Parameters
{
    public interface IGetAsynchronousAnalyticsJobsParameters : ICustomRequestParameters
    {   
        /// <summary>
        /// The identifier for the leveraged account. Appears within the resource's
        /// path and is generally a required parameter for all Advertiser API requests
        /// excluding GET accounts.
        /// The specified account must be associated with the authenticated user.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// Specifies the number of records to try and retrieve per distinct request.
        /// </summary>
        int? Count { get; set; }

        /// <summary>
        /// Specifies a cursor to get the next page of results. See
        /// <a href="https://developer.twitter.com/en/docs/ads/general/guides/pagination">Pagination</a>
        /// for more information.
        /// </summary>
        string Cursor { get; set; }

        /// <summary>
        /// Scope the response to just the desired jobs by specifying a comma-separated
        /// list of identifiers. Up to 200 IDs may be provided.
        /// </summary>
        HashSet<string> JobIds { get; set; }
    }

    public class GetAsynchronousAnalyticsJobsParameters : CustomRequestParameters, IGetAsynchronousAnalyticsJobsParameters
    {
        public GetAsynchronousAnalyticsJobsParameters()
        {
            JobIds = new HashSet<string>();
        }

        public GetAsynchronousAnalyticsJobsParameters(IGetAsynchronousAnalyticsJobsParameters parameters) : base(parameters)
        {
            AccountId = parameters.AccountId;
            Count = parameters.Count;
            Cursor = parameters.Cursor;
            JobIds = new HashSet<string>(parameters.JobIds);
        }

        public string AccountId { get; set; }
        public int? Count { get; set; }
        public string Cursor { get; set; }
        public HashSet<string> JobIds { get; set; }
    }
}
