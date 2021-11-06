using FlycatcherAds.Parameters;

namespace FlycatcherAds.Core.QueryGenerators
{
    public interface ICampaignsQueryGenerator
    {
        string GetCampaignsQuery(IGetCampaignsParameters parameters);
    }
}
