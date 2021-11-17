using System;
using System.Collections.Generic;
using Tweetinvi.Parameters;

namespace FlycatcherAds.Parameters
{
    public interface IGetActiveEntitiesParameters : IBaseAnalyticsParameters
    {
        /// <summary>
        /// Scope the response to just the desired campaigns by specifying a
        /// comma-separated list of identifiers. Up to 200 IDs may be provided.
        /// </summary>
        HashSet<string> CampaignIds { get; set; }

        /// <summary>
        /// Scope the response to just the campaigns under specific funding
        /// instruments by specifying a comma-separated list of identifiers.
        /// Up to 200 IDs may be provided.
        /// </summary>
        HashSet<string> FundingInstrumentIds { get; set; }

        /// <summary>
        /// Scope the response to just the Tweets associated with specific line items
        /// by specifying a comma-separated list of identifiers. Up to 200 IDs may
        /// be provided.
        /// </summary>
        HashSet<string> LineItemIds { get; set; }
    }

    public class GetActiveEntitiesParameters : BaseAnalyticsParameters, IGetActiveEntitiesParameters
    {
        public GetActiveEntitiesParameters()
        {
            CampaignIds = new HashSet<string>();
            FundingInstrumentIds = new HashSet<string>();
            LineItemIds = new HashSet<string>();
        }

        public GetActiveEntitiesParameters(IGetActiveEntitiesParameters parameters) : base(parameters)
        {
            CampaignIds = new HashSet<string>(parameters.CampaignIds);
            FundingInstrumentIds = new HashSet<string>(parameters.FundingInstrumentIds);
            LineItemIds = new HashSet<string>(parameters.LineItemIds);
        }

        public HashSet<string> CampaignIds { get; set; }
        public HashSet<string> FundingInstrumentIds { get; set; }
        public HashSet<string> LineItemIds { get; set; }
    }
}