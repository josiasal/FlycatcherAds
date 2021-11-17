using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Client;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Web;
using Tweetinvi.Core.Iterators;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.Controllers;

namespace FlycatcherAds.Client
{
    public class AnalyticsRequester : BaseRequester, IAnalyticsRequester
    {
        private IAnalyticsController _controller;

        public AnalyticsRequester(
            ITwitterClient client,
            ITwitterClientEvents events,
            IAnalyticsController controller) : base(client, events)
        {
            _controller = controller;
        }

        public async Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters)
        {
            return await ExecuteRequestAsync(request => _controller.GetSynchronousAnalyticsAsync(parameters, request));
        }

        public ITwitterPageIterator<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>, string> GetAsynchronousAnalyticsJobsInfoIterator(IGetAsynchronousAnalyticsJobsParameters parameters)
        {
            var request = TwitterClient.CreateRequest();
            return _controller.GetAsynchronousAnalyticsJobsInfoIterator(parameters, request);
        }

        public async Task<ITwitterResult<AsynchronousAnalyticsJobsInfoResponse>> GetAsynchronousAnalyticsJobsInfoAsync(IGetAsynchronousAnalyticsJobsParameters parameters)
        {
            return await ExecuteRequestAsync(request => _controller.GetAsynchronousAnalyticsJobsInfoAsync(parameters, request));
        }

        public async Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> CreateAsynchronousAnalyticsJob(ICreateAsynchronousAnalyticsJobParameters parameters)
        {
            return await ExecuteRequestAsync(request => _controller.CreateAsynchronousAnalyticsJobAsync(parameters, request));
        }

        public async Task<ITwitterResult<AsynchronousAnalyticsJobInfoResponse>> DeleteAsynchronousAnalyticsJob(IDeleteAsynchronousAnalyticsJobParameters parameters)
        {
            return await ExecuteRequestAsync(request => _controller.DeleteAsynchronousAnalyticsJobAsync(parameters, request));
        }

        public async Task<ITwitterResult<ActiveEntitiesResponse>> GetActiveEntitiesAsync(IGetActiveEntitiesParameters parameters)
        {
            return await ExecuteRequestAsync(request => _controller.GetActiveEntitiesAsync(parameters, request));
        }
    }
}
