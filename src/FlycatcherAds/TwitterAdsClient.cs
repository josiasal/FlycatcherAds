using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Core.Injectinvi;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Client;
using Tweetinvi.Core.RateLimit;
using Tweetinvi.Events;

using FlycatcherAds.Client;
using FlycatcherAds.Controllers;

namespace FlycatcherAds
{
    public class TwitterAdsClient : TwitterClient, ITwitterAdsClient
    {
        private readonly ITweetinviContainer _tweetinviContainer;
        private readonly ITwitterClientEvents _twitterClientEvents;

        public TwitterAdsClient(ReadOnlyTwitterCredentials credentials) : this(credentials, new TwitterClientParameters())
        {
        }

        public TwitterAdsClient(string consumerKey, string consumerSecret) : this(new ReadOnlyTwitterCredentials(consumerKey, consumerSecret), new TwitterClientParameters())
        {
        }

        public TwitterAdsClient(string consumerKey, string consumerSecret, string bearerToken) : this(new ReadOnlyTwitterCredentials(consumerKey, consumerSecret, bearerToken), new TwitterClientParameters())
        {
        }

        public TwitterAdsClient(string consumerKey, string consumerSecret, string accessToken, string accessSecret) : this(new ReadOnlyTwitterCredentials(consumerKey, consumerSecret, accessToken, accessSecret), new TwitterClientParameters())
        {
        }

        public TwitterAdsClient(IReadOnlyTwitterCredentials credentials, TwitterClientParameters parameters) : base(credentials, parameters)
        {
            RegisterCustomModules();

            _tweetinviContainer = new Tweetinvi.Injectinvi.TweetinviContainer(Tweetinvi.TweetinviContainer.Container);
            _tweetinviContainer.RegisterInstance(typeof(TwitterAdsClient), this);
            _tweetinviContainer.RegisterInstance(typeof(ITwitterClient), this);
            _tweetinviContainer.AssociatedClient = this;

            void BeforeRegistrationDelegate(object sender, TweetinviContainerEventArgs args)
            {
                parameters?.RaiseBeforeRegistrationCompletes(args);
            }

            _tweetinviContainer.BeforeRegistrationCompletes += BeforeRegistrationDelegate;
            _tweetinviContainer.Initialize();
            _tweetinviContainer.BeforeRegistrationCompletes -= BeforeRegistrationDelegate;

            _twitterClientEvents = _tweetinviContainer.Resolve<ITwitterClientEvents>();

            var rateLimitCacheManager = _tweetinviContainer.Resolve<IRateLimitCacheManager>();
            rateLimitCacheManager.RateLimitsClient = RateLimits;

            AdsAccountsClient = _tweetinviContainer.Resolve<IAdsAccountsClient>();
            CampaignsClient = _tweetinviContainer.Resolve<ICampaignsClient>();
            PromotedTweetsClient = _tweetinviContainer.Resolve<IPromotedTweetsClient>();
            LineItemsClient = _tweetinviContainer.Resolve<ILineItemsClient>();
            AnalyticsClient = _tweetinviContainer.Resolve<IAnalyticsClient>();
            MediaLibraryClient = _tweetinviContainer.Resolve<IMediaLibraryClient>();
            CustomAudiencesClient = _tweetinviContainer.Resolve<ICustomAudiencesClient>();
        }

        private void RegisterCustomModules()
        {
            Tweetinvi.TweetinviContainer.AddModule(new FlycatcherAdsModule());
            Tweetinvi.TweetinviContainer.AddModule(new FlycatcherAdsControllersModule());
        }

        public IAdsAccountsClient AdsAccountsClient { get; }
        public ICampaignsClient CampaignsClient { get; }
        public IPromotedTweetsClient PromotedTweetsClient { get; }
        public ILineItemsClient LineItemsClient { get; }
        public IAnalyticsClient AnalyticsClient { get; }
        public IMediaLibraryClient MediaLibraryClient { get; }
        public ICustomAudiencesClient CustomAudiencesClient { get; }

        new public ITwitterExecutionContext CreateTwitterExecutionContext()
        {
            return new TwitterExecutionContext
            {
                RequestFactory = CreateRequest,
                Container = _tweetinviContainer,
                Events = _twitterClientEvents
            };
        }
    }
}
