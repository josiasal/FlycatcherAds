using Tweetinvi.Iterators;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public class CampaignsClient : ICampaignsClient
    {
        private readonly ICampaignsRequester _campaignsRequester;

        public CampaignsClient(ICampaignsRequester campaignsRequester)
        {
            _campaignsRequester = campaignsRequester;
        }
        
        public ITwitterRequestIterator<CampaignsResponse, string> GetCampaignsIterator(IGetCampaignsParameters parameters)
        {
            var iterator = _campaignsRequester.GetCampaignsIterator(parameters);
            return new IteratorPageProxy<ITwitterResult<CampaignsResponse>, CampaignsResponse, string>(iterator, input => input.Model);
        }
    }
}
