using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Models;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Core.Controllers
{
    public interface IAnalyticsController
    {
        Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters, ITwitterRequest request);

        ITwitterPageIterator<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>, string> GetAsynchronousAnalyticsJobsInfoIterator(IGetAsynchronousAnalyticsJobsParameters parameters, ITwitterRequest request);

        Task<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>> GetAsynchronousAnalyticsJobsInfoAsync(IGetAsynchronousAnalyticsJobsParameters parameters, ITwitterRequest request);

        Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> CreateAsynchronousAnalyticsJobAsync(ICreateAsynchronousAnalyticsJobParameters parameters, ITwitterRequest request);

        Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> DeleteAsynchronousAnalyticsJobAsync(IDeleteAsynchronousAnalyticsJobParameters parameters, ITwitterRequest request);

        Task<ITwitterResult<ActiveEntitiesResponse>> GetActiveEntitiesAsync(IGetActiveEntitiesParameters parameters, ITwitterRequest request);
    }
}