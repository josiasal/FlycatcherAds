using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Client;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.Controllers;

namespace FlycatcherAds.Client
{
    public class SynchronousAnalyticsRequester : BaseRequester, ISynchronousAnalyticsRequester
    {
        private ISynchronousAnalyticsController _synchronousAnalyticsController;

        public SynchronousAnalyticsRequester(
            ITwitterClient client,
            ITwitterClientEvents events,
            ISynchronousAnalyticsController synchronousAnalyticsController) : base(client, events)
        {
            _synchronousAnalyticsController = synchronousAnalyticsController;
        }

        public Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters)
        {
            return ExecuteRequestAsync(request => _synchronousAnalyticsController.GetSynchronousAnalyticsAsync(parameters, request));
        }
    }
}
