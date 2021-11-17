using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;


namespace FlycatcherAds.Controllers
{
    public interface ICustomAudiencesQueryExecutor
    {
        Task<ITwitterResult<CustomAudiencesResponse>> GetCustomAudiencesAsync(IGetCustomAudiencesParameters parameters, ITwitterRequest request);
    }

    public class CustomAudiencesQueryExecutor : ICustomAudiencesQueryExecutor
    {
        private readonly JsonContentFactory _jsonContentFactory;
        private readonly ICustomAudiencesQueryGenerator _customAudiencesQueryGenerator;
        private readonly ITwitterAccessor _twitterAccessor;

        public CustomAudiencesQueryExecutor(
            JsonContentFactory jsonContentFactory,
            ICustomAudiencesQueryGenerator customAudiencesQueryGenerator,
            ITwitterAccessor twitterAccessor)
        {
            _jsonContentFactory = jsonContentFactory;
            _customAudiencesQueryGenerator = customAudiencesQueryGenerator;
            _twitterAccessor = twitterAccessor;
        }

        public Task<ITwitterResult<CustomAudiencesResponse>> GetCustomAudiencesAsync(IGetCustomAudiencesParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _customAudiencesQueryGenerator.GetCustomAudiencesQuery(parameters);
            return _twitterAccessor.ExecuteRequestAsync<CustomAudiencesResponse>(request);
        }
    }
}
