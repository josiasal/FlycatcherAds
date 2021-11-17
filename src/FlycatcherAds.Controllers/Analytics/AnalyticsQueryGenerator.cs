
using System;
using System.Linq;
using System.Text;
using Tweetinvi.Core.Extensions;

using FlycatcherAds.Parameters;
using FlycatcherAds.Core.QueryGenerators;
using FlycatcherAds.Controllers.Properties;

namespace FlycatcherAds.Controllers
{
    public class AnalyticsQueryGenerator : IAnalyticsQueryGenerator
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

            AddAnalyticsFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public string GetAsynchronousAnalyticsJobsInfoQuery(IGetAsynchronousAnalyticsJobsParameters parameters)
        {
            var query = new StringBuilder(
                String.Format(
                    Resources.AsynchronousAnalyticsJobsInfo_Get,
                    Resources.AdsAPIVersion,
                    parameters.AccountId
                )
            );

            AddAnalyticsFieldsParameters(parameters, query);

            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public string CreateAsynchronousAnalyticsJobQuery(ICreateAsynchronousAnalyticsJobParameters parameters)
        {
            var query = new StringBuilder(
                String.Format(
                    Resources.AsynchronousAnalyticsCreateJob_Post,
                    Resources.AdsAPIVersion,
                    parameters.AccountId
                )
            );

            AddAnalyticsFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
            
        }

        public string DeleteAsynchronousAnalyticsJobQuery(IDeleteAsynchronousAnalyticsJobParameters parameters)
        {
            var query = new StringBuilder(
                String.Format(
                    Resources.AsynchronousAnalyticsDeleteJob_Delete,
                    Resources.AdsAPIVersion,
                    parameters.AccountId,
                    parameters.JobId
                )
            );

            AddAnalyticsFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public string GetActiveEntitiesQuery(IGetActiveEntitiesParameters parameters)
        {
            var query = new StringBuilder(
                String.Format(
                    Resources.ActiveEntities_Get,
                    Resources.AdsAPIVersion,
                    parameters.AccountId
                )
            );

            AddAnalyticsFieldsParameters(parameters, query);
            query.AddFormattedParameterToQuery(parameters.FormattedCustomQueryParameters);
            return query.ToString();
        }

        public void AddBaseAnalyticsFieldsParameters(IBaseAnalyticsParameters parameters, StringBuilder query)
        {
            query.AddParameterToQuery("start_time", parameters.StartTime.ToString("yyyy-MM-ddThh:mm:ssZ"));
            query.AddParameterToQuery("end_time", parameters.EndTime.ToString("yyyy-MM-ddThh:mm:ssZ"));
            query.AddParameterToQuery("entity", parameters.EntityType.ToString());
        }

        public void AddAnalyticsFieldsParameters(IGetSynchronousAnalyticsParameters parameters, StringBuilder query)
        {
            AddBaseAnalyticsFieldsParameters(parameters, query);
            query.AddParameterToQuery("entity_ids", parameters.EntityIds);
            query.AddParameterToQuery("granularity", parameters.Granularity.ToString());
            query.AddParameterToQuery("metric_groups", string.Join(",", parameters.MetricGroups.Select(it => it.ToString())));
            query.AddParameterToQuery("placement", parameters.Placement.ToString());
        }

        public void AddAnalyticsFieldsParameters(IGetAsynchronousAnalyticsJobsParameters parameters, StringBuilder query)
        {
            query.AddParameterToQuery("count", parameters.Count);
            query.AddParameterToQuery("cursor", parameters.Cursor);
            query.AddParameterToQuery("job_ids", parameters.JobIds);
        }

        public void AddAnalyticsFieldsParameters(ICreateAsynchronousAnalyticsJobParameters parameters, StringBuilder query)
        {
            AddBaseAnalyticsFieldsParameters(parameters, query);
            query.AddParameterToQuery("entity_ids", parameters.EntityIds);
            query.AddParameterToQuery("granularity", parameters.Granularity.ToString());
            query.AddParameterToQuery("metric_groups", string.Join(",", parameters.MetricGroups.Select(it => it.ToString())));
            query.AddParameterToQuery("placement", parameters.Placement.ToString());
            query.AddParameterToQuery("country", parameters.Country);
            query.AddParameterToQuery("platform_type", parameters.PlatformType);
            query.AddParameterToQuery("segmentation_type", parameters.SegmentationType.ToString());
        }

        public void AddAnalyticsFieldsParameters(IDeleteAsynchronousAnalyticsJobParameters parameters, StringBuilder query)
        {
            query.AddParameterToQuery("job_id", parameters.JobId);
        }

        public void AddAnalyticsFieldsParameters(IGetActiveEntitiesParameters parameters, StringBuilder query)
        {
            AddBaseAnalyticsFieldsParameters(parameters, query);
            query.AddParameterToQuery("campaign_ids", parameters.CampaignIds);
            query.AddParameterToQuery("funding_instrument_ids", parameters.FundingInstrumentIds);
            query.AddParameterToQuery("line_item_ids", parameters.LineItemIds);
        }
    }
}
