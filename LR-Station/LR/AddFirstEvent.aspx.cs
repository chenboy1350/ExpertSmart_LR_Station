using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LR_Station
{
    public partial class AddFirstEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayOldData();
            }
        }

        private void DisplayOldData()
        {
            try
            {
                if (Session["first_event"] != null)
                {
                    String[] first_event = (String[])Session["first_event"];

                    this.txtDateTime.Value = first_event[0];
                    this.txtComplaint.Value = first_event[1];
                    this.txtVS.Value = first_event[2];
                    this.txtBabyWeight.Value = first_event[3];
                    this.txtBabyWeight_twin.Value = first_event[4];
                    this.cbxBabyFHS.Value = first_event[5];
                    this.txtBabyFHS_note.Value = first_event[6];
                    this.cbxBabyFHS_twin.Value = first_event[7];
                    this.txtBabyFHS_twin_note.Value = first_event[8];
                    this.txtUtenc.Value = first_event[9];
                    this.txtPVDilate.Value = first_event[10];
                    this.txtPVEfacement.Value = first_event[11];
                    this.cbxPVMembrane.Value = first_event[12];
                    this.txtPVMembrane.Value = first_event[13];
                    this.cbxPVPresent.Value = first_event[14];
                    this.cbxPVPresent_twin.Value = first_event[15];
                    this.cbxPVStation.Value = first_event[16];
                    this.txtPlan.Value = first_event[17];
                    this.cbxStatus.Value = first_event[18];
                    this.txtNote.Value = first_event[19];
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void SaveNewData(string Index)
        {
            try
            {
                String[] first_event = new String[20];
                first_event[0] = this.txtDateTime.Value;
                first_event[1] = this.txtComplaint.Value;
                first_event[2] = this.txtVS.Value;
                first_event[3] = this.txtBabyWeight.Value;
                first_event[4] = this.txtBabyWeight_twin.Value;
                first_event[5] = this.cbxBabyFHS.Value;
                first_event[6] = this.txtBabyFHS_note.Value;
                first_event[7] = this.cbxBabyFHS_twin.Value;
                first_event[8] = this.txtBabyFHS_twin_note.Value;
                first_event[9] = this.txtUtenc.Value;
                first_event[10] = this.txtPVDilate.Value;
                first_event[11] = this.txtPVEfacement.Value;
                first_event[12] = this.cbxPVMembrane.Value;
                first_event[13] = this.txtPVMembrane.Value;
                first_event[14] = this.cbxPVPresent.Value;
                first_event[15] = this.cbxPVPresent_twin.Value;
                first_event[16] = this.cbxPVStation.Value;
                first_event[17] = this.txtPlan.Value;
                first_event[18] = this.cbxStatus.Value;
                first_event[19] = this.txtNote.Value;

                Session["first_event"] = first_event;
                Response.Redirect(Index);
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveNewData("FinishingInsertPatient.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            SaveNewData("AddPatientInfo.aspx");
        }
    }
}