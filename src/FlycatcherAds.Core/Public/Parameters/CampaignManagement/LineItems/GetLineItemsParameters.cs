using System.Collections.Generic;

namespace FlycatcherAds.Parameters
{
    public interface IGetLineItemsParameters : IBaseAdsParameters
    {   
        /// <summary>
        /// The identifier for the leveraged account. Appears within the resource's
        /// path and is generally a required parameter for all Advertiser API requests
        /// excluding GET accounts.
        /// The specified account must be associated with the authenticated user.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// Scope the response to just the line items under specific campaigns by
        /// specifying a comma-separated list of identifiers. Up to 200 IDs may be provided.
        /// </summary>
        HashSet<string> CampaignIds { get; set; }

        /// <summary>
        /// Scope the response to just the Tweets associated with specific line items
        /// by specifying a comma-separated list of identifiers. Up to 200 IDs may
        /// be provided.
        /// </summary>
        HashSet<string> LineItemIds { get; set; }

        /// <summary>
        /// Scope the response to just the campaigns under specific funding
        /// instruments by specifying a comma-separated list of identifiers.
        /// Up to 200 IDs may be provided.
        /// </summary>
        HashSet<string> FundingInstrumentIds { get; set; }
        /// <summary>
        /// An optional query to scope resource by name.
        /// </summary>
        string Query { get; set; }

        /// <summary>
        /// Include draft campaigns results in your request.
        /// </summary>
        bool? WithDraft { get; set; }
    }

    public class GetLineItemsParameters : BaseAdsParameters, IGetLineItemsParameters
    {
        public GetLineItemsParameters()
        {
            CampaignIds = new HashSet<string>();
            LineItemIds = new HashSet<string>();
            FundingInstrumentIds = new HashSet<string>();
        }

        public GetLineItemsParameters(IGetLineItemsParameters parameters) : base(parameters)
        {
            AccountId = parameters.AccountId;
            CampaignIds = new HashSet<string>(parameters.CampaignIds);
            LineItemIds = new HashSet<string>(parameters.LineItemIds);
            FundingInstrumentIds = new HashSet<string>(parameters.FundingInstrumentIds);
            Query = parameters.Query;
            WithDraft = parameters.WithDraft;
        }

        public string AccountId { get; set; }
        public HashSet<string> CampaignIds { get; set; }
        public HashSet<string> LineItemIds { get; set; }
        public HashSet<string> FundingInstrumentIds { get; set; }
        public string Query { get; set; }
        public bool? WithDraft { get; set; }
    }
}