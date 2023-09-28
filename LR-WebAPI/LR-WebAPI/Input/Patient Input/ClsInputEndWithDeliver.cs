using Newtonsoft.Json;

namespace LR_WebAPI
{
    public class ClsInputEndWithDeliver
    {
        [JsonProperty("hn")]
        public string hn { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("EFW")]
        public string EFW { get; set; }

        [JsonProperty("AGPAR")]
        public string AGPAR { get; set; }

        [JsonProperty("Follow")]
        public string Follow { get; set; }
    }
}
