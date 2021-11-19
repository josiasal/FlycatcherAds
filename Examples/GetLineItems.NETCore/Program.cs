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

            var iterator = client.LineItemsClient.GetLineItemsIterator(new GetLineItemsParameters(){
                AccountId = "ACCOUNT_ID"
            });

            while (!iterator.Completed)
            {
                var lineItemsResponse = iterator.NextPageAsync().GetAwaiter().GetResult();
                foreach (var lineItem in lineItemsResponse?.Content?.LineItems)
                {
                    System.Console.WriteLine($"{lineItem.Id} - {lineItem.Name} - Created at: {lineItem.CreatedAt}");
                    System.Console.WriteLine($"The advertiser id: {lineItem.AdvertiserUserId}");
                    System.Console.WriteLine($"The entity status: {lineItem.EntityStatus}");
                    System.Console.WriteLine($"The bid strategy: {lineItem.BidStrategy}");
                    System.Console.WriteLine($"The bid amount: {lineItem.BidAmountLocalMicro}");
                    System.Console.WriteLine($"The bid currency: {lineItem.Currency}");
                    System.Console.WriteLine($"The bid pay by: {lineItem.PayBy}");
                    System.Console.WriteLine($"The product type: {lineItem.ProductType}");
                }
            }
        }
    }
}
