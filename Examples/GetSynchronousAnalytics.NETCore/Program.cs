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
                EntityType = "PROMOTED_TWEET",
                Granularity = "DAY",
                Placement = "ALL_ON_TWITTER"
            };

            parameters.EntityIds.Add("PROMOTED_TWEET_ID");

            parameters.MetricGroups.Add("MEDIA");
            parameters.MetricGroups.Add("BILLING");
            parameters.MetricGroups.Add("VIDEO");
            parameters.MetricGroups.Add("ENGAGEMENT");

            return parameters;
        }

        private static IGetSynchronousAnalyticsParameters BuildParametersForOrganicTweets()
        {
            var parameters = new GetSynchronousAnalyticsParameters()
            {
                AccountId = "ACCOUNT_ID",
                StartTime = new System.DateTime(2021, 11, 3, 3, 0, 0),
                EndTime = new System.DateTime(2021, 11, 6, 3, 0, 0),
                EntityType = "ORGANIC_TWEET",
                Granularity = "DAY",
                Placement = "ALL_ON_TWITTER"
            };

            parameters.EntityIds.Add("ORGANIC_TWEET_ID");

            parameters.MetricGroups.Add("VIDEO");
            parameters.MetricGroups.Add("ENGAGEMENT");

            return parameters;
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

            var analytics = client.SynchronousAnalyticsClient
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
    }
}
