using Tweetinvi.Iterators;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface IMediaLibraryClient
    {
        /// <summary>
        /// Retrieve details for some or all MediaLibrary associated with the current account.
        /// </summary>
        ITwitterRequestIterator<MediaLibraryResponse, string> GetMediaLibraryIterator(IGetMediaLibraryParameters parameters);
    }
}