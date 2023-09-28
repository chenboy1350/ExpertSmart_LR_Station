using Newtonsoft.Json;
using System.Collections.Generic;

namespace LR_Station
{
    public class AllPatientInfo
    {
        public string message;
        public int code;

        [JsonProperty(PropertyName = "PatienList", NullValueHandling = NullValueHandling.Ignore)]
        public List<PatienList> PatienList;
    }

    public class PatienList
    {
        public string hn;
        public string name;
        public int bed;
        public string zone;
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

        [JsonProperty(PropertyName = "EventList", NullValueHandling = NullValueHandling.Ignore)]
        public List<EventList> EventList;
    }

    public class EventList
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