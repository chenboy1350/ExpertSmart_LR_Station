using Newtonsoft.Json;
using System.Collections.Generic;

namespace LR_Station
{
    public class PatientInfo
    {
        public string hn;
        public string name;
        public string age;
        public string gpal;
        public string edc;
        public string ga;
        public string admit_at;
        public string admit_times;
        public string lab1;
        public string lab1_note;
        public string lab2;
        public string lab2_note;
        public string hct1;
        public string hct2;
        public string allergy;
        public string allergy_note;
        public string surgery;
        public string surgery_note;
        public string uc;
        public string uc_note;
        public string risk;
        public string risk_note;
        public string covid_status;

        public string message;
        public int code;

        [JsonProperty(PropertyName = "ancList", NullValueHandling = NullValueHandling.Ignore)]
        public List<ancList> ancList;
    }

    public class ancList
    {
        public string hn;
        public string anc_id;
        public string anc_at;
        public string anc_times;
        public string anc_case_state;
    }
}