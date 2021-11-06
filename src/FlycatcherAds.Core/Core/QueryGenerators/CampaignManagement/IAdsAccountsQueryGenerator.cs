using FlycatcherAds.Parameters;

namespace FlycatcherAds.Core.QueryGenerators
{
    public interface IAdsAccountsQueryGenerator
    {
        string GetAdsAccountsQuery(IGetAdsAccountsParameters parameters);
    }
}
