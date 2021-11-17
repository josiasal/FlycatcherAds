using System;
using System.Text;
using Tweetinvi.Core.Extensions;

using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;
using FlycatcherAds.Controllers.Properties;

namespace FlycatcherAds.Controllers
{
    public class LineItemsQueryGenerator : ILineItemsQueryGenerator
    {
        public string GetLineItemsQuery(IGetLineItemsParameters parameters)
        {
            var query = new StringBuilder(
                String.Format(
                    Resources.LineItems_Get,
                    Resources.AdsAPIVersion,
                    parameters.AccountId
                )
            );

            AddLineItemsFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public void AddLineItemsFieldsParameters(IGetLineItemsParameters parameters, StringBuilder query)
        {
            // BaseAdsParameters
            query.AddParameterToQuery("count", parameters.Count);
            query.AddParameterToQuery("cursor", parameters.Cursor);
            query.AddParameterToQuery("sort_by", parameters.SortBy);
            query.AddParameterToQuery("with_deleted", parameters.WithDeleted);
            query.AddParameterToQuery("with_total_count", parameters.WithTotalCount);

            // GetLineItemsParameters
            query.AddParameterToQuery("account_id", parameters.AccountId);
            query.AddParameterToQuery("campaign_ids", parameters.CampaignIds);
            query.AddParameterToQuery("lineitem_ids", parameters.LineItemIds);
            query.AddParameterToQuery("funding_instrument_ids", parameters.FundingInstrumentIds);
            query.AddParameterToQuery("q", parameters.Query);
            query.AddParameterToQuery("with_draft", parameters.WithDraft);
        }
    }
}
