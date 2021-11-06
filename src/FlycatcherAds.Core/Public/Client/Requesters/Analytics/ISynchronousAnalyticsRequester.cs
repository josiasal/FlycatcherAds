using System.Threading.Tasks;

using Tweetinvi.Core.Web;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Client
{
    public interface ISynchronousAnalyticsRequester
    {
        Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters);
    }
}
