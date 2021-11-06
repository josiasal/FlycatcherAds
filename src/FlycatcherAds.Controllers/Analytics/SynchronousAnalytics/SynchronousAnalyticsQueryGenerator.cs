
using System;
using System.Collections.Generic;
using System.Text;
using Tweetinvi.Core.Extensions;

using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;
using FlycatcherAds.Controllers.Properties;

namespace FlycatcherAds.Controllers
{
    public class SynchronousAnalyticsQueryGenerator : ISynchronousAnalyticsQueryGenerator
    {
        public string GetSynchronousAnalyticsQuery(IGetSynchronousAnalyticsParameters parameters)
        {
            var query = new StringBuilder(
                String.Format(
                    Resources.SynchronousAnalytics_Get,
                    Resources.AdsAPIVersion,
                    parameters.AccountId
                )
            );

            AddSynchronousAnalyticsFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public void AddSynchronousAnalyticsFieldsParameters(IGetSynchronousAnalyticsParameters parameters, StringBuilder query)
        {
            query.AddParameterToQuery("start_time", parameters.StartTime.ToString("yyy-MM-ddThh:mm:ssZ"));
            query.AddParameterToQuery("end_time", parameters.EndTime.ToString("yyy-MM-ddThh:mm:ssZ"));
            query.AddParameterToQuery("entity", parameters.EntityType);
            query.AddParameterToQuery("entity_ids", parameters.EntityIds);
            query.AddParameterToQuery("granularity", parameters.Granularity);
            query.AddParameterToQuery("metric_groups", string.Join(",", parameters.MetricGroups));
            query.AddParameterToQuery("placement", parameters.Placement);
        }
    }
}
