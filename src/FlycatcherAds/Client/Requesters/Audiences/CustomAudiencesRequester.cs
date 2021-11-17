using Tweetinvi;

using Tweetinvi.Client;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Core.Events;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.Controllers;

namespace FlycatcherAds.Client
{
    public class CustomAudiencesRequester : BaseRequester, ICustomAudiencesRequester
    {
        private ICustomAudiencesController _customAudiencesController;

        public CustomAudiencesRequester(
            ITwitterClient client,
            ITwitterClientEvents events,
            ICustomAudiencesController customAudiencesController) : base(client, events)
        {
            _customAudiencesController = customAudiencesController;
        }

        public ITwitterPageIterator<ITwitterResult<CustomAudiencesResponse>, string> GetCustomAudiencesIterator(IGetCustomAudiencesParameters parameters)
        {
            var request = TwitterClient.CreateRequest();
            return _customAudiencesController.GetCustomAudiencesIterator(parameters, request);
        }
    }
}
