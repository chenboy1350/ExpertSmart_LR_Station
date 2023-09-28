using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LR_Station
{
    public partial class EndWithoutDelivery : System.Web.UI.Page
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

        private async void EndCaseWithOutDeliver()
        {
            try
            {
                if ((txtHN.Text != string.Empty && txtNAME.Text != string.Empty) || (txtHN.Text != null && txtNAME.Text != null))
                {
                    var now = DateTime.Now.ToString("HH:mm:ss");
                    string datetime = string.Format("{0} {1}", txtDateTime.Value, now);
                    EndCaseWithOutDeliver parameter = new EndCaseWithOutDeliver()
                    {
                        hn = txtHN.Text,
                        name = txtNAME.Text,
                        date = datetime,
                        Delivery = cbxDeliver.Value,
                    };

                    MsgResult dataResult = new MsgResult();
                    string responseBody = "";
                    string JsonData = JsonConvert.SerializeObject(parameter);
                    var buffer = Encoding.UTF8.GetBytes(JsonData);
                    var bytes = new ByteArrayContent(buffer);
                    bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        string RestURL = string.Format("{0}/EndCaseWithOutDelivery/", LR.Properties.Settings.Default.API);
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
            EndCaseWithOutDeliver();
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
    }
}