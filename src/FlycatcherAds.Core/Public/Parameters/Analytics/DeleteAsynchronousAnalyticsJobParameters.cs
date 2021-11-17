using Tweetinvi.Parameters;

namespace FlycatcherAds.Parameters
{
    public interface IDeleteAsynchronousAnalyticsJobParameters : ICustomRequestParameters
    {
        /// <summary>
        /// The identifier for the leveraged account. Appears within the resource's 
        /// path and is generally a required parameter for all Advertiser API requests excluding
        /// <a href="/en/docs/ads/campaign-management/api-reference/accounts#get-accounts">GET accounts</a>.
        /// The specified account must be associated with the authenticated user
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// A reference to the job you are operating with in the request.
        /// </summary>
        string JobId { get; set; }
    }

    public class DeleteAsynchronousAnalyticsJobParameters : CustomRequestParameters, IDeleteAsynchronousAnalyticsJobParameters
    {
        public DeleteAsynchronousAnalyticsJobParameters()
        {
        }

        public DeleteAsynchronousAnalyticsJobParameters(string accountId, string jobId)
        {
            AccountId = accountId;
            JobId = jobId;
        }

        public DeleteAsynchronousAnalyticsJobParameters(IDeleteAsynchronousAnalyticsJobParameters parameters) : base(parameters)
        {
            AccountId = parameters.AccountId;
            JobId = parameters.JobId;
        }

        public string AccountId { get; set; }
        public string JobId { get; set; }
    }
}
