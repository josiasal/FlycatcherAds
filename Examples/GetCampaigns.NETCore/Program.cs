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

            var iterator = client.CampaignsClient.GetCampaignsIterator(new GetCampaignsParameters(){
                AccountId = "ACCOUNT_ID"
            });

            while (!iterator.Completed)
            {
                var campaignsResponse = iterator.NextPageAsync().GetAwaiter().GetResult();
                foreach (var campaign in campaignsResponse?.Content?.Campaigns)
                {
                    System.Console.WriteLine($"{campaign.Id} - {campaign.Name} - Created at: {campaign.CreatedAt}");
                    System.Console.WriteLine($"The funding instrument: {campaign.FundingInstrumentId}");
                }
            }
        }
    }
}
