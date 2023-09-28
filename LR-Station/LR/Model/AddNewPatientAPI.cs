using System.Collections.Generic;

namespace LR_Station
{
    public class AddNewPatientAPI
    {
        public string hn;
        public string name;
        public string age;
        public string gpal;
        public string edc;
        public string ga;
        public string admit_at;
        public string admit_times;
        public string bed;

        public List<ANC_List> ANC_list;

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

        public string datetime;
        public string chief_complaint;
        public string vs;
        public string baby_weight;
        public string baby_weight_twin;
        public string baby_fhs;
        public string baby_fhs_note;
        public string baby_fhs_twin;
        public string baby_fhs_twin_note;
        public string utene;
        public string pv_diate;
        public string pv_effacement;
        public string pv_membrane;
        public string pv_membrane_note;
        public string pv_present;
        public string pv_present_twin;
        public string pv_station;
        public string plan;
        public string status;
        public string note;

        public class ANC_List
        {
            public string anc_at;
            public string anc_times;
        }
    }
}