using Tweetinvi;

using FlycatcherAds.Client;

namespace FlycatcherAds
{
    public interface ITwitterAdsClient : ITwitterClient
    {
        IAdsAccountsClient AdsAccountsClient { get; }
        ICampaignsClient CampaignsClient { get; }
        IPromotedTweetsClient PromotedTweetsClient { get; }
        ISynchronousAnalyticsClient SynchronousAnalyticsClient { get; }
        IMediaLibraryClient MediaLibraryClient { get; }
    }
}
