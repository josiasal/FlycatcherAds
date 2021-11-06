using Tweetinvi.Core.Injectinvi;

using FlycatcherAds.Client;

namespace FlycatcherAds
{
    public class FlycatcherAdsModule : ITweetinviModule
    {
        /// <summary>
        /// Initialize the module registration.
        /// </summary>
        public void Initialize(ITweetinviContainer container)
        {
            // Campaign Management
            container.RegisterType<IAdsAccountsClient, AdsAccountsClient>();
            container.RegisterType<IAdsAccountsRequester, AdsAccountsRequester>();
         
            container.RegisterType<IPromotedTweetsClient, PromotedTweetsClient>();
            container.RegisterType<IPromotedTweetsRequester, PromotedTweetsRequester>();

            container.RegisterType<ICampaignsClient, CampaignsClient>();
            container.RegisterType<ICampaignsRequester, CampaignsRequester>();

            // Analytics
            container.RegisterType<ISynchronousAnalyticsClient, SynchronousAnalyticsClient>();
            container.RegisterType<ISynchronousAnalyticsRequester, SynchronousAnalyticsRequester>();

            // Creatives
            container.RegisterType<IMediaLibraryClient, MediaLibraryClient>();
            container.RegisterType<IMediaLibraryRequester, MediaLibraryRequester>();
        }
    }
}
