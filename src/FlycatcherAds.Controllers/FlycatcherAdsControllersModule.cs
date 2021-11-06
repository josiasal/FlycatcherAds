using Tweetinvi.Core.Injectinvi;

using FlycatcherAds.Core.Controllers;
using FlycatcherAds.Controllers.AdsAccount;
using FlycatcherAds.Core.QueryGenerators;

namespace FlycatcherAds.Controllers
{
    public class FlycatcherAdsControllersModule : ITweetinviModule
    {
        public void Initialize(ITweetinviContainer container)
        {
            InitializeControllers(container);
            InitializeQueryExecutors(container);
            InitializeQueryGenerators(container);
        }

        private void InitializeControllers(ITweetinviContainer container)
        {
            // Campaign Management
            container.RegisterType<IAdsAccountsController, AdsAccountsController>();
            container.RegisterType<ICampaignsController, CampaignsController>();
            container.RegisterType<IPromotedTweetsController, PromotedTweetsController>();
            
            // Analytics
            container.RegisterType<ISynchronousAnalyticsController, SynchronousAnalyticsController>();

            // Creatives
            container.RegisterType<IMediaLibraryController, MediaLibraryController>();
        }

        private void InitializeQueryExecutors(ITweetinviContainer container)
        {
            // Campaign Management
            container.RegisterType<IAdsAccountsQueryExecutor, AdsAccountsQueryExecutor>();
            container.RegisterType<ICampaignsQueryExecutor, CampaignsQueryExecutor>();
            container.RegisterType<IPromotedTweetsQueryExecutor, PromotedTweetsQueryExecutor>();

            // Analytics
            container.RegisterType<ISynchronousAnalyticsQueryExecutor, SynchronousAnalyticsQueryExecutor>();

            // Creatives
            container.RegisterType<IMediaLibraryQueryExecutor, MediaLibraryQueryExecutor>();

        }

        private void InitializeQueryGenerators(ITweetinviContainer container)
        {
            // Campaign Management
            container.RegisterType<IAdsAccountsQueryGenerator, AdsAccountsQueryGenerator>();
            container.RegisterType<ICampaignsQueryGenerator, CampaignsQueryGenerator>();
            container.RegisterType<IPromotedTweetsQueryGenerator, PromotedTweetsQueryGenerator>();

            // Analytics
            container.RegisterType<ISynchronousAnalyticsQueryGenerator, SynchronousAnalyticsQueryGenerator>();

            // Creatives
            container.RegisterType<IMediaLibraryQueryGenerator, MediaLibraryQueryGenerator>();
        }
    }
}