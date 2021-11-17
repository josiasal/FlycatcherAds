using Tweetinvi.Core.Injectinvi;

using FlycatcherAds.Core.Controllers;
using FlycatcherAds.Core.QueryGenerators;
using FlycatcherAds.Controllers;


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
            container.RegisterType<ILineItemsController, LineItemsController>();
            
            // Analytics
            container.RegisterType<IAnalyticsController, AnalyticsController>();

            // Creatives
            container.RegisterType<IMediaLibraryController, MediaLibraryController>();

            // Audiences
            container.RegisterType<ICustomAudiencesController, CustomAudiencesController>();
        }

        private void InitializeQueryExecutors(ITweetinviContainer container)
        {
            // Campaign Management
            container.RegisterType<IAdsAccountsQueryExecutor, AdsAccountsQueryExecutor>();
            container.RegisterType<ICampaignsQueryExecutor, CampaignsQueryExecutor>();
            container.RegisterType<IPromotedTweetsQueryExecutor, PromotedTweetsQueryExecutor>();
            container.RegisterType<ILineItemsQueryExecutor, LineItemsQueryExecutor>();

            // Analytics
            container.RegisterType<IAnalyticsQueryExecutor, AnalyticsQueryExecutor>();

            // Creatives
            container.RegisterType<IMediaLibraryQueryExecutor, MediaLibraryQueryExecutor>();

            // Audiences
            container.RegisterType<ICustomAudiencesQueryExecutor, CustomAudiencesQueryExecutor>();

        }

        private void InitializeQueryGenerators(ITweetinviContainer container)
        {
            // Campaign Management
            container.RegisterType<IAdsAccountsQueryGenerator, AdsAccountsQueryGenerator>();
            container.RegisterType<ICampaignsQueryGenerator, CampaignsQueryGenerator>();
            container.RegisterType<IPromotedTweetsQueryGenerator, PromotedTweetsQueryGenerator>();
            container.RegisterType<ILineItemsQueryGenerator, LineItemsQueryGenerator>();

            // Analytics
            container.RegisterType<IAnalyticsQueryGenerator, AnalyticsQueryGenerator>();

            // Creatives
            container.RegisterType<IMediaLibraryQueryGenerator, MediaLibraryQueryGenerator>();

            // Audiences
            container.RegisterType<ICustomAudiencesQueryGenerator, CustomAudiencesQueryGenerator>();
        }
    }
}
