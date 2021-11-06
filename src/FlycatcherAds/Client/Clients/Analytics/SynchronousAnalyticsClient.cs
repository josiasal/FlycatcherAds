using System.Threading.Tasks;
using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public class SynchronousAnalyticsClient : ISynchronousAnalyticsClient
    {
        private readonly ISynchronousAnalyticsRequester _campaignsRequester;

        public SynchronousAnalyticsClient(ISynchronousAnalyticsRequester campaignsRequester)
        {
            _campaignsRequester = campaignsRequester;
        }

        public async Task<SynchronousAnalyticsResponse> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters)
        {
            var response = await _campaignsRequester.GetSynchronousAnalyticsAsync(parameters).ConfigureAwait(false);
            return response?.Model;
        }
    }
}
