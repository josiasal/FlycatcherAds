using Tweetinvi.Iterators;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public class AdsAccountsClient : IAdsAccountsClient
    {
        private readonly IAdsAccountsRequester _adsAccountsRequester;
        public AdsAccountsClient(IAdsAccountsRequester adsAccountsRequester)
        {
            _adsAccountsRequester = adsAccountsRequester;
        }
        public ITwitterRequestIterator<AdsAccountsResponse, string> GetAccountsIterator(IGetAdsAccountsParameters parameters)
        {
            var iterator = _adsAccountsRequester.GetAccountsIterator(parameters);
            return new IteratorPageProxy<ITwitterResult<AdsAccountsResponse>, AdsAccountsResponse, string>(iterator, input => input.Model);
        }
    }
}
