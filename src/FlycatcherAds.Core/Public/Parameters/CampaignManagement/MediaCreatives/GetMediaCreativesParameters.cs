using System.Collections.Generic;

namespace FlycatcherAds.Parameters
{
    public interface IGetMediaCreativesParameters : IBaseAdsParameters
    {
        /// <summary>
        /// The identifier for the leveraged account. Appears within the resource's
        /// path and is generally a required parameter for all Advertiser API requests
        /// excluding GET accounts.
        /// The specified account must be associated with the authenticated user.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// Scope the response to just the media creatives associated with the
        /// specified campaign.
        /// </summary>
        string CampaignId { get; set; }

        /// <summary>
        /// Scope the response to just the Tweets associated with specific line items
        /// by specifying a comma-separated list of identifiers. Up to 200 IDs may
        /// be provided.
        /// </summary>
        HashSet<string> LineItemIds { get; set; }

        /// <summary>
        /// Scope the response to just the desired media creatives by specifying a
        /// comma-separated list of identifiers. Up to 200 IDs may be provided.
        /// </summary>
        HashSet<string> MediaCreativeIds { get; set; }
    }

    public class GetMediaCreativesParameters : BaseAdsParameters, IGetMediaCreativesParameters
    {
        public GetMediaCreativesParameters()
        {
            LineItemIds = new HashSet<string>();
            MediaCreativeIds = new HashSet<string>();
        }

        public string AccountId { get; set; }

        public string CampaignId { get; set; }

        public HashSet<string> LineItemIds { get; set; }

        public HashSet<string> MediaCreativeIds { get; set; }
    }
}
