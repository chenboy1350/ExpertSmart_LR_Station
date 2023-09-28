using Newtonsoft.Json;

namespace LR_WebAPI
{
    public class ClsInputMoveBed
    {
        [JsonProperty("hn")]
        public string hn { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("curZone")]
        public string curZone { get; set; }

        [JsonProperty("curBed")]
        public string curBed { get; set; }

        [JsonProperty("toZone")]
        public string toZone { get; set; }

        [JsonProperty("toBed")]
        public string toBed { get; set; }
    }
}
