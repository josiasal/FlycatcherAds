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
    public class AdsAccountsController : IAdsAccountsController
    {
        private readonly IAdsAccountsQueryExecutor _queryExecutor;

        public AdsAccountsController(IAdsAccountsQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public ITwitterPageIterator<ITwitterResult<AdsAccountsResponse>, string> GetIterator(
            Func<IGetAdsAccountsParameters, ITwitterRequest, Task<ITwitterResult<AdsAccountsResponse>>> Method,
            IGetAdsAccountsParameters parameters,
            ITwitterRequest request)
        {
            Func<string, Task<ITwitterResult<AdsAccountsResponse>>> getNext = nextCursor =>
            {
                var cursoredParameters = new GetAdsAccountsParameters(parameters)
                {
                    Cursor = nextCursor
                };

                return Method(cursoredParameters, request);
            };

            var twitterCursorResult = new TwitterPageIterator<ITwitterResult<AdsAccountsResponse>, string>(
                parameters.Cursor,
                getNext,
                page =>
                {
                    if (page.Model.Accounts.Length == 0)
                    {
                        return null;
                    }

                    return page.Model.NextCursor;
                },
                page =>
                {
                    if (page.Model.Accounts.Length == 0)
                    {
                        return true;
                    }

                    return page.Model.NextCursor == null;
                });

            return twitterCursorResult;
        }

        public ITwitterPageIterator<ITwitterResult<AdsAccountsResponse>, string> GetAdsAccountIterator(
            IGetAdsAccountsParameters parameters, ITwitterRequest request)
        {
            return GetIterator(
                _queryExecutor.GetAdsAccountsAsync,
                parameters,
                request);
        }
    }
}
