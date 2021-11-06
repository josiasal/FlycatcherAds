using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;


namespace FlycatcherAds.Core.Controllers
{
    public interface ICampaignsController
    {
        ITwitterPageIterator<ITwitterResult<CampaignsResponse>, string> GetCampaignsIterator(IGetCampaignsParameters parameters, ITwitterRequest request);
    }
}