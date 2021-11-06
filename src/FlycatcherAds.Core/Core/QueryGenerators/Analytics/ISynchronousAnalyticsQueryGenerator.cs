using FlycatcherAds.Parameters;

namespace FlycatcherAds.Core.QueryGenerators
{
    public interface ISynchronousAnalyticsQueryGenerator
    {
        string GetSynchronousAnalyticsQuery(IGetSynchronousAnalyticsParameters parameters);
    }
}
