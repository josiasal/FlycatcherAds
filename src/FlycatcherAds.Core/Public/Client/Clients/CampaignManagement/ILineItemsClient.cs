using Tweetinvi.Iterators;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface ILineItemsClient
    {
        /// <summary>
        /// Retrieve details for some or all line items associated with the current account.
        /// </summary>
        ITwitterRequestIterator<LineItemsResponse, string> GetLineItemsIterator(IGetLineItemsParameters parameters);
    }
}
