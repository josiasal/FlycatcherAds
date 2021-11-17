using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface ILineItemsRequester
    {
        ITwitterPageIterator<ITwitterResult<LineItemsResponse>, string> GetLineItemsIterator(IGetLineItemsParameters parameters);
    }
}
