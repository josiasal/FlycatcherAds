using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;


namespace FlycatcherAds.Core.Controllers
{
    public interface IPromotedTweetsController
    {
        ITwitterPageIterator<ITwitterResult<PromotedTweetsResponse>, string> GetPromotedTweetsIterator(IGetPromotedTweetsParameters parameters, ITwitterRequest request);
    }
}