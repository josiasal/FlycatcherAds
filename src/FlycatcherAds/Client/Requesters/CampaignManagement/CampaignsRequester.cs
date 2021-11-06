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
    public class CampaignsRequester : BaseRequester, ICampaignsRequester
    {
        private ICampaignsController _adsAccountsController;

        public CampaignsRequester(
            ITwitterClient client,
            ITwitterClientEvents events,
            ICampaignsController adsAccountsController) : base(client, events)
        {
            _adsAccountsController = adsAccountsController;
        }

        public ITwitterPageIterator<ITwitterResult<CampaignsResponse>, string> GetCampaignsIterator(IGetCampaignsParameters parameters)
        {
            var request = TwitterClient.CreateRequest();
            return _adsAccountsController.GetCampaignsIterator(parameters, request);
        }
    }
}
