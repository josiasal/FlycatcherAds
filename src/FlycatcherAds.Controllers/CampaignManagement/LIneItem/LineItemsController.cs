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
    public class LineItemsController : ILineItemsController
    {
        private readonly ILineItemsQueryExecutor _queryExecutor;

        public LineItemsController(ILineItemsQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public ITwitterPageIterator<ITwitterResult<LineItemsResponse>, string> GetIterator(
            Func<IGetLineItemsParameters, ITwitterRequest, Task<ITwitterResult<LineItemsResponse>>> Method,
            IGetLineItemsParameters parameters,
            ITwitterRequest request)
        {
            Func<string, Task<ITwitterResult<LineItemsResponse>>> getNext = nextCursor =>
            {
                var cursoredParameters = new GetLineItemsParameters(parameters)
                {
                    Cursor = nextCursor
                };

                return Method(cursoredParameters, request);
            };

            var twitterCursorResult = new TwitterPageIterator<ITwitterResult<LineItemsResponse>, string>(
                parameters.Cursor,
                getNext,
                page =>
                {
                    if (page.Model.LineItems.Length == 0)
                    {
                        return null;
                    }

                    return page.Model.NextCursor;
                },
                page =>
                {
                    if (page.Model.LineItems.Length == 0)
                    {
                        return true;
                    }

                    return page.Model.NextCursor == null;
                });

            return twitterCursorResult;
        }

        public ITwitterPageIterator<ITwitterResult<LineItemsResponse>, string> GetLineItemsIterator(
            IGetLineItemsParameters parameters, ITwitterRequest request)
        {
            return GetIterator(
                _queryExecutor.GetLineItemsAsync,
                parameters,
                request);
        }
    }
}
