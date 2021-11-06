using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;


namespace FlycatcherAds.Core.Controllers
{
    public interface IAdsAccountsController
    {
        ITwitterPageIterator<ITwitterResult<AdsAccountsResponse>, string> GetAdsAccountIterator(IGetAdsAccountsParameters parameters, ITwitterRequest request);
    }
}