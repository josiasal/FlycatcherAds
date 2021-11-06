using Tweetinvi.Iterators;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface IAdsAccountsClient
    {
        /// <summary>
        /// Retrieve details for some or all advertising-enabled accounts the authenticating user has access to.
        /// </summary>
        ITwitterRequestIterator<AdsAccountsResponse, string> GetAccountsIterator(IGetAdsAccountsParameters parameters);
    }
}
