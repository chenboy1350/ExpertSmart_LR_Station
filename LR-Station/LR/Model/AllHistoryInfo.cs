using Newtonsoft.Json;
using System.Collections.Generic;

namespace LR_Station
{
    public class AllHistoryInfo
    {
        public string message;
        public int code;

        [JsonProperty(PropertyName = "HistoryList", NullValueHandling = NullValueHandling.Ignore)]
        public List<HistoryList> HistoryList;
    }

    public class HistoryList
    {
        public string hn;
        public string name;
        public string end_with;
        public string end_date;
        public string end_without_date;
        public string end_EFW;
        public string end_AGPAR;
        public string end_Follow;
        public string end_deliver_status;
        public string status;
        public string age;
        public string gpal;
        public string ga;
        public string efw;
        public string efw_twin;
        public string pv_dilate;
        public string pv_effacement;
        public string pv_membrane;
        public string pv_station;
        public string pv_present;
        public string fhs;
        public string utene;

        [JsonProperty(PropertyName = "EvenHistorytList", NullValueHandling = NullValueHandling.Ignore)]
        public List<EvenHistorytList> EvenHistorytList;
    }

    public class EvenHistorytList
    {
        public string hn;
        public string se_id;
        public string datetime;
        public string pv_dilate;
        public string pv_effacement;
        public string pv_membrane;
        public string pv_membrane_note;
        public string pv_station;
        public string pv_present;
        public string pv_present_twin;
        public string fhs;
        public string fhs_note;
        public string fhs_twin;
        public string fhs_twin_note;
        public string utene;
        public string status;
        public string plan;
        public string note;
        public string eventtype;
    }
}