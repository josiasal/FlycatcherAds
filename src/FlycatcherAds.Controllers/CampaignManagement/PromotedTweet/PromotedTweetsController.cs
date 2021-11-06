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
    public class PromotedTweetsController : IPromotedTweetsController
    {
        private readonly IPromotedTweetsQueryExecutor _queryExecutor;

        public PromotedTweetsController(IPromotedTweetsQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public ITwitterPageIterator<ITwitterResult<PromotedTweetsResponse>, string> GetIterator(
            Func<IGetPromotedTweetsParameters, ITwitterRequest, Task<ITwitterResult<PromotedTweetsResponse>>> Method,
            IGetPromotedTweetsParameters parameters,
            ITwitterRequest request)
        {
            Func<string, Task<ITwitterResult<PromotedTweetsResponse>>> getNext = nextCursor =>
            {
                var cursoredParameters = new GetPromotedTweetsParameters(parameters)
                {
                    Cursor = nextCursor
                };

                return Method(cursoredParameters, request);
            };

            var twitterCursorResult = new TwitterPageIterator<ITwitterResult<PromotedTweetsResponse>, string>(
                parameters.Cursor,
                getNext,
                page =>
                {
                    if (page.Model.PromotedTweets.Length == 0)
                    {
                        return null;
                    }

                    return page.Model.NextCursor;
                },
                page =>
                {
                    if (page.Model.PromotedTweets.Length == 0)
                    {
                        return true;
                    }

                    return page.Model.NextCursor == null;
                });

            return twitterCursorResult;
        }

        public ITwitterPageIterator<ITwitterResult<PromotedTweetsResponse>, string> GetPromotedTweetsIterator(
            IGetPromotedTweetsParameters parameters, ITwitterRequest request)
        {
            return GetIterator(
                _queryExecutor.GetPromotedTweetsAsync,
                parameters,
                request);
        }
    }
}
