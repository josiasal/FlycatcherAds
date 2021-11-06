using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    public class SymbolEntity
    {
        [JsonProperty("text")] public string Text { get; set; }
        [JsonProperty("indices")] public int[] Indices { get; set; }

        public override string ToString()
        {
            return $"{Text}";
        }
    }
}
