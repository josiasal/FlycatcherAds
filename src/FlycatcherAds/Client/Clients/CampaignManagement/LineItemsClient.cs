using Tweetinvi.Iterators;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public class LineItemsClient : ILineItemsClient
    {
        private readonly ILineItemsRequester _campaignsRequester;

        public LineItemsClient(ILineItemsRequester campaignsRequester)
        {
            _campaignsRequester = campaignsRequester;
        }

        public ITwitterRequestIterator<LineItemsResponse, string> GetLineItemsIterator(IGetLineItemsParameters parameters)
        {
            var iterator = _campaignsRequester.GetLineItemsIterator(parameters);
            return new IteratorPageProxy<ITwitterResult<LineItemsResponse>, LineItemsResponse, string>(iterator, input => input.Model);
        }
    }
}
