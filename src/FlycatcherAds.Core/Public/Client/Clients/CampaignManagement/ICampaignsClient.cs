using Tweetinvi.Iterators;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface ICampaignsClient
    {
        /// <summary>
        /// Retrieve details for some or all campaigns associated with the current account.
        /// </summary>
        ITwitterRequestIterator<CampaignsResponse, string> GetCampaignsIterator(IGetCampaignsParameters parameters);
    }
}