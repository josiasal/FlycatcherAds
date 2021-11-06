using FlycatcherAds.Parameters;

namespace FlycatcherAds.Core.QueryGenerators
{
    public interface IPromotedTweetsQueryGenerator
    {
        string GetPromotedTweetsQuery(IGetPromotedTweetsParameters parameters);
    }
}
