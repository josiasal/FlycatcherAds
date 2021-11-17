using System.Threading.Tasks;

using Tweetinvi.Iterators;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface IAnalyticsClient
    {
        /// <summary>
        /// Retrieve synchronous analytics for the current account.
        /// A maximum time range (end_time - start_time) of 7 days is allowed.
        /// </summary>
        Task<SynchronousAnalyticsResponse> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters);

        /// <summary>
        /// Retrieve details for some or all asynchronous analytics jobs for the current account.
        /// </summary>
        ITwitterRequestIterator<AsynchronousAnalyticsJobsInfoResponse, string> GetAsynchronousAnalyticsJobsInfoIterator(IGetAsynchronousAnalyticsJobsParameters parameters);

        /// <summary>
        /// Retrieve details for some analytics jobs for the current account.
        /// </summary>
        Task<AsynchronousAnalyticsJobsInfoResponse> GetAsynchronousAnalyticsJobsInfoAsync(IGetAsynchronousAnalyticsJobsParameters parameters);

        /// <summary>
        /// Create an asynchronous analytics job for the current account.
        /// A maximum time range (end_time - start_time) of 90 days is allowed for non-segmented queries.
        /// For segmented queries, the maximum time range is 45 days.
        /// </summary>
        Task<AsynchronousAnalyticsJobInfoResponse> CreateAsynchronousAnalyticsJobAsync(ICreateAsynchronousAnalyticsJobParameters parameters);

        /// <summary>
        /// Cancel an asynchronous analytics job for a given ads account.
        /// </summary>
        Task<AsynchronousAnalyticsJobInfoResponse> DeleteAsynchronousAnalyticsJobAsync(IDeleteAsynchronousAnalyticsJobParameters parameters);

        /// <summary>
        /// Retrieve details about which entities' analytics metrics have changed in a given time period.
        /// </summary>
        Task<ActiveEntitiesResponse> GetActiveEntitiesAsync(IGetActiveEntitiesParameters parameters);
    }
}
