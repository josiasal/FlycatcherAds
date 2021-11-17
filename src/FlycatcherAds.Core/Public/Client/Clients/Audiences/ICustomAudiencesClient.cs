using Tweetinvi.Iterators;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface ICustomAudiencesClient
    {
        /// <summary>
        /// Retrieve details for some or all advertising-enabled accounts
        /// the authenticating user has access to.
        /// </summary>
        ITwitterRequestIterator<CustomAudiencesResponse, string> GetCustomAudiencesIterator(IGetCustomAudiencesParameters parameters);
    }
}
