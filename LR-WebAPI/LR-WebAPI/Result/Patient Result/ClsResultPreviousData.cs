using Newtonsoft.Json;

namespace LR_WebAPI
{
    public class ClsResultPreviousData : ClsResultMessage
    {
        public ClsResultPreviousData()
        { }

        [JsonProperty("hn")]
        public string hn { get; set; }

        [JsonProperty("pv_dilate")]
        public string pv_dilate { get; set; }

        [JsonProperty("pv_effacement")]
        public string pv_effacement { get; set; }

        [JsonProperty("pv_membrane")]
        public string pv_membrane { get; set; }

        [JsonProperty("pv_membrane_note")]
        public string pv_membrane_note { get; set; }

        [JsonProperty("pv_station")]
        public string pv_station { get; set; }

        [JsonProperty("pv_present")]
        public string pv_present { get; set; }

        [JsonProperty("pv_present_twin")]
        public string pv_present_twin { get; set; }

        [JsonProperty("fhs")]
        public string fhs { get; set; }

        [JsonProperty("fhs_note")]
        public string fhs_note { get; set; }

        [JsonProperty("fhs_twin")]
        public string fhs_twin { get; set; }

        [JsonProperty("fhs_twin_note")]
        public string fhs_twin_note { get; set; }

        [JsonProperty("utene")]
        public string utene { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("plan")]
        public string plan { get; set; }

        [JsonProperty("note")]
        public string note { get; set; }
    }
}
