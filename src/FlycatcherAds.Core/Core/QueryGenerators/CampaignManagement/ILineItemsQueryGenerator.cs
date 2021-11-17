using FlycatcherAds.Parameters;

namespace FlycatcherAds.Core.QueryGenerators
{
    public interface ILineItemsQueryGenerator
    {
        string GetLineItemsQuery(IGetLineItemsParameters parameters);
    }
}
