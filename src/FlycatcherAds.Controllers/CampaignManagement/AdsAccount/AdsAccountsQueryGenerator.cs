using System;
using System.Text;
using Tweetinvi.Core.Extensions;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;
using FlycatcherAds.Controllers.Properties;

namespace FlycatcherAds.Controllers
{
    public class AdsAccountsQueryGenerator : IAdsAccountsQueryGenerator
    {
        public string GetAdsAccountsQuery(IGetAdsAccountsParameters parameters)
        {
            var query = new StringBuilder(String.Format(Resources.AdsAccounts_Get, Resources.AdsAPIVersion));
            AddAdsAccountsFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public void AddAdsAccountsFieldsParameters(IGetAdsAccountsParameters parameters, StringBuilder query)
        {
            // BaseAdsParameters
            query.AddParameterToQuery("count", parameters.Count);
            query.AddParameterToQuery("cursor", parameters.Cursor);
            query.AddParameterToQuery("sort_by", parameters.SortBy);
            query.AddParameterToQuery("with_deleted", parameters.WithDeleted);
            query.AddParameterToQuery("with_total_count", parameters.WithTotalCount);

            // GetAdsAccountsParameters
            query.AddParameterToQuery("query", parameters.Query);
            query.AddParameterToQuery("ids", parameters.AccountIds);
        }
    }
}
