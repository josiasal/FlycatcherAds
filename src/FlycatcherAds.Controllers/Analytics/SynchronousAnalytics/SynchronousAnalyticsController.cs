using System;
using System.Threading.Tasks;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Core.Controllers;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Controllers.AdsAccount
{
    public class SynchronousAnalyticsController : ISynchronousAnalyticsController
    {
        private readonly ISynchronousAnalyticsQueryExecutor _queryExecutor;

        public SynchronousAnalyticsController(ISynchronousAnalyticsQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(
            IGetSynchronousAnalyticsParameters parameters, ITwitterRequest request)
        {
            return _queryExecutor.GetSynchronousAnalyticsAsync(parameters, request);
        }
    }
}
