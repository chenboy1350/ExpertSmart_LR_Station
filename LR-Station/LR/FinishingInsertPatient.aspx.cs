using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using static LR_Station.AddNewPatientAPI;

namespace LR_Station
{
    public partial class FinishingInsertPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    AddNewPatientAPI();
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        private async void AddNewPatientAPI()
        {
            try
            {

                AddNewPatientAPI parameter = new AddNewPatientAPI();
                if (Session["patient_info"] != null && Session["first_event"] != null)
                {
                    String[] patient_info = (String[])Session["patient_info"];
                    String[] first_event = (String[])Session["first_event"];

                    var now = DateTime.Now.ToString("HH:mm:ss");
                    string datetime = string.Format("{0} {1}", first_event[0], now);

                    List<ANC_List> anc_List = (List<ANC_List>)Session["ANC_List"];

                    parameter = new AddNewPatientAPI
                    {
                        admit_at = patient_info[0],
                        bed = patient_info[1],
                        admit_times = patient_info[2],
                        hn = patient_info[3],
                        name = patient_info[4],
                        age = patient_info[5],
                        gpal = patient_info[6],
                        edc = patient_info[7],
                        ga = patient_info[8],

                        ANC_list = anc_List,

                        lab1 = patient_info[9],
                        lab1_note = patient_info[10],
                        lab2 = patient_info[11],
                        lab2_note = patient_info[12],
                        hct1 = patient_info[13],
                        hct2 = patient_info[14],
                        allergy = patient_info[15],
                        allergy_note = patient_info[16],
                        surgery = patient_info[17],
                        surgery_note = patient_info[18],
                        uc = patient_info[19],
                        uc_note = patient_info[20],
                        risk = patient_info[21],
                        risk_note = patient_info[22],
                        covid_status = patient_info[23],

                        datetime = datetime,
                        chief_complaint = first_event[1],
                        vs = first_event[2],
                        baby_weight = first_event[3],
                        baby_weight_twin = first_event[4],
                        baby_fhs = first_event[5],
                        baby_fhs_note = first_event[6],
                        baby_fhs_twin = first_event[7],
                        baby_fhs_twin_note = first_event[8],
                        utene = first_event[9],
                        pv_diate = first_event[10],
                        pv_effacement = first_event[11],
                        pv_membrane = first_event[12],
                        pv_membrane_note = first_event[13],
                        pv_present = first_event[14],
                        pv_present_twin = first_event[15],
                        pv_station = first_event[16],
                        plan = first_event[17],
                        status = first_event[18],
                        note = first_event[19]
                    };
                }

                MsgResult dataResult = new MsgResult();
                string responseBody = "";
                string JsonData = JsonConvert.SerializeObject(parameter);
                var buffer = Encoding.UTF8.GetBytes(JsonData);
                var bytes = new ByteArrayContent(buffer);
                bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpClient client = new HttpClient())
                {
                    string RestURL = string.Format("{0}/RegisterNewPatient/", LR.Properties.Settings.Default.API);
                    var response = await client.PostAsync(RestURL, bytes);
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                dataResult = JsonConvert.DeserializeObject<MsgResult>(responseBody);

                if (dataResult == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Modal_Danger", "$(window).on('load', function () { $('#DialogIconedDanger').modal('show'); }); ", true);
                    return;
                }
                else if (dataResult.code == 400)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Modal_Danger", "$(window).on('load', function () { $('#DialogIconedDanger').modal('show'); }); ", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Modal_Success", "$(window).on('load', function () { $('#DialogIconedSuccess').modal('show'); }); ", true);
                    return;
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }

        protected void btnTryAgain_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPatientInfo.aspx");
        }

        protected void btnDiscard_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }
    }
}