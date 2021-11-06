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
    public class PromotedTweetsRequester : BaseRequester, IPromotedTweetsRequester
    {
        private IPromotedTweetsController _promotedTweetsController;

        public PromotedTweetsRequester(
            ITwitterClient client,
            ITwitterClientEvents events,
            IPromotedTweetsController promotedTweetsController) : base(client, events)
        {
            _promotedTweetsController = promotedTweetsController;
        }

        public ITwitterPageIterator<ITwitterResult<PromotedTweetsResponse>, string> GetPromotedTweetsIterator(IGetPromotedTweetsParameters parameters)
        {
            var request = TwitterClient.CreateRequest();
            return _promotedTweetsController.GetPromotedTweetsIterator(parameters, request);
        }
    }
}
