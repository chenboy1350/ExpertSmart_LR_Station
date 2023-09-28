using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LR_WebAPI
{
    public class ClsInputRegisterNewPatient
    {
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

        [JsonProperty("bed")]
        public string bed { get; set; }

        [JsonProperty("ANC_list")]
        public List<ClsInputANC> ANC_list { get; set; }

        public class ClsInputANC
        {
            [JsonProperty("anc_at")]
            public string anc_at { get; set; }

            [JsonProperty("anc_times")]
            public string anc_times { get; set; }
        }

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

        [JsonProperty("datetime")]
        public string datetime { get; set; }

        [JsonProperty("chief_complaint")]
        public string chief_complaint { get; set; }

        [JsonProperty("vs")]
        public string vs { get; set; }

        [JsonProperty("baby_weight")]
        public string baby_weight { get; set; }

        [JsonProperty("baby_weight_twin")]
        public string baby_weight_twin { get; set; }

        [JsonProperty("baby_fhs")]
        public string baby_fhs { get; set; }

        [JsonProperty("baby_fhs_note")]
        public string baby_fhs_note { get; set; }

        [JsonProperty("baby_fhs_twin")]
        public string baby_fhs_twin { get; set; }

        [JsonProperty("baby_fhs_twin_note")]
        public string baby_fhs_twin_note { get; set; }

        [JsonProperty("utene")]
        public string utene { get; set; }

        [JsonProperty("pv_dilate")]
        public string pv_diate { get; set; }

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

        [JsonProperty("plan")]
        public string plan { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("note")]
        public string note { get; set; }
    }
}