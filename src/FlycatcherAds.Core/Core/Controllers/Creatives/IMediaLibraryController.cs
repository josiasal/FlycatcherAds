using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;


namespace FlycatcherAds.Core.Controllers
{
    public interface IMediaLibraryController
    {
        ITwitterPageIterator<ITwitterResult<MediaLibraryResponse>, string> GetMediaLibraryIterator(IGetMediaLibraryParameters parameters, ITwitterRequest request);
    }
}