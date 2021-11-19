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

            var iterator = client.CustomAudiencesClient.GetCustomAudiencesIterator(new GetCustomAudiencesParameters() {
                AccountId = "ACCOUNT_ID"
            });

            while (!iterator.Completed)
            {
                var customAudienceResponse = iterator.NextPageAsync().GetAwaiter().GetResult();
                foreach (CustomAudience customAudience in customAudienceResponse?.Content?.CustomAudiences)
                {
                    System.Console.WriteLine($"This is the id: {customAudience.Id}");
                    System.Console.WriteLine($"This is the targetable: {customAudience.Targetable}");
                    System.Console.WriteLine($"This is the name: {customAudience.Name}");
                    System.Console.WriteLine($"This is the targetable_types: {customAudience.TargetableTypes}");
                    System.Console.WriteLine($"This is the audience_type: {customAudience.AudienceType}");
                    System.Console.WriteLine($"This is the description: {customAudience.Description}");
                    System.Console.WriteLine($"This is the permission_level: {customAudience.PermissionLevel}");
                    System.Console.WriteLine($"This is the owner_account_id: {customAudience.OwnerAccountId}");
                    System.Console.WriteLine($"This is the reasons_not_targetable: {customAudience.ReasonsNotTargetable}");
                    System.Console.WriteLine($"This is the created_at: {customAudience.CreatedAt}");
                    System.Console.WriteLine($"This is the updated_at: {customAudience.UpdatedAt}");
                    System.Console.WriteLine($"This is the partner_source: {customAudience.PartnerSource}");
                    System.Console.WriteLine($"This is the deleted: {customAudience.Deleted}");
                    System.Console.WriteLine($"This is the audience_size: {customAudience.AudienceSize}");
                }
            }
        }
    }
}
