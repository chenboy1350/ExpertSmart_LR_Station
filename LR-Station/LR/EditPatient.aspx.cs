using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LR_Station
{
    public partial class EditPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString.Count > 0)
                    {
                        txtHN.Text = Request.QueryString["hn"].ToString();
                        txtNAME.Text = Request.QueryString["name"].ToString();
                        ShowPatientInfo(Request.QueryString["hn"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        private async void ShowPatientInfo(string hn)
        {
            try
            {
                if ((txtHN.Text != string.Empty && txtNAME.Text != string.Empty) || (txtHN.Text != null && txtNAME.Text != null))
                {
                    AddEventAPI parameter = new AddEventAPI()
                    {
                        hn = hn
                    };

                    PatientInfo dataResult = new PatientInfo();
                    string responseBody = "";
                    string JsonData = JsonConvert.SerializeObject(parameter);
                    var buffer = Encoding.UTF8.GetBytes(JsonData);
                    var bytes = new ByteArrayContent(buffer);
                    bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        string RestURL = string.Format("{0}/GetPatientInfo/", LR.Properties.Settings.Default.API);
                        var response = await client.PostAsync(RestURL, bytes);
                        responseBody = await response.Content.ReadAsStringAsync();
                    }
                    dataResult = JsonConvert.DeserializeObject<PatientInfo>(responseBody);

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
                        txtAdmitTimes.Value = dataResult.admit_times;
                        txtAge.Value = dataResult.age;
                        txtGPAL.Value = dataResult.gpal;
                        txtEDC.Value = dataResult.edc;
                        txtGA.Text = dataResult.ga;

                        if (dataResult.lab1 == "1")
                        {
                            chxLAB1.Checked = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle1", "document.getElementById('onchangeToggle1').style.display = 'block';", true);
                        }
                        else
                        {
                            chxLAB1.Checked = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle1", "document.getElementById('onchangeToggle1').style.display = 'none';", true);
                        }
                        txtLAB1Note.Value = dataResult.lab1_note;

                        if (dataResult.lab2 == "1")
                        {
                            chxLAB2.Checked = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle2", "document.getElementById('onchangeToggle2').style.display = 'block';", true);
                        }
                        else
                        {
                            chxLAB2.Checked = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle2", "document.getElementById('onchangeToggle2').style.display = 'none';", true);
                        }
                        txtLAB2Note.Value = dataResult.lab2_note;

                        txtHCT1.Value = dataResult.hct1;
                        txtHCT2.Value = dataResult.hct2;

                        if(dataResult.allergy == "1")
                        {
                            chxAllergy.Checked = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle3", "document.getElementById('onchangeToggle3').style.display = 'block';", true);
                        }
                        else
                        {
                            chxAllergy.Checked = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle3", "document.getElementById('onchangeToggle3').style.display = 'none';", true);
                        }
                        txtAllergyNote.Value = dataResult.allergy_note;

                        if (dataResult.surgery == "1")
                        {
                            chxSurgery.Checked = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle4", "document.getElementById('onchangeToggle4').style.display = 'block';", true);
                        }
                        else
                        {
                            chxSurgery.Checked = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle4", "document.getElementById('onchangeToggle4').style.display = 'none';", true);
                        }
                        txtSurgeryNote.Value = dataResult.surgery_note;

                        if (dataResult.uc == "1")
                        {
                            chxUnD.Checked = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle5", "document.getElementById('onchangeToggle5').style.display = 'block';", true);
                        }
                        else
                        {
                            chxUnD.Checked = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle5", "document.getElementById('onchangeToggle5').style.display = 'none';", true);
                        }
                        txtUndNote.Value = dataResult.uc_note;

                        if (dataResult.risk == "1")
                        {
                            chxRick.Checked = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle6", "document.getElementById('onchangeToggle6').style.display = 'block';", true);
                        }
                        else
                        {
                            chxRick.Checked = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toggle6", "document.getElementById('onchangeToggle6').style.display = 'none';", true);
                        }
                        txtRickNote.Value = dataResult.risk_note;
                        cbxCovidState.Value = dataResult.covid_status;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void EditPatientInfo()
        {
            try
            {
                EditPatientInfo parameter = new EditPatientInfo();

                parameter = new EditPatientInfo
                {
                    admit_times = txtAdmitTimes.Value,
                    hn = txtHN.Text,
                    name = txtNAME.Text,
                    age = txtAge.Value,
                    gpal = txtGPAL.Value,
                    edc = txtEDC.Value,
                    ga = txtGA.Text,
                    lab1_note = txtLAB1Note.Value,
                    lab2_note = txtLAB2Note.Value,
                    hct1 = txtHCT1.Value,
                    hct2 = txtHCT2.Value,
                    allergy_note = txtAllergyNote.Value,
                    surgery_note = txtSurgeryNote.Value,
                    uc_note = txtUndNote.Value,
                    risk_note = txtRickNote.Value,
                    covid_status = cbxCovidState.Value,
                };

                if (chxLAB1.Checked) { parameter.lab1 = "1"; } else { parameter.lab1 = "0"; }
                if (chxLAB2.Checked) { parameter.lab2 = "1"; } else { parameter.lab2 = "0"; }
                if (chxAllergy.Checked) { parameter.allergy = "1"; } else { parameter.allergy = "0"; }
                if (chxSurgery.Checked) { parameter.surgery = "1"; } else { parameter.surgery = "0"; }
                if (chxUnD.Checked) { parameter.uc = "1"; } else { parameter.uc = "0"; }
                if (chxRick.Checked) { parameter.risk = "1"; } else { parameter.risk = "0"; }

                MsgResult dataResult = new MsgResult();
                string responseBody = "";
                string JsonData = JsonConvert.SerializeObject(parameter);
                var buffer = Encoding.UTF8.GetBytes(JsonData);
                var bytes = new ByteArrayContent(buffer);
                bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpClient client = new HttpClient())
                {
                    string RestURL = string.Format("{0}/EditPatientInfo/", LR.Properties.Settings.Default.API);
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
            catch (Exception ex)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EditPatientInfo();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Event.aspx");
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Response.Redirect("Event.aspx");
        }

        protected void btnDiscard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Event.aspx");
        }

        protected void btnCalGA_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime EDC = Convert.ToDateTime(txtEDC.Value);
                TimeSpan now = EDC - DateTime.Now.Date;
                double days = Math.Abs(now.Days);
                double GA1 = 280 - days;
                double GA2 = GA1 / 7;

                if (GA2.ToString("N2").Length == 5)
                {
                    string GA3 = GA2.ToString("N2").Substring(2, 3);
                    double GA4 = Math.Round(Convert.ToDouble(GA3) * 7);
                    txtGA.Text = string.Format(GA2.ToString("N0") + "+" + GA4.ToString() + "Weeks");
                }
                else if (GA2.ToString("N2").Length == 4)
                {
                    string GA3 = GA2.ToString("N2").Substring(1, 3);
                    double GA4 = Math.Round(Convert.ToDouble(GA3) * 7);
                    txtGA.Text = string.Format(GA2.ToString("N2").Substring(0, 1) + "+" + GA4.ToString() + " Weeks");
                }
            }
            catch (Exception ex)
            {
                txtGA.Text = ex.ToString();
            }
        }
    }
}