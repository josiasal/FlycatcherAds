using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;


namespace FlycatcherAds.Controllers
{
    public interface ISynchronousAnalyticsQueryExecutor
    {
        Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters, ITwitterRequest request);
    }

    public class SynchronousAnalyticsQueryExecutor : ISynchronousAnalyticsQueryExecutor
    {
        private readonly JsonContentFactory _jsonContentFactory;
        private readonly ISynchronousAnalyticsQueryGenerator _SynchronousAnalyticsQueryGenerator;
        private readonly ITwitterAccessor _twitterAccessor;

        public SynchronousAnalyticsQueryExecutor(
            JsonContentFactory jsonContentFactory,
            ISynchronousAnalyticsQueryGenerator SynchronousAnalyticsQueryGenerator,
            ITwitterAccessor twitterAccessor)
        {
            _jsonContentFactory = jsonContentFactory;
            _SynchronousAnalyticsQueryGenerator = SynchronousAnalyticsQueryGenerator;
            _twitterAccessor = twitterAccessor;
        }

        public Task<ITwitterResult<SynchronousAnalyticsResponse>> GetSynchronousAnalyticsAsync(IGetSynchronousAnalyticsParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _SynchronousAnalyticsQueryGenerator.GetSynchronousAnalyticsQuery(parameters);
            return _twitterAccessor.ExecuteRequestAsync<SynchronousAnalyticsResponse>(request);
        }
    }
}
