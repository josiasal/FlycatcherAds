using Tweetinvi.Core.Helpers;

// ReSharper disable InvalidXmlDocComment
// ReSharper disable InconsistentNaming
namespace FlycatcherAds.Controllers.Properties
{
    public static class Resources
    {
        public static string AdsAPIVersion = "10";

        // Campaign Management
        public static string AdsAccounts_Get = "https://ads-api.twitter.com/{0}/accounts";
        public static string Campaigns_Get = "https://ads-api.twitter.com/{0}/accounts/{1}/campaigns";
        public static string PromotedTweets_Get = "https://ads-api.twitter.com/{0}/accounts/{1}/promoted_tweets";
        public static string LineItems_Get = "https://ads-api.twitter.com/{0}/accounts/{1}/line_items";

        // Analytics
        public static string SynchronousAnalytics_Get = "https://ads-api.twitter.com/{0}/stats/accounts/{1}";
        public static string AsynchronousAnalyticsJobsInfo_Get = "https://ads-api.twitter.com/{0}/stats/jobs/accounts/{1}";
        public static string AsynchronousAnalyticsCreateJob_Post = AsynchronousAnalyticsJobsInfo_Get;
        public static string AsynchronousAnalyticsDeleteJob_Delete = "https://ads-api.twitter.com/{0}/stats/jobs/accounts/{1}/{2}";
        public static string ActiveEntities_Get = "https://ads-api.twitter.com/{0}/stats/accounts/{1}/active_entities";

        // Creatives
        public static string AdsTimelines_Get = "https://ads-api.twitter.com/{0}/accounts/{1}/tweets";
        public static string MediaLibrary_Get = "https://ads-api.twitter.com/{0}/accounts/{1}/media_library";

        // Audiences
        public static string CustomAudiences_Get = "https://ads-api.twitter.com/{0}/accounts/{1}/custom_audiences";

        public static string GetResourceByName(string resourceName)
        {
            return ResourcesHelper.GetResourceByType(typeof(Resources), resourceName);
        }
    }
}
