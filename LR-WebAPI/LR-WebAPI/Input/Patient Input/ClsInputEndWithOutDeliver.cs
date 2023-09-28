using Newtonsoft.Json;

namespace LR_WebAPI
{
    public class ClsInputEndWithOutDeliver
    {
        [JsonProperty("hn")]
        public string hn { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("Delivery")]
        public string Delivery { get; set; }
    }
}
