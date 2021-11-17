using Tweetinvi.Iterators;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public class CustomAudiencesClient : ICustomAudiencesClient
    {
        private readonly ICustomAudiencesRequester _customAudiencesRequester;

        public CustomAudiencesClient(ICustomAudiencesRequester customAudiencesRequester)
        {
            _customAudiencesRequester = customAudiencesRequester;
        }

        public ITwitterRequestIterator<CustomAudiencesResponse, string> GetCustomAudiencesIterator(IGetCustomAudiencesParameters parameters)
        {
            var iterator = _customAudiencesRequester.GetCustomAudiencesIterator(parameters);
            return new IteratorPageProxy<ITwitterResult<CustomAudiencesResponse>, CustomAudiencesResponse, string>(iterator, input => input.Model);
        }
    }
}
