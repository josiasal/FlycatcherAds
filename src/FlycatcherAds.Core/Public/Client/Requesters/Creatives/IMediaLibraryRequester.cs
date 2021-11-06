using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface IMediaLibraryRequester
    {
        ITwitterPageIterator<ITwitterResult<MediaLibraryResponse>, string> GetMediaLibraryIterator(IGetMediaLibraryParameters parameters);
    }
}
