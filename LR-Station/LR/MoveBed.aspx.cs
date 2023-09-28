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
    public partial class MoveBed : System.Web.UI.Page
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
                        txtZONE.Text = Request.QueryString["zone"].ToString();
                        txtBED.Text = Request.QueryString["bed"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        protected void cbxMoveTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxMoveTo.SelectedValue == "Wait")
            {
                cbxToBed.Items.Clear();
                cbxToBed.Items.Add("4");
                cbxToBed.Items.Add("5");
                cbxToBed.Items.Add("6");
                cbxToBed.Items.Add("7");
                cbxToBed.Items.Add("8");
                cbxToBed.Enabled = true;
            }
            else if (cbxMoveTo.SelectedValue == "Safe")
            {
                cbxToBed.Items.Clear();
                cbxToBed.Items.Add("1");
                cbxToBed.Items.Add("2");
                cbxToBed.Items.Add("3");
                cbxToBed.Items.Add("4");
                cbxToBed.Items.Add("5");
                cbxToBed.Items.Add("6");
                cbxToBed.Items.Add("7");
                cbxToBed.Items.Add("8");
                cbxToBed.Enabled = true;
            }
        }

        private async void MoveTo()
        {
            try
            {
                if ((txtHN.Text != string.Empty && txtNAME.Text != string.Empty) || (txtHN.Text != null && txtNAME.Text != null))
                {
                    MoveTo parameter = new MoveTo()
                    {
                        hn = txtHN.Text,
                        name = txtNAME.Text,
                        curBed = txtBED.Text,
                        toZone = cbxMoveTo.SelectedValue,
                        toBed = cbxToBed.SelectedValue,
                    };

                    if(txtZONE.Text == "Waiting Covid Result")
                    {
                        parameter.curZone = "Wait";
                    }
                    else if (txtZONE.Text == "No Covid")
                    {
                        parameter.curZone = "Salf";
                    }

                    MsgResult dataResult = new MsgResult();
                    string responseBody = "";
                    string JsonData = JsonConvert.SerializeObject(parameter);
                    var buffer = Encoding.UTF8.GetBytes(JsonData);
                    var bytes = new ByteArrayContent(buffer);
                    bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (HttpClient client = new HttpClient())
                    {
                        string RestURL = string.Format("{0}/MoveBed/", LR.Properties.Settings.Default.API);
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
                    else if (dataResult.code == 201)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Modal_Danger", "$(window).on('load', function () { $('#DialogIconedDanger2').modal('show'); }); ", true);
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
            MoveTo();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnDiscard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnDiscard2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}