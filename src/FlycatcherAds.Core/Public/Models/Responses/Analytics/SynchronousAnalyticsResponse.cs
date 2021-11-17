using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class SynchronousAnalyticsResponse
    {
        [JsonProperty("data_type")] public string DataType { get; set; }
        [JsonProperty("time_series_length")] public int TimeSeriesLength { get; set; }
        [JsonProperty("data")] public StatisticsData[] StatisticsData { get; set; }
    }
}
