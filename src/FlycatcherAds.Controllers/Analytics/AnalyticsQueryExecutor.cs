using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;

namespace FlycatcherAds.Controllers
{
    public interface IAnalyticsQueryExecutor
    {
        Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters, ITwitterRequest request);

        Task<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>> GetAsynchronousAnalyticsJobsInfoAsync(IGetAsynchronousAnalyticsJobsParameters parameters, ITwitterRequest request);

        Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> CreateAsynchronousAnalyticsJobAsync(ICreateAsynchronousAnalyticsJobParameters parameters, ITwitterRequest request);

        Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> DeleteAsynchronousAnalyticsJobAsync(IDeleteAsynchronousAnalyticsJobParameters parameters, ITwitterRequest request);

        Task<ITwitterResult<ActiveEntitiesResponse>> GetActiveEntitiesAsync(IGetActiveEntitiesParameters parameters, ITwitterRequest request);
    }

    public class AnalyticsQueryExecutor : IAnalyticsQueryExecutor
    {
        private readonly JsonContentFactory _jsonContentFactory;
        private readonly IAnalyticsQueryGenerator _queryGenerator;
        private readonly ITwitterAccessor _twitterAccessor;

        public AnalyticsQueryExecutor(
            JsonContentFactory jsonContentFactory,
            IAnalyticsQueryGenerator queryGenerator,
            ITwitterAccessor twitterAccessor)
        {
            _jsonContentFactory = jsonContentFactory;
            _queryGenerator = queryGenerator;
            _twitterAccessor = twitterAccessor;
        }

        public Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _queryGenerator.GetSynchronousAnalyticsQuery(parameters);
            request.Query.HttpMethod = HttpMethod.GET;
            return _twitterAccessor.ExecuteRequestAsync<SynchronousAnalyticsResponse>(request);
        }

        public async Task<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>> GetAsynchronousAnalyticsJobsInfoAsync(IGetAsynchronousAnalyticsJobsParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _queryGenerator.GetAsynchronousAnalyticsJobsInfoQuery(parameters);
            request.Query.HttpMethod = HttpMethod.GET;
            return await _twitterAccessor.ExecuteRequestAsync<AsynchronousAnalyticsJobsInfoResponse>(request);
        }

        public async Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> CreateAsynchronousAnalyticsJobAsync(ICreateAsynchronousAnalyticsJobParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _queryGenerator.CreateAsynchronousAnalyticsJobQuery(parameters);
            request.Query.HttpMethod = HttpMethod.POST;
            return await _twitterAccessor.ExecuteRequestAsync<AsynchronousAnalyticsJobInfoResponse>(request);
        }

        public async Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> DeleteAsynchronousAnalyticsJobAsync(IDeleteAsynchronousAnalyticsJobParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _queryGenerator.DeleteAsynchronousAnalyticsJobQuery(parameters);
            request.Query.HttpMethod = HttpMethod.DELETE;
            return await _twitterAccessor.ExecuteRequestAsync<AsynchronousAnalyticsJobInfoResponse>(request);
        }

        public async Task<ITwitterResult<ActiveEntitiesResponse>> GetActiveEntitiesAsync(IGetActiveEntitiesParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _queryGenerator.GetActiveEntitiesQuery(parameters);
            request.Query.HttpMethod = HttpMethod.GET;
            return await _twitterAccessor.ExecuteRequestAsync<ActiveEntitiesResponse>(request);
        }
    }
}
