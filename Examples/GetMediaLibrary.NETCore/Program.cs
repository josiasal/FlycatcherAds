using Tweetinvi;
using Tweetinvi.Models;
using FlycatcherAds;
using FlycatcherAds.Parameters;
using FlycatcherAds.Models;

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

            var iterator = client.MediaLibraryClient.GetMediaLibraryIterator(new GetMediaLibraryParameters(){
                AccountId = "ACCOUNT_ID"
            });

            while (!iterator.Completed)
            {
                var mediaLibraryResponse = iterator.NextPageAsync().GetAwaiter().GetResult();
                foreach (var mediaLibrary in mediaLibraryResponse?.Content?.MediaLibraries)
                {
                    var type = mediaLibrary.GetType();

                    if (type == typeof(ImageLibrary))
                    {
                        var imageLibrary = mediaLibrary as ImageLibrary;
                        System.Console.WriteLine($"Image Library: {imageLibrary.MediaKey} -> {imageLibrary.OriginalWidth}");
                    }
                    else if (type == typeof(VideoLibrary))
                    {
                        var videoLibrary = mediaLibrary as VideoLibrary;
                        System.Console.WriteLine($"Video Library: {videoLibrary.MediaKey} -> {videoLibrary.PosterMediaUrl}");
                    }
                }
            }
        }
    }
}
