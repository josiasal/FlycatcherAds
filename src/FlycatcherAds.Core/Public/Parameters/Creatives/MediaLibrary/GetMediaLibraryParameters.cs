using Newtonsoft.Json;

using Tweetinvi.Parameters;

namespace FlycatcherAds.Parameters
{
    public interface IGetMediaLibraryParameters : ICustomRequestParameters
    {
        /// <summary>
        /// The identifier for the leveraged account. Appears within the resource's path and is generally a
        /// required parameter for all Advertiser API requests excluding
        /// <a href="/en/docs/ads/campaign-management/api-reference/accounts#get-accounts">GET accounts</a>
        /// The specified account must be associated with the authenticated user
        /// </summary>
        [JsonProperty("account_id")] string AccountId { get; set; }
        
        /// <summary>
        /// Specifies the number of records to try and retrieve per distinct request
        /// </summary>
        [JsonProperty("count")] int? Count { get; set; }

        /// <summary>
        /// Specifies a cursor to get the next page of results. See
        /// <a href="/en/docs/ads/general/guides/pagination">Pagination</a> for more information.
        /// </summary>
        [JsonProperty("cursor")] string Cursor { get; set; }

        /// <summary>
        /// Scope the response to just the desired media type.
        /// Possible values: GIF, IMAGE, VIDEO
        /// </summary>
        [JsonProperty("q")] string Query { get; set; }

        /// <summary>
        /// An optional query to scope resource by name, title, file_name,
        /// and description fields.
        /// Note: This performs case-insensitive <em>term</em> matching.
        /// Min, Max length: 1, 255
        /// </summary>
        [JsonProperty("media_type")] string MediaType { get; set; }
    }

    public class GetMediaLibraryParameters : CustomRequestParameters, IGetMediaLibraryParameters
    {
        public GetMediaLibraryParameters() {}

        public GetMediaLibraryParameters(IGetMediaLibraryParameters parameters)
        {
            AccountId = parameters.AccountId;
            Count = parameters.Count;
            Cursor = parameters.Cursor;
            Query = parameters.Query;
            MediaType = parameters.MediaType;
        }

        public string AccountId { get; set; }
        public int? Count { get; set; }
        public string Cursor { get; set; }
        public string Query { get; set; }
        public string MediaType { get; set; }
    }
}
