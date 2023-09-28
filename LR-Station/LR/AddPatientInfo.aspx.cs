using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using static LR_Station.AddNewPatientAPI;
using System.Data;

namespace LR_Station
{
    public partial class AddPatientInfo : System.Web.UI.Page
    {
        System.Globalization.CultureInfo _cultureTHInfo = new System.Globalization.CultureInfo("th-TH");
        System.Globalization.CultureInfo _cultureENInfo = new System.Globalization.CultureInfo("en-EN");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DisplayOldData();

                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["id"] == "BtnHeaderBack")
                        {
                            BtnHeaderBack();
                        }
                        else if(Request.QueryString["hn"].ToString() == "Empty" && Request.QueryString["name"].ToString() == "Empty")
                        {
                            txtBed.Value = Request.QueryString["bed"].ToString();
                            txtAdmitAt.Value = Request.QueryString["zone"].ToString();
                        }
                        else if (Request.QueryString["hn"].ToString() != "Empty" && Request.QueryString["name"].ToString() != "Empty")
                        {
                            Response.Redirect(string.Format("AddEvent.aspx?hn={0}&name={1}", Request.QueryString["hn"].ToString(), Request.QueryString["name"].ToString()));
                        }
                    }
                }
                catch (Exception ex)
                {

                }     
            }
        }

        public void BtnHeaderBack()
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }

        private void DisplayOldData()
        {
            try
            {
                if(Session["patient_info"] != null)
                {
                    String[] patient_info = (String[])Session["patient_info"];

                    if (patient_info[0] == "Wait")
                    {
                        txtAdmitAt.Value = "Waiting Covide Result Zone";
                    }
                    else if(patient_info[0] == "Safe")
                    {
                        txtAdmitAt.Value = "No Covid Zone";
                    }
                    this.txtBed.Value = patient_info[1];
                    this.txtAdmitTimes.Value = patient_info[2];
                    this.txtHN.Value = patient_info[3];
                    this.txtName.Value = patient_info[4];
                    this.txtAge.Value = patient_info[5];
                    this.txtGPAL.Value = patient_info[6];
                    this.txtEDC.Value = patient_info[7];
                    this.txtGA.Text = patient_info[8];
                    if (patient_info[9] == "1") { 
                        chxLAB1.Checked = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle1", "document.getElementById('onchangeToggle1').style.display = 'block';", true);
                    } 
                    else
                    { 
                        chxLAB1.Checked = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle1", "document.getElementById('onchangeToggle1').style.display = 'none';", true);
                    }
                    this.txtLAB1Note.Value = patient_info[10];
                    if (patient_info[11] == "1")
                    {
                        chxLAB2.Checked = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle2", "document.getElementById('onchangeToggle2').style.display = 'block';", true);
                    }
                    else
                    {
                        chxLAB2.Checked = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle2", "document.getElementById('onchangeToggle2').style.display = 'none';", true);
                    }
                    this.txtLAB2Note.Value = patient_info[12];
                    this.txtHCT1.Value = patient_info[13];
                    this.txtHCT2.Value = patient_info[14];
                    if (patient_info[15] == "1")
                    {
                        chxAllergy.Checked = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle3", "document.getElementById('onchangeToggle3').style.display = 'block';", true);
                    }
                    else
                    {
                        chxAllergy.Checked = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle3", "document.getElementById('onchangeToggle3').style.display = 'none';", true);
                    }
                    this.txtAllergyNote.Value = patient_info[16];
                    if (patient_info[17] == "1")
                    {
                        chxSurgery.Checked = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle4", "document.getElementById('onchangeToggle4').style.display = 'block';", true);
                    }
                    else
                    {
                        chxSurgery.Checked = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle4", "document.getElementById('onchangeToggle4').style.display = 'none';", true);
                    }
                    this.txtSurgeryNote.Value = patient_info[18];
                    if (patient_info[19] == "1")
                    {
                        chxUnD.Checked = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle5", "document.getElementById('onchangeToggle5').style.display = 'block';", true);
                    }
                    else
                    {
                        chxUnD.Checked = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle5", "document.getElementById('onchangeToggle5').style.display = 'none';", true);
                    }
                    this.txtUndNote.Value = patient_info[20];
                    if (patient_info[21] == "1")
                    {
                        chxRick.Checked = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle6", "document.getElementById('onchangeToggle6').style.display = 'block';", true);
                    }
                    else
                    {
                        chxRick.Checked = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toggle6", "document.getElementById('onchangeToggle6').style.display = 'none';", true);
                    }
                    this.txtRickNote.Value = patient_info[22];
                    this.cbxCovidState.Value =  patient_info[23];
                }
            }
            catch (Exception ex)
            {

            }
        }

        //protected void btnAddANC_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Session["ANC_List"] != null)
        //        {
        //            List<ANC_List> anc_List_tmp = (List<ANC_List>)Session["ANC_List"];
        //            anc_List_tmp.Add(new ANC_List { anc_at = txtANCat.Value, anc_times = txtANCTimes.Value });
        //            Session["ANC_List"] = anc_List_tmp;

        //            DataTable dtANC = new DataTable();
        //            dtANC.Columns.Add("anc_at", typeof(String));
        //            dtANC.Columns.Add("anc_times", typeof(String));

        //            foreach (var anc in anc_List_tmp)
        //            {
        //                dtANC.Rows.Add(anc.anc_at, anc.anc_times);
        //            }

        //            this.rptANC.DataSource = dtANC;
        //            this.rptANC.DataBind();

        //            txtANCat.Value = "";
        //            txtANCTimes.Value = "";
        //        }
        //        else
        //        {
        //            List<ANC_List> anc_List_tmp = new List<ANC_List>();
        //            anc_List_tmp.Add(new ANC_List { anc_at = txtANCat.Value, anc_times = txtANCTimes.Value });
        //            Session["ANC_List"] = anc_List_tmp;

        //            DataTable dtANC = new DataTable();
        //            dtANC.Columns.Add("anc_at", typeof(String));
        //            dtANC.Columns.Add("anc_times", typeof(String));

        //            foreach (var anc in anc_List_tmp)
        //            {
        //                dtANC.Rows.Add(anc.anc_at, anc.anc_times);
        //            }

        //            this.rptANC.DataSource = dtANC;
        //            this.rptANC.DataBind();

        //            txtANCat.Value = "";
        //            txtANCTimes.Value = "";
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        protected void btnNext_Click1(object sender, EventArgs e)
        {
            try
            {
                //if (Session["ANC_List"] == null)
                //{
                //    List<ANC_List> anc_List_tmp = new List<ANC_List>();
                //    anc_List_tmp.Add(new ANC_List { anc_at = "N/A", anc_times = "0" });
                //    Session["ANC_List"] = anc_List_tmp;
                //}

                String[] patient_info = new String[24];
                if (txtAdmitAt.Value == "Waiting Covide Result Zone")
                {
                    patient_info[0] = "Wait";
                }
                else if (txtAdmitAt.Value == "No Covid Zone")
                {
                    patient_info[0] = "Safe";
                }
                else if (txtAdmitAt.Value == "Wait")
                {
                    patient_info[0] = "Wait";
                }
                else if (txtAdmitAt.Value == "Safe")
                {
                    patient_info[0] = "Safe";
                }

                patient_info[1] = this.txtBed.Value;
                patient_info[2] = this.txtAdmitTimes.Value;
                patient_info[3] = this.txtHN.Value;
                patient_info[4] = this.txtName.Value;
                patient_info[5] = this.txtAge.Value;
                patient_info[6] = this.txtGPAL.Value;
                patient_info[7] = this.txtEDC.Value;
                patient_info[8] = this.txtGA.Text;
                if (chxLAB1.Checked) { patient_info[9] = "1"; } else { patient_info[9] = "0"; }
                patient_info[10] = this.txtLAB1Note.Value;
                if (chxLAB2.Checked) { patient_info[11] = "1"; } else { patient_info[11] = "0"; }
                patient_info[12] = this.txtLAB2Note.Value;
                if (this.txtHCT1.Value == "") { patient_info[13] = "0"; } else { patient_info[13] = this.txtHCT1.Value; ; }
                if (this.txtHCT2.Value == "") { patient_info[14] = "0"; } else { patient_info[14] = this.txtHCT2.Value; ; }
                if (chxAllergy.Checked) { patient_info[15] = "1"; } else { patient_info[15] = "0"; }
                patient_info[16] = this.txtAllergyNote.Value;
                if (chxSurgery.Checked) { patient_info[17] = "1"; } else { patient_info[17] = "0"; }
                patient_info[18] = this.txtSurgeryNote.Value;
                if (chxUnD.Checked) { patient_info[19] = "1"; } else { patient_info[19] = "0"; }
                patient_info[20] = this.txtUndNote.Value;
                if (chxRick.Checked) { patient_info[21] = "1"; } else { patient_info[21] = "0"; }
                patient_info[22] = this.txtRickNote.Value;
                patient_info[23] = this.cbxCovidState.Value;

                Session["patient_info"] = patient_info;

                Response.Redirect("AddFirstEvent.aspx");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Index.aspx");
        }

        protected void btnCalGA_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime EDC = Convert.ToDateTime(txtEDC.Value);
                TimeSpan now = EDC - DateTime.Now.Date;
                double days = Math.Abs(now.Days);
                double GA1 = 280 - days;
                double GA2 = GA1/7;

                if (GA2.ToString("N2").Length == 5)
                {
                    string GA3 = GA2.ToString("N2").Substring(2, 3);
                    double GA4 = Math.Round(Convert.ToDouble(GA3) * 7);
                    txtGA.Text = string.Format(GA2.ToString("N0") + "+" + GA4.ToString() + "Weeks");
                }
                else if(GA2.ToString("N2").Length == 4)
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