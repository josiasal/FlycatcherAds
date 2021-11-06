using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface ICampaignsRequester
    {
        ITwitterPageIterator<ITwitterResult<CampaignsResponse>, string> GetCampaignsIterator(IGetCampaignsParameters parameters);
    }
}
