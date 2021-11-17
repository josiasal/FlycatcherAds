using Tweetinvi;

using FlycatcherAds.Client;

namespace FlycatcherAds
{
    public interface ITwitterAdsClient : ITwitterClient
    {
        IAdsAccountsClient AdsAccountsClient { get; }
        ICampaignsClient CampaignsClient { get; }
        IPromotedTweetsClient PromotedTweetsClient { get; }
        ILineItemsClient LineItemsClient { get; }
        IAnalyticsClient AnalyticsClient { get; }
        IMediaLibraryClient MediaLibraryClient { get; }
        ICustomAudiencesClient CustomAudiencesClient { get; }
    }
}
