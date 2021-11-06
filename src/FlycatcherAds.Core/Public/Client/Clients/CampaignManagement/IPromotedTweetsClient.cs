using Tweetinvi.Iterators;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface IPromotedTweetsClient
    {
        /// <summary>
        /// Retrieve references to Tweets associated with line items under the current account.
        /// </summary>
        ITwitterRequestIterator<PromotedTweetsResponse, string> GetPromotedTweetsIterator(IGetPromotedTweetsParameters parameters);
    }
}
