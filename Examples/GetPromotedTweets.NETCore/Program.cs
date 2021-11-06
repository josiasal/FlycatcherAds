using Tweetinvi;
using Tweetinvi.Models;
using FlycatcherAds;
using FlycatcherAds.Parameters;

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

            var iterator = client.PromotedTweetsClient.GetPromotedTweetsIterator(new GetPromotedTweetsParameters(){
                AccountId = "ACCOUNT_ID"
            });

            while (!iterator.Completed)
            {
                var promotedTweetsResponse = iterator.NextPageAsync().GetAwaiter().GetResult();
                foreach (var promotedTweet in promotedTweetsResponse?.Content?.PromotedTweets)
                {
                    System.Console.WriteLine($"Tweet Id: {promotedTweet.TweetId} - {promotedTweet.LineItemId} - {promotedTweet.EntityStatus} - Created at: {promotedTweet.CreatedAt}");
                }
            }
        }
    }
}
