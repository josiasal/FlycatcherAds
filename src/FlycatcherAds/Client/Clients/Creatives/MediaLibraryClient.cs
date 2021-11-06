using Tweetinvi.Iterators;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public class MediaLibraryClient : IMediaLibraryClient
    {
        private readonly IMediaLibraryRequester _campaignsRequester;

        public MediaLibraryClient(IMediaLibraryRequester campaignsRequester)
        {
            _campaignsRequester = campaignsRequester;
        }
        
        public ITwitterRequestIterator<MediaLibraryResponse, string> GetMediaLibraryIterator(IGetMediaLibraryParameters parameters)
        {
            var iterator = _campaignsRequester.GetMediaLibraryIterator(parameters);
            return new IteratorPageProxy<ITwitterResult<MediaLibraryResponse>, MediaLibraryResponse, string>(iterator, input => input.Model);
        }
    }
}
