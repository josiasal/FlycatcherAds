using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;


namespace FlycatcherAds.Core.Controllers
{
    public interface ICustomAudiencesController
    {
        ITwitterPageIterator<ITwitterResult<CustomAudiencesResponse>, string> GetCustomAudiencesIterator(IGetCustomAudiencesParameters parameters, ITwitterRequest request);
    }
}