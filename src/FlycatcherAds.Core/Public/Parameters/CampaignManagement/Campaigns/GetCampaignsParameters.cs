using System.Collections.Generic;

namespace FlycatcherAds.Parameters
{
    public interface IGetCampaignsParameters : IBaseAdsParameters
    {
        /// <summary>
        /// The identifier for the leveraged account. Appears within the
        /// resource's path and is generally a required parameter for all
        /// Advertiser API requests excluding GET accounts. The specified 
        /// account must be associated with the authenticated user.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// An optional query to scope resource by name.
        /// </summary>
        string Query { get; set; }

        /// <summary>
        /// Include draft campaigns results in your request.
        /// </summary>
        bool? WithDraft { get; set; }

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
    }

    public class GetCampaignsParameters : BaseAdsParameters, IGetCampaignsParameters
    {
        public GetCampaignsParameters()
        {
            CampaignIds = new HashSet<string>();
            FundingInstrumentIds = new HashSet<string>();
        }

        public GetCampaignsParameters(IGetCampaignsParameters parameters) : base(parameters)
        {
            AccountId = parameters.AccountId;
            Query = parameters.Query;
            WithDraft = parameters.WithDraft;
            CampaignIds = new HashSet<string>(parameters.CampaignIds);
            FundingInstrumentIds = new HashSet<string>(parameters.FundingInstrumentIds);
        }

        public string AccountId { get; set; }
        public string Query { get; set; }
        public bool? WithDraft { get; set; }
        public HashSet<string> CampaignIds { get; set; }
        public HashSet<string> FundingInstrumentIds { get; set; }
    }
}
