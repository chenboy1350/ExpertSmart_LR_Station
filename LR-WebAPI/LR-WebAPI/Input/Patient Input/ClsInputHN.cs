using Newtonsoft.Json;

namespace LR_WebAPI
{
    public class ClsInputHN
    {
        [JsonProperty("hn")]
        public string hn { get; set; }
    }
}
