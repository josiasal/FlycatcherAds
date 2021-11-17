using System;
using System.Threading.Tasks;
using Tweetinvi.Core.Iterators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;

using FlycatcherAds.Core.Controllers;

using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

namespace FlycatcherAds.Controllers
{
    public class MediaLibraryController : IMediaLibraryController
    {
        private readonly IMediaLibraryQueryExecutor _queryExecutor;

        public MediaLibraryController(IMediaLibraryQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public ITwitterPageIterator<ITwitterResult<MediaLibraryResponse>, string> GetIterator(
            Func<IGetMediaLibraryParameters, ITwitterRequest, Task<ITwitterResult<MediaLibraryResponse>>> Method,
            IGetMediaLibraryParameters parameters,
            ITwitterRequest request)
        {
            Func<string, Task<ITwitterResult<MediaLibraryResponse>>> getNext = nextCursor =>
            {
                var cursoredParameters = new GetMediaLibraryParameters(parameters)
                {
                    Cursor = nextCursor
                };

                return Method(cursoredParameters, request);
            };

            var twitterCursorResult = new TwitterPageIterator<ITwitterResult<MediaLibraryResponse>, string>(
                parameters.Cursor,
                getNext,
                page =>
                {
                    if (page.Model.MediaLibraries.Length == 0)
                    {
                        return null;
                    }

                    return page.Model.NextCursor;
                },
                page =>
                {
                    if (page.Model.MediaLibraries.Length == 0)
                    {
                        return true;
                    }

                    return page.Model.NextCursor == null;
                });

            return twitterCursorResult;
        }

        public ITwitterPageIterator<ITwitterResult<MediaLibraryResponse>, string> GetMediaLibraryIterator(
            IGetMediaLibraryParameters parameters, ITwitterRequest request)
        {
            return GetIterator(
                _queryExecutor.GetMediaLibraryAsync,
                parameters,
                request);
        }
    }
}
