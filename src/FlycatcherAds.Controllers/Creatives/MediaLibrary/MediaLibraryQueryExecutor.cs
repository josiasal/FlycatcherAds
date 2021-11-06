using System.Threading.Tasks;

using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;


namespace FlycatcherAds.Controllers
{
    public interface IMediaLibraryQueryExecutor
    {
        Task<ITwitterResult<MediaLibraryResponse>> GetMediaLibraryAsync(IGetMediaLibraryParameters parameters, ITwitterRequest request);
    }

    public class MediaLibraryQueryExecutor : IMediaLibraryQueryExecutor
    {
        private readonly JsonContentFactory _jsonContentFactory;
        private readonly IMediaLibraryQueryGenerator _MediaLibraryQueryGenerator;
        private readonly ITwitterAccessor _twitterAccessor;

        public MediaLibraryQueryExecutor(
            JsonContentFactory jsonContentFactory,
            IMediaLibraryQueryGenerator MediaLibraryQueryGenerator,
            ITwitterAccessor twitterAccessor)
        {
            _jsonContentFactory = jsonContentFactory;
            _MediaLibraryQueryGenerator = MediaLibraryQueryGenerator;
            _twitterAccessor = twitterAccessor;
        }

        public Task<ITwitterResult<MediaLibraryResponse>> GetMediaLibraryAsync(IGetMediaLibraryParameters parameters, ITwitterRequest request)
        {
            request.Query.Url = _MediaLibraryQueryGenerator.GetMediaLibraryQuery(parameters);
            var result = _twitterAccessor.ExecuteRequestAsync<MediaLibraryResponse>(request);
            return result;
        }
    }
}
