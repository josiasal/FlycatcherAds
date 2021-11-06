using System.Collections.Generic;

namespace FlycatcherAds.Parameters
{
    public interface IGetAdsAccountsParameters : IBaseAdsParameters
    {
        /// <summary>
        /// An optional query to scope resource by name.
        /// </summary>
        string Query { get; set; }

        /// <summary>
        /// Scope the response to just the desired account 
        /// IDs by specifying a comma-separated list of identifiers.
        /// </summary>
        HashSet<string> AccountIds { get; set; }
    }

    public class GetAdsAccountsParameters : BaseAdsParameters, IGetAdsAccountsParameters
    {
        public GetAdsAccountsParameters() : base()
        {
            AccountIds = new HashSet<string>();
        }

        public GetAdsAccountsParameters(IGetAdsAccountsParameters parameters) : base(parameters)
        {
            Query = parameters.Query;
            AccountIds = new HashSet<string>(parameters.AccountIds);
        }

        public string Query { get; set; }
        public HashSet<string> AccountIds { get; set; }
    }
}
