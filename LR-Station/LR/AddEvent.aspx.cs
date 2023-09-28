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

namespace LR_Station
{
    public partial class AddEvent : System.Web.UI.Page
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
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        private async void AddNewEventAPI()
        {
            try
            {
                var now = DateTime.Now.ToString("HH:mm:ss");
                string datetime = string.Format("{0} {1}", txtDateTime.Value, now);
                if ((txtHN.Text != string.Empty && txtNAME.Text != string.Empty)||(txtHN.Text != null && txtNAME.Text != null))
                {
                    AddEventAPI parameter = new AddEventAPI()
                    {
                        hn = txtHN.Text,
                        name = txtNAME.Text,
                        datetime = datetime,
                        baby_fhs = cbxBabyFHS.Value,
                        baby_fhs_note = txtBabyFHS_note.Value,
                        baby_fhs_twin = cbxBabyFHS_twin.Value,
                        baby_fhs_twin_note = txtBabyFHS_twin_note.Value,
                        utene = txtUtenc.Value,
                        pv_dilate = txtPVDilate.Value,
                        pv_effacement = txtPVEfacement.Value,
                        pv_membrane = cbxPVMembrane.Value,
                        pv_membrane_note = txtPVMembrane.Value,
                        pv_present = cbxPVPresent.Value,
                        pv_present_twin = cbxPVPresent_twin.Value,
                        pv_station = cbxPVStation.Value,
                        plan = txtPlan.Value,
                        status = cbxStatus.Value,
                        note = txtNote.Value
                    };

                    if (Request.Form["btnradios"].ToString() != null)
                    {
                        parameter.saveas = Request.Form["btnradios"].ToString();
                    }

                    MsgResult dataResult = new MsgResult();
                    string responseBody = "";
                    string JsonData = JsonConvert.SerializeObject(parameter);
                    var buffer = Encoding.UTF8.GetBytes(JsonData);
                    var bytes = new ByteArrayContent(buffer);
                    bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        string RestURL = string.Format("{0}/InsertNewEvent/", LR.Properties.Settings.Default.API);
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
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddNewEventAPI();
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

        protected async void btnFillPreviousData_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtHN.Text != string.Empty && txtNAME.Text != string.Empty) || (txtHN.Text != null && txtNAME.Text != null))
                {
                    AddEventAPI parameter = new AddEventAPI()
                    {
                        hn = txtHN.Text
                    };

                    PreviousData dataResult = new PreviousData();
                    string responseBody = "";
                    string JsonData = JsonConvert.SerializeObject(parameter);
                    var buffer = Encoding.UTF8.GetBytes(JsonData);
                    var bytes = new ByteArrayContent(buffer);
                    bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        string RestURL = string.Format("{0}/GetPreviousData/", LR.Properties.Settings.Default.API);
                        var response = await client.PostAsync(RestURL, bytes);
                        responseBody = await response.Content.ReadAsStringAsync();
                    }
                    dataResult = JsonConvert.DeserializeObject<PreviousData>(responseBody);

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
                        cbxBabyFHS.Value = dataResult.fhs;
                        txtBabyFHS_note.Value = dataResult.fhs_note;
                        cbxBabyFHS_twin.Value = dataResult.fhs_twin;
                        txtBabyFHS_twin_note.Value = dataResult.fhs_twin_note;
                        txtUtenc.Value = dataResult.utene;
                        txtPVDilate.Value = dataResult.pv_dilate;
                        txtPVEfacement.Value = dataResult.pv_effacement;
                        cbxPVMembrane.Value = dataResult.pv_membrane;
                        txtPVMembrane.Value = dataResult.pv_membrane_note;
                        cbxPVPresent.Value = dataResult.pv_present;
                        cbxPVPresent_twin.Value = dataResult.pv_present_twin;
                        cbxPVStation.Value = dataResult.pv_station;
                        txtPlan.Value = dataResult.plan;
                        cbxStatus.Value = dataResult.status;
                        txtNote.Value = dataResult.note;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}