using FlycatcherAds.Parameters;

namespace FlycatcherAds.Core.QueryGenerators
{
    public interface ICustomAudiencesQueryGenerator
    {
        string GetCustomAudiencesQuery(IGetCustomAudiencesParameters parameters);
    }
}
