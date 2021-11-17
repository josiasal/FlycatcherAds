using System;
using System.Threading.Tasks;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Core.Controllers;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Controllers
{
    public class AnalyticsController : IAnalyticsController
    {
        private readonly IAnalyticsQueryExecutor _queryExecutor;

        public AnalyticsController(IAnalyticsQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(
            IGetSynchronousAnalyticsParameters parameters, ITwitterRequest request)
        {
            return _queryExecutor.GetSynchronousAnalyticsAsync(parameters, request);
        }

        public ITwitterPageIterator<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>, string> GetAsynchronousAnalyticsJobsInfoIterator(IGetAsynchronousAnalyticsJobsParameters parameters, ITwitterRequest request)
        {
            return GetIterator(
                _queryExecutor.GetAsynchronousAnalyticsJobsInfoAsync,
                parameters,
                request
            );
        }

        public async Task<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>> GetAsynchronousAnalyticsJobsInfoAsync(IGetAsynchronousAnalyticsJobsParameters parameters, ITwitterRequest request)
        {
            return await _queryExecutor.GetAsynchronousAnalyticsJobsInfoAsync(parameters, request);
        }

        public async Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> CreateAsynchronousAnalyticsJobAsync(ICreateAsynchronousAnalyticsJobParameters parameters, ITwitterRequest request)
        {
            return await _queryExecutor.CreateAsynchronousAnalyticsJobAsync(parameters, request);
        }

        public async Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> DeleteAsynchronousAnalyticsJobAsync(IDeleteAsynchronousAnalyticsJobParameters parameters, ITwitterRequest request)
        {
            return await _queryExecutor.DeleteAsynchronousAnalyticsJobAsync(parameters, request);
        }

        public async Task<ITwitterResult<ActiveEntitiesResponse>> GetActiveEntitiesAsync(IGetActiveEntitiesParameters parameters, ITwitterRequest request)
        {
            return await _queryExecutor.GetActiveEntitiesAsync(parameters, request);
        }

        private ITwitterPageIterator<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>, string> GetIterator(
            Func<IGetAsynchronousAnalyticsJobsParameters, ITwitterRequest, Task<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>>> Method,
            IGetAsynchronousAnalyticsJobsParameters parameters,
            ITwitterRequest request)
        {
            Func<string, Task<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>>> getNext = nextCursor =>
            {
                var cursoredParameters = new GetAsynchronousAnalyticsJobsParameters(parameters)
                {
                    Cursor = nextCursor
                };

                return Method(cursoredParameters, request);
            };

            var twitterCursorResult = new TwitterPageIterator<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>, string>(
                parameters.Cursor,
                getNext,
                page =>
                {
                    if (page.Model.AsynchrounousAnalyticsJobs.Length == 0)
                    {
                        return null;
                    }

                    return page.Model.NextCursor;
                },
                page =>
                {
                    if (page.Model.AsynchrounousAnalyticsJobs.Length == 0)
                    {
                        return true;
                    }

                    return page.Model.NextCursor == null;
                });

            return twitterCursorResult;
        }
    }
}
