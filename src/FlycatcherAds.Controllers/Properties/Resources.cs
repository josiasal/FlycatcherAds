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
        
        // Analytics
        public static string SynchronousAnalytics_Get = "https://ads-api.twitter.com/{0}/stats/accounts/{1}";

        // Creatives
        public static string AdsTimelines_Get = "https://ads-api.twitter.com/{0}/accounts/{1}/tweets";
        public static string MediaLibrary_Get = "https://ads-api.twitter.com/{0}/accounts/{1}/media_library";

        public static string GetResourceByName(string resourceName)
        {
            return ResourcesHelper.GetResourceByType(typeof(Resources), resourceName);
        }
    }
}
