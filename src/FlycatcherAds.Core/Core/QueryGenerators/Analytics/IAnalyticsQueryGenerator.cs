using FlycatcherAds.Parameters;

namespace FlycatcherAds.Core.QueryGenerators
{
    public interface IAnalyticsQueryGenerator
    {
        string GetSynchronousAnalyticsQuery(IGetSynchronousAnalyticsParameters parameters);
        
        string GetAsynchronousAnalyticsJobsInfoQuery(IGetAsynchronousAnalyticsJobsParameters parameters);
        
        string CreateAsynchronousAnalyticsJobQuery(ICreateAsynchronousAnalyticsJobParameters parameters);
        
        string DeleteAsynchronousAnalyticsJobQuery(IDeleteAsynchronousAnalyticsJobParameters parameters);
        
        string GetActiveEntitiesQuery(IGetActiveEntitiesParameters parameters);
    }
}
