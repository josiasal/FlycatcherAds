using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;


namespace FlycatcherAds.Controllers
{
    public interface IPromotedTweetsQueryExecutor
    {
        Task<ITwitterResult<PromotedTweetsResponse>> GetPromotedTweetsAsync(IGetPromotedTweetsParameters parameters, ITwitterRequest request);
    }

    public class PromotedTweetsQueryExecutor : IPromotedTweetsQueryExecutor
    {
        private readonly JsonContentFactory _jsonContentFactory;
        private readonly IPromotedTweetsQueryGenerator _promotedTweetsQueryGenerator;
        private readonly ITwitterAccessor _twitterAccessor;

        public PromotedTweetsQueryExecutor(
            JsonContentFactory jsonContentFactory,
            IPromotedTweetsQueryGenerator promotedTweetsQueryGenerator,
            ITwitterAccessor twitterAccessor)
        {
            _jsonContentFactory = jsonContentFactory;
            _promotedTweetsQueryGenerator = promotedTweetsQueryGenerator;
            _twitterAccessor = twitterAccessor;
        }

        public Task<ITwitterResult<PromotedTweetsResponse>> GetPromotedTweetsAsync(IGetPromotedTweetsParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _promotedTweetsQueryGenerator.GetPromotedTweetsQuery(parameters);
            return _twitterAccessor.ExecuteRequestAsync<PromotedTweetsResponse>(request);
        }
    }
}
