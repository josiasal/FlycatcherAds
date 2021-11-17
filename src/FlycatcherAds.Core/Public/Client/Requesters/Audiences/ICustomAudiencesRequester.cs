using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface ICustomAudiencesRequester
    {
        ITwitterPageIterator<ITwitterResult<CustomAudiencesResponse>, string> GetCustomAudiencesIterator(IGetCustomAudiencesParameters parameters);
    }
}
