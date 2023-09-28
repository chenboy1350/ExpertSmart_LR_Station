using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LR_Station
{
    public partial class Event : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    GetPatientInfo_FromAPI();
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        private async void GetPatientInfo_FromAPI()
        {
            try
            {
                AllPatientInfo dataResult = new AllPatientInfo();
                string responseBody = "";
                using (HttpClient client = new HttpClient())
                {
                    string RestURL = string.Format("{0}/GetAllPatientInfo/", LR.Properties.Settings.Default.API);
                    var response = await client.GetAsync(RestURL);
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                dataResult = JsonConvert.DeserializeObject<AllPatientInfo>(responseBody);

                if (dataResult == null)
                {
                    return;
                }
                else if (dataResult.code == 201)
                {
                    return;
                }
                else
                {
                    DataTable dtBed1 = new DataTable();
                    DataTable dtBed2 = new DataTable();
                    DataTable dtEvent1 = new DataTable();
                    DataTable dtEvent2 = new DataTable();

                    dtBed1.Columns.Add("hn", typeof(String));
                    dtBed1.Columns.Add("name", typeof(String));
                    dtBed1.Columns.Add("bed", typeof(int));
                    dtBed1.Columns.Add("zone", typeof(String));
                    dtBed1.Columns.Add("status", typeof(String));
                    dtBed1.Columns.Add("age", typeof(String));
                    dtBed1.Columns.Add("gpal", typeof(String));
                    dtBed1.Columns.Add("ga", typeof(String));
                    dtBed1.Columns.Add("efw", typeof(String));
                    dtBed1.Columns.Add("efw_twin", typeof(String));
                    dtBed1.Columns.Add("pv_dilate", typeof(String));
                    dtBed1.Columns.Add("pv_effacement", typeof(String));
                    dtBed1.Columns.Add("pv_membrane", typeof(String));
                    dtBed1.Columns.Add("pv_station", typeof(String));
                    dtBed1.Columns.Add("pv_present", typeof(String));
                    dtBed1.Columns.Add("fhs", typeof(String));
                    dtBed1.Columns.Add("utene", typeof(String));

                    dtBed2.Columns.Add("hn", typeof(String));
                    dtBed2.Columns.Add("name", typeof(String));
                    dtBed2.Columns.Add("bed", typeof(int));
                    dtBed2.Columns.Add("zone", typeof(String));
                    dtBed2.Columns.Add("status", typeof(String));
                    dtBed2.Columns.Add("age", typeof(String));
                    dtBed2.Columns.Add("gpal", typeof(String));
                    dtBed2.Columns.Add("ga", typeof(String));
                    dtBed2.Columns.Add("efw", typeof(String));
                    dtBed2.Columns.Add("efw_twin", typeof(String));
                    dtBed2.Columns.Add("pv_dilate", typeof(String));
                    dtBed2.Columns.Add("pv_effacement", typeof(String));
                    dtBed2.Columns.Add("pv_membrane", typeof(String));
                    dtBed2.Columns.Add("pv_station", typeof(String));
                    dtBed2.Columns.Add("pv_present", typeof(String));
                    dtBed2.Columns.Add("fhs", typeof(String));
                    dtBed2.Columns.Add("utene", typeof(String));

                    dtEvent1.Columns.Add("hn", typeof(String));
                    dtEvent1.Columns.Add("se_id", typeof(String));
                    dtEvent1.Columns.Add("datetime", typeof(String));
                    dtEvent1.Columns.Add("pv_dilate", typeof(String));
                    dtEvent1.Columns.Add("pv_effacement", typeof(String));
                    dtEvent1.Columns.Add("pv_membrane", typeof(String));
                    dtEvent1.Columns.Add("pv_membrane_note", typeof(String));
                    dtEvent1.Columns.Add("pv_station", typeof(String));
                    dtEvent1.Columns.Add("pv_present", typeof(String));
                    dtEvent1.Columns.Add("pv_present_twin", typeof(String));
                    dtEvent1.Columns.Add("fhs", typeof(String));
                    dtEvent1.Columns.Add("fhs_note", typeof(String));
                    dtEvent1.Columns.Add("fhs_twin", typeof(String));
                    dtEvent1.Columns.Add("fhs_twin_note", typeof(String));
                    dtEvent1.Columns.Add("utene", typeof(String));
                    dtEvent1.Columns.Add("status", typeof(String));
                    dtEvent1.Columns.Add("plan", typeof(String));
                    dtEvent1.Columns.Add("note", typeof(String));
                    dtEvent1.Columns.Add("eventtype", typeof(String));

                    dtEvent2.Columns.Add("hn", typeof(String));
                    dtEvent2.Columns.Add("se_id", typeof(String));
                    dtEvent2.Columns.Add("datetime", typeof(String));
                    dtEvent2.Columns.Add("pv_dilate", typeof(String));
                    dtEvent2.Columns.Add("pv_effacement", typeof(String));
                    dtEvent2.Columns.Add("pv_membrane", typeof(String));
                    dtEvent2.Columns.Add("pv_membrane_note", typeof(String));
                    dtEvent2.Columns.Add("pv_station", typeof(String));
                    dtEvent2.Columns.Add("pv_present", typeof(String));
                    dtEvent2.Columns.Add("pv_present_twin", typeof(String));
                    dtEvent2.Columns.Add("fhs", typeof(String));
                    dtEvent2.Columns.Add("fhs_note", typeof(String));
                    dtEvent2.Columns.Add("fhs_twin", typeof(String));
                    dtEvent2.Columns.Add("fhs_twin_note", typeof(String));
                    dtEvent2.Columns.Add("utene", typeof(String));
                    dtEvent2.Columns.Add("status", typeof(String));
                    dtEvent2.Columns.Add("plan", typeof(String));
                    dtEvent2.Columns.Add("note", typeof(String));
                    dtEvent2.Columns.Add("eventtype", typeof(String));

                    foreach (var patien in dataResult.PatienList)
                    {
                        if (patien.zone.ToString() == "Wait")
                        {
                            dtBed1.Rows.Add(patien.hn.ToString(), patien.name.ToString(), patien.bed.ToString(), patien.zone.ToString(), patien.status.ToString(), patien.age.ToString(), patien.gpal.ToString(), patien.ga.ToString(), patien.efw.ToString(), patien.efw_twin.ToString(), patien.pv_dilate.ToString(), patien.pv_effacement.ToString(), patien.pv_membrane.ToString(), patien.pv_station.ToString(), patien.pv_present.ToString(), patien.fhs.ToString(), patien.utene.ToString());
                            foreach (var events in patien.EventList)
                            {
                                dtEvent1.Rows.Add(events.hn.ToString(), events.se_id.ToString(), events.datetime.ToString(), events.pv_dilate.ToString(), events.pv_effacement.ToString(), events.pv_membrane.ToString(), events.pv_membrane_note.ToString(), events.pv_station.ToString(), events.pv_present.ToString(), events.pv_present_twin.ToString(), events.fhs.ToString(), events.fhs_note.ToString(), events.fhs_twin.ToString(), events.fhs_twin_note.ToString(), events.utene.ToString(), events.status.ToString(), events.plan.ToString(), events.note.ToString(), events.eventtype.ToString());
                            }
                        }
                        if (patien.zone.ToString() == "Safe")
                        {
                            dtBed2.Rows.Add(patien.hn.ToString(), patien.name.ToString(), patien.bed.ToString(), patien.zone.ToString(), patien.status.ToString(), patien.age.ToString(), patien.gpal.ToString(), patien.ga.ToString(), patien.efw.ToString(), patien.efw_twin.ToString(), patien.pv_dilate.ToString(), patien.pv_effacement.ToString(), patien.pv_membrane.ToString(), patien.pv_station.ToString(), patien.pv_present.ToString(), patien.fhs.ToString(), patien.utene.ToString());
                            foreach (var events in patien.EventList)
                            {
                                dtEvent2.Rows.Add(events.hn.ToString(), events.se_id.ToString(), events.datetime.ToString(), events.pv_dilate.ToString(), events.pv_effacement.ToString(), events.pv_membrane.ToString(), events.pv_membrane_note.ToString(), events.pv_station.ToString(), events.pv_present.ToString(), events.pv_present_twin.ToString(), events.fhs.ToString(), events.fhs_note.ToString(), events.fhs_twin.ToString(), events.fhs_twin_note.ToString(), events.utene.ToString(), events.status.ToString(), events.plan.ToString(), events.note.ToString(), events.eventtype.ToString());
                            }
                        }
                    }

                    Session["dte1"] = dtEvent1;
                    Session["dte2"] = dtEvent2;

                    rptBed.DataSource = dtBed1;
                    rptBed.DataBind();
                    
                    rptBed2.DataSource = dtBed2;
                    rptBed2.DataBind();

                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        protected void rptBed_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hidhn = (e.Item.FindControl("hidhn") as HiddenField);

                    var dte1 = (DataTable)Session["dte1"];
                    DataRow[] rows = dte1.Select(string.Format(" hn = '{0}'", hidhn.Value));
                    if(rows.Length > 0)
                    {
                        Repeater rptevent1 = (e.Item.FindControl("rptevent1") as Repeater);

                        rptevent1.DataSource = rows.CopyToDataTable();
                        rptevent1.DataBind();
                    }
                }
            }
            catch
            {

            }
        }

        protected void rptBed2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hidhn = (e.Item.FindControl("hidhn") as HiddenField);

                    var dte2 = (DataTable)Session["dte2"];
                    DataRow[] rows = dte2.Select(string.Format(" hn = '{0}'", hidhn.Value));
                    if (rows.Length > 0)
                    {
                        Repeater rptevent2 = (e.Item.FindControl("rptevent2") as Repeater);

                        rptevent2.DataSource = rows.CopyToDataTable();
                        rptevent2.DataBind();
                    }
                }
            }
            catch
            {

            }
        }
    }
}