using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LR_WebAPI
{
    public class ClsResultAllHistory : ClsResultMessage
    {
        public ClsResultAllHistory()
        { }

        public List<ClsAllHistoryInfo> HistoryList { get; set; }
    }

    [Serializable]
    public class ClsAllHistoryInfo
    {
        public ClsAllHistoryInfo()
        { }

        [JsonProperty("hn")]
        public string hn { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("end_with")]
        public string end_with { get; set; }

        [JsonProperty("end_date")]
        public string end_date { get; set; }

        [JsonProperty("end_without_date")]
        public string end_without_date { get; set; }

        [JsonProperty("end_EFW")]
        public string end_EFW { get; set; }

        [JsonProperty("end_AGPAR")]
        public string end_AGPAR { get; set; }

        [JsonProperty("end_Follow")]
        public string end_Follow { get; set; }

        [JsonProperty("end_deliver_status")]
        public string end_deliver_status { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("age")]
        public string age { get; set; }

        [JsonProperty("gpal")]
        public string gpal { get; set; }

        [JsonProperty("ga")]
        public string ga { get; set; }

        [JsonProperty("efw")]
        public string efw { get; set; }

        [JsonProperty("efw_twin")]
        public string efw_twin { get; set; }

        [JsonProperty("pv_dilate")]
        public string pv_dilate { get; set; }

        [JsonProperty("pv_effacement")]
        public string pv_effacement { get; set; }

        [JsonProperty("pv_membrane")]
        public string pv_membrane { get; set; }

        [JsonProperty("pv_station")]
        public string pv_station { get; set; }

        [JsonProperty("pv_present")]
        public string pv_present { get; set; }

        [JsonProperty("fhs")]
        public string fhs { get; set; }

        [JsonProperty("utene")]
        public string utene { get; set; }

        public List<ClsEventHistory> EvenHistorytList { get; set; }
    }

    [Serializable]
    public class ClsEventHistory
    {
        public ClsEventHistory()
        { }

        [JsonProperty("hn")]
        public string hn { get; set; }

        [JsonProperty("se_id")]
        public string se_id { get; set; }

        [JsonProperty("datetime")]
        public string datetime { get; set; }

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

        [JsonProperty("eventtype")]
        public string eventtype { get; set; }
    }

}
