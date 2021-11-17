using System.Threading.Tasks;
using Tweetinvi.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Core.Iterators;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public class AnalyticsClient : IAnalyticsClient
    {
        private readonly IAnalyticsRequester _analyticsRequester;

        public AnalyticsClient(IAnalyticsRequester analyticsRequester)
        {
            _analyticsRequester = analyticsRequester;
        }

        public async Task<SynchronousAnalyticsResponse> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters)
        {
            var response = await _analyticsRequester.GetSynchronousAnalyticsAsync(parameters).ConfigureAwait(false);
            return response?.Model;
        }

        public ITwitterRequestIterator<AsynchronousAnalyticsJobsInfoResponse, string> GetAsynchronousAnalyticsJobsInfoIterator(IGetAsynchronousAnalyticsJobsParameters parameters)
        {
            var iterator = _analyticsRequester.GetAsynchronousAnalyticsJobsInfoIterator(parameters);
            return new IteratorPageProxy<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>, AsynchronousAnalyticsJobsInfoResponse, string>(iterator, input => input.Model);
        }

        public async Task<AsynchronousAnalyticsJobsInfoResponse> GetAsynchronousAnalyticsJobsInfoAsync(IGetAsynchronousAnalyticsJobsParameters parameters)
        {
            var response = await _analyticsRequester.GetAsynchronousAnalyticsJobsInfoAsync(parameters).ConfigureAwait(false);
            return response?.Model;
        }

        public async Task<AsynchronousAnalyticsJobInfoResponse> CreateAsynchronousAnalyticsJobAsync(ICreateAsynchronousAnalyticsJobParameters parameters)
        {
            var response = await _analyticsRequester.CreateAsynchronousAnalyticsJob(parameters).ConfigureAwait(false);
            return response?.Model;
        }

        public async Task<AsynchronousAnalyticsJobInfoResponse> DeleteAsynchronousAnalyticsJobAsync(IDeleteAsynchronousAnalyticsJobParameters parameters)
        {
            var response = await _analyticsRequester.DeleteAsynchronousAnalyticsJob(parameters).ConfigureAwait(false);
            return response?.Model;
        }

        public async Task<ActiveEntitiesResponse> GetActiveEntitiesAsync(IGetActiveEntitiesParameters parameters)
        {
            var response = await _analyticsRequester.GetActiveEntitiesAsync(parameters).ConfigureAwait(false);
            return response?.Model;
        }
    }
}
