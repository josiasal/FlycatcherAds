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

            var iterator = client.AdsAccountsClient.GetAccountsIterator(new GetAdsAccountsParameters());

            while (!iterator.Completed)
            {
                var adsAccountResponse = iterator.NextPageAsync().GetAwaiter().GetResult();
                foreach (AdsAccount adsAccount in adsAccountResponse?.Content?.Accounts)
                {
                    System.Console.WriteLine($"{adsAccount.Id} - {adsAccount.Name} - Created at: {adsAccount.CreatedAt}");
                }
            }
        }
    }
}
