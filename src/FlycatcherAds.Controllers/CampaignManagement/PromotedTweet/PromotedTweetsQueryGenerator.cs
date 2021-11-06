using System;
using System.Text;
using Tweetinvi.Core.Extensions;

using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;
using FlycatcherAds.Controllers.Properties;

namespace FlycatcherAds.Controllers
{
    public class PromotedTweetsQueryGenerator : IPromotedTweetsQueryGenerator
    {
        public string GetPromotedTweetsQuery(IGetPromotedTweetsParameters parameters)
        {
            var query = new StringBuilder(
                String.Format(
                    Resources.PromotedTweets_Get,
                    Resources.AdsAPIVersion,
                    parameters.AccountId
                )
            );

            AddPromotedTweetsFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public void AddPromotedTweetsFieldsParameters(IGetPromotedTweetsParameters parameters, StringBuilder query)
        {
            // BaseAdsParameters
            query.AddParameterToQuery("count", parameters.Count);
            query.AddParameterToQuery("cursor", parameters.Cursor);
            query.AddParameterToQuery("sort_by", parameters.SortBy);
            query.AddParameterToQuery("with_deleted", parameters.WithDeleted);
            query.AddParameterToQuery("with_total_count", parameters.WithTotalCount);

            // GetPromotedTweetsParameters
            query.AddParameterToQuery("line_item_ids", parameters.LineItemIds);
            query.AddParameterToQuery("promoted_tweet_ids", parameters.PromotedTweetIds);
        }
    }
}
