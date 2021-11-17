
namespace FlycatcherAds.Parameters
{
    public interface IGetAdsAccountParameters
    {
        /// <summary>
        /// The identifier for the leveraged account. Appears within the 
        /// resource's path and is generally a required parameter for all 
        /// Advertiser API requests excluding GET accounts.
        ///
        /// The specified account must be associated with the authenticated user.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// Include deleted results in your request.
        /// </summary>
        string WithDeleted { get; set; }
    }

    public class GetAdsAccountParameters : IGetAdsAccountParameters
    {
        public string AccountId { get; set; }
        public string WithDeleted { get; set; }
    }
}
