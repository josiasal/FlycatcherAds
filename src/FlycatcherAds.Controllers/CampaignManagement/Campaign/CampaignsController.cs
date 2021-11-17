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
    public class CampaignsController : ICampaignsController
    {
        private readonly ICampaignsQueryExecutor _queryExecutor;

        public CampaignsController(ICampaignsQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public ITwitterPageIterator<ITwitterResult<CampaignsResponse>, string> GetIterator(
            Func<IGetCampaignsParameters, ITwitterRequest, Task<ITwitterResult<CampaignsResponse>>> Method,
            IGetCampaignsParameters parameters,
            ITwitterRequest request)
        {
            Func<string, Task<ITwitterResult<CampaignsResponse>>> getNext = nextCursor =>
            {
                var cursoredParameters = new GetCampaignsParameters(parameters)
                {
                    Cursor = nextCursor
                };

                return Method(cursoredParameters, request);
            };

            var twitterCursorResult = new TwitterPageIterator<ITwitterResult<CampaignsResponse>, string>(
                parameters.Cursor,
                getNext,
                page =>
                {
                    if (page.Model.Campaigns.Length == 0)
                    {
                        return null;
                    }

                    return page.Model.NextCursor;
                },
                page =>
                {
                    if (page.Model.Campaigns.Length == 0)
                    {
                        return true;
                    }

                    return page.Model.NextCursor == null;
                });

            return twitterCursorResult;
        }

        public ITwitterPageIterator<ITwitterResult<CampaignsResponse>, string> GetCampaignsIterator(
            IGetCampaignsParameters parameters, ITwitterRequest request)
        {
            return GetIterator(
                _queryExecutor.GetCampaignsAsync,
                parameters,
                request);
        }
    }
}
