using System.Collections.Generic;

using FlycatcherAds.Models;

namespace FlycatcherAds.Parameters
{
    public interface IGetCustomAudiencesParameters : IBaseAdsParameters
    {
        /// <summary>
        /// The identifier for the leveraged account. Appears within the 
        /// resource's path and is generally a required parameter for all 
        /// Advertiser API requests excluding GET accounts.
        ///
        /// The specified account must be associated with the authenticated user.
        /// </summary>
        string AccountId { get; set; }

        /// <summary>
        /// Allows filtering the response to lists you own or lists that have been
        /// shared with you. By default, without specifying this parameter you
        /// will only see audiences you own.
        /// </summary>
        PermissionScope? PermissionScope { get; set; }

        /// <summary>
        ///
        /// </summary>
        HashSet<string> CustomAudienceIds { get; set; }
    }

    public class GetCustomAudiencesParameters : BaseAdsParameters, IGetCustomAudiencesParameters
    {
        public GetCustomAudiencesParameters()
        {
            CustomAudienceIds = new HashSet<string>();
        }

        public GetCustomAudiencesParameters(IGetCustomAudiencesParameters parameters) : base(parameters)
        {
            AccountId = parameters.AccountId;
            PermissionScope = parameters.PermissionScope;
            CustomAudienceIds = new HashSet<string>(parameters.CustomAudienceIds);
        }

        public string AccountId { get; set; }
        public PermissionScope? PermissionScope { get; set; }
        public HashSet<string> CustomAudienceIds { get; set; }
    }
}
