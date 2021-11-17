using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;


namespace FlycatcherAds.Core.Controllers
{
    public interface ILineItemsController
    {
        ITwitterPageIterator<ITwitterResult<LineItemsResponse>, string> GetLineItemsIterator(IGetLineItemsParameters parameters, ITwitterRequest request);
    }
}