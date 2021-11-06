using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Models;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;


namespace FlycatcherAds.Core.Controllers
{
    public interface ISynchronousAnalyticsController
    {
        Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters, ITwitterRequest request);
    }
}