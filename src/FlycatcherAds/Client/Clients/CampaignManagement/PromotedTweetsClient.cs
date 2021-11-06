using Tweetinvi.Iterators;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public class PromotedTweetsClient : IPromotedTweetsClient
    {
        private readonly IPromotedTweetsRequester _campaignsRequester;

        public PromotedTweetsClient(IPromotedTweetsRequester campaignsRequester)
        {
            _campaignsRequester = campaignsRequester;
        }
        
        public ITwitterRequestIterator<PromotedTweetsResponse, string> GetPromotedTweetsIterator(IGetPromotedTweetsParameters parameters)
        {
            var iterator = _campaignsRequester.GetPromotedTweetsIterator(parameters);
            return new IteratorPageProxy<ITwitterResult<PromotedTweetsResponse>, PromotedTweetsResponse, string>(iterator, input => input.Model);
        }
    }
}
