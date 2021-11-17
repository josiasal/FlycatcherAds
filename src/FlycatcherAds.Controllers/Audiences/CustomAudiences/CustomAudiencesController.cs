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
    public class CustomAudiencesController : ICustomAudiencesController
    {
        private readonly ICustomAudiencesQueryExecutor _queryExecutor;

        public CustomAudiencesController(ICustomAudiencesQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public ITwitterPageIterator<ITwitterResult<CustomAudiencesResponse>, string> GetIterator(
            Func<IGetCustomAudiencesParameters, ITwitterRequest, Task<ITwitterResult<CustomAudiencesResponse>>> Method,
            IGetCustomAudiencesParameters parameters,
            ITwitterRequest request)
        {
            Func<string, Task<ITwitterResult<CustomAudiencesResponse>>> getNext = nextCursor =>
            {
                var cursoredParameters = new GetCustomAudiencesParameters(parameters)
                {
                    Cursor = nextCursor
                };

                return Method(cursoredParameters, request);
            };

            var twitterCursorResult = new TwitterPageIterator<ITwitterResult<CustomAudiencesResponse>, string>(
                parameters.Cursor,
                getNext,
                page =>
                {
                    if (page.Model.CustomAudiences.Length == 0)
                    {
                        return null;
                    }

                    return page.Model.NextCursor;
                },
                page =>
                {
                    if (page.Model.CustomAudiences.Length == 0)
                    {
                        return true;
                    }

                    return page.Model.NextCursor == null;
                });

            return twitterCursorResult;
        }

        public ITwitterPageIterator<ITwitterResult<CustomAudiencesResponse>, string> GetCustomAudiencesIterator(
            IGetCustomAudiencesParameters parameters, ITwitterRequest request)
        {
            return GetIterator(
                _queryExecutor.GetCustomAudiencesAsync,
                parameters,
                request);
        }
    }
}
