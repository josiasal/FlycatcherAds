using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;


namespace FlycatcherAds.Controllers
{
    public interface ICampaignsQueryExecutor
    {
        Task<ITwitterResult<CampaignsResponse>> GetCampaignsAsync(IGetCampaignsParameters parameters, ITwitterRequest request);
    }

    public class CampaignsQueryExecutor : ICampaignsQueryExecutor
    {
        private readonly JsonContentFactory _jsonContentFactory;
        private readonly ICampaignsQueryGenerator _campaignsQueryGenerator;
        private readonly ITwitterAccessor _twitterAccessor;

        public CampaignsQueryExecutor(
            JsonContentFactory jsonContentFactory,
            ICampaignsQueryGenerator campaignsQueryGenerator,
            ITwitterAccessor twitterAccessor)
        {
            _jsonContentFactory = jsonContentFactory;
            _campaignsQueryGenerator = campaignsQueryGenerator;
            _twitterAccessor = twitterAccessor;
        }

        public Task<ITwitterResult<CampaignsResponse>> GetCampaignsAsync(IGetCampaignsParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _campaignsQueryGenerator.GetCampaignsQuery(parameters);
            return _twitterAccessor.ExecuteRequestAsync<CampaignsResponse>(request);
        }
    }
}
