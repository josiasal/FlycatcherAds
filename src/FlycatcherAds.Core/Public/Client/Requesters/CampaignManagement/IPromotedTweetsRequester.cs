using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface IPromotedTweetsRequester
    {
        ITwitterPageIterator<ITwitterResult<PromotedTweetsResponse>, string> GetPromotedTweetsIterator(IGetPromotedTweetsParameters parameters);
    }
}
