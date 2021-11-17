using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Core.Iterators;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface IAnalyticsRequester
    {
        Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters);

        ITwitterPageIterator<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>, string> GetAsynchronousAnalyticsJobsInfoIterator(IGetAsynchronousAnalyticsJobsParameters parameters);

        Task<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>> GetAsynchronousAnalyticsJobsInfoAsync(IGetAsynchronousAnalyticsJobsParameters parameters);

        Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> CreateAsynchronousAnalyticsJob(ICreateAsynchronousAnalyticsJobParameters parameters);

        Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> DeleteAsynchronousAnalyticsJob(IDeleteAsynchronousAnalyticsJobParameters parameters);

        Task<ITwitterResult<ActiveEntitiesResponse>> GetActiveEntitiesAsync(IGetActiveEntitiesParameters parameters);
    }
}
