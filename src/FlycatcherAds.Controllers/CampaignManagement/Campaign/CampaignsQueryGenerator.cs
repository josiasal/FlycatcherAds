using System;
using System.Text;
using Tweetinvi.Core.Extensions;

using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;
using FlycatcherAds.Controllers.Properties;

namespace FlycatcherAds.Controllers
{
    public class CampaignsQueryGenerator : ICampaignsQueryGenerator
    {
        public string GetCampaignsQuery(IGetCampaignsParameters parameters)
        {
            var query = new StringBuilder(
                String.Format(
                    Resources.Campaigns_Get,
                    Resources.AdsAPIVersion,
                    parameters.AccountId
                )
            );

            AddCampaignsFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public void AddCampaignsFieldsParameters(IGetCampaignsParameters parameters, StringBuilder query)
        {
            // BaseAdsParameters
            query.AddParameterToQuery("count", parameters.Count);
            query.AddParameterToQuery("cursor", parameters.Cursor);
            query.AddParameterToQuery("sort_by", parameters.SortBy);
            query.AddParameterToQuery("with_deleted", parameters.WithDeleted);
            query.AddParameterToQuery("with_total_count", parameters.WithTotalCount);

            // GetCampaignsParameters
            query.AddParameterToQuery("query", parameters.Query);
            query.AddParameterToQuery("with_draft", parameters.WithDraft);
            query.AddParameterToQuery("campaign_ids", parameters.CampaignIds);
            query.AddParameterToQuery("funding_instrument_ids", parameters.FundingInstrumentIds);
        }
    }
}
