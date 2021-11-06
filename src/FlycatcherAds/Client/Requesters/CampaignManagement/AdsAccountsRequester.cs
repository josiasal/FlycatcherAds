using Tweetinvi;

using Tweetinvi.Client;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Core.Events;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.Controllers;

namespace FlycatcherAds.Client
{
    public class AdsAccountsRequester : BaseRequester, IAdsAccountsRequester
    {
        private IAdsAccountsController _adsAccountsController;

        public AdsAccountsRequester(
            ITwitterClient client,
            ITwitterClientEvents events,
            IAdsAccountsController adsAccountsController) : base(client, events)
        {
            _adsAccountsController = adsAccountsController;
        }

        public ITwitterPageIterator<ITwitterResult<AdsAccountsResponse>, string> GetAccountsIterator(IGetAdsAccountsParameters parameters)
        {
            var request = TwitterClient.CreateRequest();
            return _adsAccountsController.GetAdsAccountIterator(parameters, request);
        }
    }
}
