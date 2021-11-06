using Newtonsoft.Json;

namespace FlycatcherAds.Models
{
    /// <summary>
    /// A hashtag is a keyword prefixed by # and representing a category of tweet
    /// This class stores information related with an user mention
    /// </summary>
    public class HashtagEntity
    {
        [JsonProperty("text")] public string Text { get; set; }
        [JsonProperty("indices")] public int[] Indices { get; set; }

        public override string ToString()
        {
            return $"#{Text}";
        }
    }
}
