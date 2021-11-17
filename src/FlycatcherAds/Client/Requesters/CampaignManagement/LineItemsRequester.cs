using Tweetinvi;
using Tweetinvi.Client;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.Controllers;

namespace FlycatcherAds.Client
{
    public class LineItemsRequester : BaseRequester, ILineItemsRequester
    {
        private ILineItemsController _lineItemsController;

        public LineItemsRequester(
            ITwitterClient client,
            ITwitterClientEvents events,
            ILineItemsController LineItemsController) : base(client, events)
        {
            _lineItemsController = LineItemsController;
        }

        public ITwitterPageIterator<ITwitterResult<LineItemsResponse>, string> GetLineItemsIterator(IGetLineItemsParameters parameters)
        {
            var request = TwitterClient.CreateRequest();
            return _lineItemsController.GetLineItemsIterator(parameters, request);
        }
    }
}
