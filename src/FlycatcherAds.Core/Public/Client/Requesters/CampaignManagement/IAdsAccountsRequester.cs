using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface IAdsAccountsRequester
    {
        ITwitterPageIterator<ITwitterResult<AdsAccountsResponse>, string> GetAccountsIterator(IGetAdsAccountsParameters parameters);
    }
}
