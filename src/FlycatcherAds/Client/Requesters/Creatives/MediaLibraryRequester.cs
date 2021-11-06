using Tweetinvi;
using Tweetinvi.Client;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.Controllers;

namespace FlycatcherAds.Client
{
    public class MediaLibraryRequester : BaseRequester, IMediaLibraryRequester
    {
        private IMediaLibraryController _mediaLibraryController;

        public MediaLibraryRequester(
            ITwitterClient client,
            ITwitterClientEvents events,
            IMediaLibraryController MediaLibraryController) : base(client, events)
        {
            _mediaLibraryController = MediaLibraryController;
        }

        public ITwitterPageIterator<ITwitterResult<MediaLibraryResponse>, string> GetMediaLibraryIterator(IGetMediaLibraryParameters parameters)
        {
            var request = TwitterClient.CreateRequest();
            return _mediaLibraryController.GetMediaLibraryIterator(parameters, request);
        }
    }
}
