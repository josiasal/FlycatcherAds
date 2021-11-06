using Tweetinvi.Parameters;

namespace FlycatcherAds.Parameters
{
    public interface IBaseAdsParameters : ICustomRequestParameters
    {
        /// <summary>
        /// Specifies the number of records to try and retrieve per distinct
        /// request.
        /// </summary>
        int? Count { get; set; }

        /// <summary>
        /// Specifies a cursor to get the next page of results. See
        /// <a href="https://developer.twitter.com/en/docs/ads/general/guides/pagination">Pagination</a>
        /// for more information.
        /// </summary>
        string Cursor { get; set; }

         /// <summary>
        /// Sorts by supported attribute in ascending or descending order. See
        /// <a href="https://developer.twitter.com/en/docs/twitter-ads-api/sorting">Sorting</a> for more information.
        /// </summary>
        string SortBy { get; set; }

        /// <summary>
        /// Include deleted results in your request.
        /// </summary>
        bool? WithDeleted { get; set; }

        /// <summary>
        /// Include the total_count response attribute.
        /// </summary>
        bool? WithTotalCount { get; set; }
    }

    public class BaseAdsParameters : CustomRequestParameters, IBaseAdsParameters
    {
        public BaseAdsParameters() {}
        public BaseAdsParameters(IBaseAdsParameters parameters) : base(parameters)
        {
            Count = parameters.Count;
            Cursor = parameters.Cursor;
            SortBy = parameters.SortBy;
            WithDeleted = parameters.WithDeleted;
            WithTotalCount = parameters.WithTotalCount;
        }

        public int? Count { get; set; }
        public string Cursor { get; set; }
        public string SortBy { get; set; }
        public bool? WithDeleted { get; set; }
        public bool? WithTotalCount { get; set; }
    }
}
