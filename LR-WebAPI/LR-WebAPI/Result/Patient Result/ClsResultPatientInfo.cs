using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LR_WebAPI
{
    public class ClsResultPatientInfo : ClsResultMessage
    {
        public ClsResultPatientInfo()
        { }

        [JsonProperty("hn")]
        public string hn { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("age")]
        public string age { get; set; }

        [JsonProperty("gpal")]
        public string gpal { get; set; }

        [JsonProperty("edc")]
        public string edc { get; set; }

        [JsonProperty("ga")]
        public string ga { get; set; }

        [JsonProperty("admit_at")]
        public string admit_at { get; set; }

        [JsonProperty("admit_times")]
        public string admit_times { get; set; }

        [JsonProperty("lab1")]
        public string lab1 { get; set; }

        [JsonProperty("lab1_note")]
        public string lab1_note { get; set; }

        [JsonProperty("lab2")]
        public string lab2 { get; set; }

        [JsonProperty("lab2_note")]
        public string lab2_note { get; set; }

        [JsonProperty("hct1")]
        public string hct1 { get; set; }

        [JsonProperty("hct2")]
        public string hct2 { get; set; }

        [JsonProperty("allergy")]
        public string allergy { get; set; }

        [JsonProperty("allergy_note")]
        public string allergy_note { get; set; }

        [JsonProperty("surgery")]
        public string surgery { get; set; }

        [JsonProperty("surgery_note")]
        public string surgery_note { get; set; }

        [JsonProperty("uc")]
        public string uc { get; set; }

        [JsonProperty("uc_note")]
        public string uc_note { get; set; }

        [JsonProperty("risk")]
        public string risk { get; set; }

        [JsonProperty("risk_note")]
        public string risk_note { get; set; }

        [JsonProperty("covid_status")]
        public string covid_status { get; set; }

        public List<ClsAnc> AncList { get; set; }
    }

    [Serializable]
    public class ClsAnc
    {
        public ClsAnc()
        { }

        [JsonProperty("hn")]
        public string hn { get; set; }

        [JsonProperty("anc_id")]
        public string anc_id { get; set; }

        [JsonProperty("anc_at")]
        public string anc_at { get; set; }

        [JsonProperty("anc_times")]
        public string anc_times { get; set; }

        [JsonProperty("anc_case_state")]
        public string anc_case_state { get; set; }

    }
}
