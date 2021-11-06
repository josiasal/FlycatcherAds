using System.Threading.Tasks;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface ISynchronousAnalyticsClient
    {
        /// <summary>
        /// Retrieve synchronous analytics for the current account.
        /// A maximum time range (end_time - start_time) of 7 days is allowed.
        /// </summary>
        Task<SynchronousAnalyticsResponse> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters);
    }
}
