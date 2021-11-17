using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;


namespace FlycatcherAds.Controllers
{
    public interface ILineItemsQueryExecutor
    {
        Task<ITwitterResult<LineItemsResponse>> GetLineItemsAsync(IGetLineItemsParameters parameters, ITwitterRequest request);
    }

    public class LineItemsQueryExecutor : ILineItemsQueryExecutor
    {
        private readonly JsonContentFactory _jsonContentFactory;
        private readonly ILineItemsQueryGenerator _lineItemsQueryGenerator;
        private readonly ITwitterAccessor _twitterAccessor;

        public LineItemsQueryExecutor(
            JsonContentFactory jsonContentFactory,
            ILineItemsQueryGenerator LineItemsQueryGenerator,
            ITwitterAccessor twitterAccessor)
        {
            _jsonContentFactory = jsonContentFactory;
            _lineItemsQueryGenerator = LineItemsQueryGenerator;
            _twitterAccessor = twitterAccessor;
        }

        public Task<ITwitterResult<LineItemsResponse>> GetLineItemsAsync(IGetLineItemsParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _lineItemsQueryGenerator.GetLineItemsQuery(parameters);
            return _twitterAccessor.ExecuteRequestAsync<LineItemsResponse>(request);
        }
    }
}
