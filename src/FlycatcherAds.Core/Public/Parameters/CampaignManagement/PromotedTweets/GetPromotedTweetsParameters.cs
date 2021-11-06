using System.Collections.Generic;

namespace FlycatcherAds.Parameters
{
    public interface IGetPromotedTweetsParameters : IBaseAdsParameters
    {   
        /// <summary>
        /// The identifier for the leveraged account. Appears within the resource's
        /// path and is generally a required parameter for all Advertiser API requests
        /// excluding GET accounts.
        /// The specified account must be associated with the authenticated user.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// Scope the response to just the Tweets associated with specific line items
        /// by specifying a comma-separated list of identifiers. Up to 200 IDs may
        /// be provided.
        /// </summary>
        HashSet<string> LineItemIds { get; set; }

        /// <summary>
        /// Scope the response to just the desired promoted Tweets by specifying a
        /// comma-separated list of identifiers. Up to 200 IDs may be provided.
        /// </summary>
        HashSet<string> PromotedTweetIds { get; set; }
    }

    public class GetPromotedTweetsParameters : BaseAdsParameters, IGetPromotedTweetsParameters
    {
        public GetPromotedTweetsParameters()
        {
            LineItemIds = new HashSet<string>();
            PromotedTweetIds = new HashSet<string>();
        }

        public GetPromotedTweetsParameters(IGetPromotedTweetsParameters parameters) : base(parameters)
        {
            AccountId = parameters.AccountId;
            LineItemIds = new HashSet<string>(parameters.LineItemIds);
            PromotedTweetIds = new HashSet<string>(parameters.PromotedTweetIds);
        }

        public string AccountId { get; set; }

        public HashSet<string> LineItemIds { get; set; }

        public HashSet<string> PromotedTweetIds { get; set; }
    }
}