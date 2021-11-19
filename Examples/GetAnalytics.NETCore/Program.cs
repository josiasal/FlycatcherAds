using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Models;
using FlycatcherAds;
using FlycatcherAds.Models;
using FlycatcherAds.Parameters;

using TweetinviContainer = Tweetinvi.Injectinvi.TweetinviContainer;

namespace Examples.GetAdsAccount.NETCore
{
    public class Program
    {
        private static IGetSynchronousAnalyticsParameters BuildParametersForPromotedTweets()
        {
            var parameters = new GetSynchronousAnalyticsParameters()
            {
                AccountId = "ACCOUNT_ID",
                StartTime = new System.DateTime(2021, 11, 3, 3, 0, 0),
                EndTime = new System.DateTime(2021, 11, 6, 3, 0, 0),
                EntityType = EntityType.PROMOTED_TWEET,
                Granularity = FlycatcherAds.Models.Granularity.DAY,
                Placement = Placement.ALL_ON_TWITTER
            };

            parameters.EntityIds.Add("PROMOTED_TWEET_ID");

            parameters.MetricGroups.Add(MetricGroup.MEDIA);
            parameters.MetricGroups.Add(MetricGroup.BILLING);
            parameters.MetricGroups.Add(MetricGroup.VIDEO);
            parameters.MetricGroups.Add(MetricGroup.ENGAGEMENT);

            return parameters;
        }

        private static IGetSynchronousAnalyticsParameters BuildParametersForOrganicTweets()
        {
            var parameters = new GetSynchronousAnalyticsParameters()
            {
                AccountId = "ACCOUNT_ID",
                StartTime = new System.DateTime(2020, 12, 25, 3, 0, 0),
                EndTime = new System.DateTime(2021, 1, 1, 3, 0, 0),
                EntityType = EntityType.ORGANIC_TWEET,
                Granularity = Granularity.DAY,
                Placement = Placement.ALL_ON_TWITTER
            };

            parameters.EntityIds.Add("ENTITY_ID");
            
            parameters.MetricGroups.Add(MetricGroup.VIDEO);
            parameters.MetricGroups.Add(MetricGroup.ENGAGEMENT);

            return parameters;
        }

        private static IGetAsynchronousAnalyticsJobsParameters BuildParametersForListingJobs()
        {
            return new GetAsynchronousAnalyticsJobsParameters()
            {
                AccountId = "ACCOUNT_ID"
            };
        }

        private static ICreateAsynchronousAnalyticsJobParameters BuildParametersForCreatingAsynchronousJob()
        {
            return new CreateAsynchronousAnalyticsJobParameters()
            {
                AccountId = "ACCOUNT_ID",
                EndTime = new System.DateTime(2021, 11, 17, 3, 0, 0),
                EntityType = EntityType.PROMOTED_TWEET,
                StartTime = new System.DateTime(2021, 10, 17, 3, 0, 0),
                Granularity = Granularity.DAY,
                Placement = Placement.ALL_ON_TWITTER,
                EntityIds = new HashSet<string>()
                {
                    "PROMOTED_TWEET_ID",
                },
                MetricGroups = new HashSet<MetricGroup>()
                {
                    MetricGroup.MEDIA,
                    MetricGroup.BILLING,
                    MetricGroup.VIDEO,
                    MetricGroup.ENGAGEMENT
                },
                SegmentationType = SegmentationType.AGE
            };
        }

        private static void ShowAsynchronousAnalyticsJobInfo(AsynchronousAnalyticsJobInfo jobInfo)
        {
            if (jobInfo == null)
            {
                System.Console.WriteLine("No job info found");
                return;
            }

            System.Console.WriteLine($" This is the Id: {jobInfo.Id}");
            System.Console.WriteLine($" This is the StartTime: {jobInfo.StartTime}");
            System.Console.WriteLine($" This is the EndTime: {jobInfo.EndTime}");
            System.Console.WriteLine($" This is the Status: {jobInfo.Status}");
            System.Console.WriteLine($" This is the SegementationType: {jobInfo.SegementationType}");
            System.Console.WriteLine($" This is the Url: {jobInfo.Url}");
            foreach (var entityId in jobInfo.EntityIds)
            {
                System.Console.WriteLine($" This is the EntityId: {entityId}");
            }
            System.Console.WriteLine($" This is the IdStr: {jobInfo.IdStr}");
            System.Console.WriteLine($" This is the Country: {jobInfo.Country}");
            System.Console.WriteLine($" This is the Placement: {jobInfo.Placement}");
            System.Console.WriteLine($" This is the ExpiresAt: {jobInfo.ExpiresAt}");
            System.Console.WriteLine($" This is the CreatedAt: {jobInfo.CreatedAt}");
            System.Console.WriteLine($" This is the UpdatedAt: {jobInfo.UpdatedAt}");
            System.Console.WriteLine($" This is the Entity: {jobInfo.Entity}");
            System.Console.WriteLine($" This is the Platform: {jobInfo.Platform}");
            foreach (var metricGroup in jobInfo.MetricGroups)
            {
                System.Console.WriteLine($" This is the MetricGroup: {metricGroup}");
            }
            System.Console.WriteLine("===============================================");
        }

        private static void RunGetActiveEntities(ITwitterAdsClient client)
        {
            var entities = client.AnalyticsClient
                .GetActiveEntitiesAsync(new GetActiveEntitiesParameters()
                {
                    AccountId = "ACCOUNT_ID"
                })
                .GetAwaiter()
                .GetResult();

            foreach (var entity in entities.ActiveEntities)
            {
                System.Console.WriteLine($"This is the EntityId {entity.EntityId}");
                System.Console.WriteLine($"This is the ActivityStartTime {entity.ActivityStartTime}");
                System.Console.WriteLine($"This is the ActivityEndTime {entity.ActivityEndTime}");
                System.Console.WriteLine($"This is the Placements {entity.Placements}");
            }
        }

        private static void RunSynchronousAnalytics(ITwitterAdsClient client)
        {
            var analytics = client.AnalyticsClient
                .GetSynchronousAnalyticsAsync(BuildParametersForOrganicTweets())
                .GetAwaiter()
                .GetResult();

            System.Console.WriteLine($"This is the data type: {analytics.DataType}");
            System.Console.WriteLine($"This is the time series length: {analytics.TimeSeriesLength}");

            foreach (var statisticsData in analytics.StatisticsData)
            {
                System.Console.WriteLine($"This is the id: {statisticsData.Id}");

                foreach (var statistic in statisticsData.Statistics)
                {
                    System.Console.WriteLine($"This is the Segment: {statistic.Segment}");
                    System.Console.WriteLine("===============================================");
                    foreach (KeyValuePair<string, List<int>> entry in statistic.Metrics)
                    {
                        if (entry.Value?.Count > 0)
                        {
                            System.Console.WriteLine($"This is the metric: {entry.Key}");
                            foreach (var value in entry.Value)
                            {
                                System.Console.WriteLine($"This is the value: {value}");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine($"The metric: {entry.Key} is empty");
                        }
                    }
                }
            }
        }

        private static void RunAsynchronousAnalyticsJobs(ITwitterAdsClient client)
        {
            var iterator = client.AnalyticsClient
                .GetAsynchronousAnalyticsJobsInfoIterator(BuildParametersForListingJobs());
                
            while (!iterator.Completed)
            {
                var response = iterator.NextPageAsync().GetAwaiter().GetResult();
                foreach (var jobInfo in response?.Content?.AsynchrounousAnalyticsJobs)
                {
                    ShowAsynchronousAnalyticsJobInfo(jobInfo);
                }
            }
        }

        private static void RunCreateAsynchronousAnalyticsJob(ITwitterAdsClient client)
        {
            var response = client.AnalyticsClient
                .CreateAsynchronousAnalyticsJobAsync(BuildParametersForCreatingAsynchronousJob())
                .GetAwaiter()
                .GetResult();

            ShowAsynchronousAnalyticsJobInfo(response.AsynchrounousAnalyticsJobInfo);
        }

        public static void Main(string[] args)
        {
            var client = new TwitterAdsClient(
                new ReadOnlyTwitterCredentials(
                    consumerKey: "CONSUMER_KEY",
                    consumerSecret : "CONSUMER_SECRET",
                    accessToken: "ACCESS_TOKEN",
                    accessTokenSecret: "ACCESS_TOKEN_SECRET"
                )
            );

            RunGetActiveEntities(client);
            // RunCreateAsynchronousAnalyticsJob(client);
            // RunSynchronousAnalytics(client);
            // RunAsynchronousAnalyticsJobs(client);
        }
    }
}
