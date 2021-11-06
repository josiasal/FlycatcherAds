using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class Coordinates
    {
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("coordinates")] public double[] LatLon { get; set; }
    }
}
