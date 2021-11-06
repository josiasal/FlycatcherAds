using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;


namespace FlycatcherAds.Controllers
{
    public interface IAdsAccountsQueryExecutor
    {
        Task<ITwitterResult<AdsAccountsResponse>> GetAdsAccountsAsync(IGetAdsAccountsParameters parameters, ITwitterRequest request);
    }

    public class AdsAccountsQueryExecutor : IAdsAccountsQueryExecutor
    {
        private readonly JsonContentFactory _jsonContentFactory;
        private readonly IAdsAccountsQueryGenerator _adsAccountsQueryGenerator;
        private readonly ITwitterAccessor _twitterAccessor;

        public AdsAccountsQueryExecutor(
            JsonContentFactory jsonContentFactory,
            IAdsAccountsQueryGenerator adsAccountsQueryGenerator,
            ITwitterAccessor twitterAccessor)
        {
            _jsonContentFactory = jsonContentFactory;
            _adsAccountsQueryGenerator = adsAccountsQueryGenerator;
            _twitterAccessor = twitterAccessor;
        }

        public Task<ITwitterResult<AdsAccountsResponse>> GetAdsAccountsAsync(IGetAdsAccountsParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _adsAccountsQueryGenerator.GetAdsAccountsQuery(parameters);
            return _twitterAccessor.ExecuteRequestAsync<AdsAccountsResponse>(request);
        }
    }
}
