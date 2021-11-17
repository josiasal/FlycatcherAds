using System;
using System.Text;
using Tweetinvi.Core.Extensions;
using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;
using FlycatcherAds.Controllers.Properties;

namespace FlycatcherAds.Controllers
{
    public class CustomAudiencesQueryGenerator : ICustomAudiencesQueryGenerator
    {
        public string GetCustomAudiencesQuery(IGetCustomAudiencesParameters parameters)
        {
            var query = new StringBuilder(
                String.Format(
                    Resources.CustomAudiences_Get,
                    Resources.AdsAPIVersion,
                    parameters.AccountId
                )
            );
            AddCustomAudiencesFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public void AddCustomAudiencesFieldsParameters(IGetCustomAudiencesParameters parameters, StringBuilder query)
        {
            // BaseAdsParameters
            query.AddParameterToQuery("count", parameters.Count);
            query.AddParameterToQuery("cursor", parameters.Cursor);
            query.AddParameterToQuery("sort_by", parameters.SortBy);
            query.AddParameterToQuery("with_deleted", parameters.WithDeleted);
            query.AddParameterToQuery("with_total_count", parameters.WithTotalCount);

            // GetCustomAudiencesParameters
            query.AddParameterToQuery("permission_scope", parameters.PermissionScope);
            query.AddParameterToQuery("custom_audience_ids", parameters.CustomAudienceIds);
        }
    }
}
