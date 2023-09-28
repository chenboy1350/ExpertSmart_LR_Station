using System;
using System.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace LR_Station
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    GetBedInfo_FromAPI();
                }
                catch(Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }
        public string GenData(object hn , object name, object bedno, object zone)
        {
            try
            {
                if (hn.ToString() == "Empty")
                {
                    StringBuilder HTMLFormat = new StringBuilder();
                    HTMLFormat.AppendFormat("<li class='splide__slide'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("   <div class='card'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("      <div class='row'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("          <div class='col'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              <span class='iconedbox iconedbox-xxl'><ion-icon name='bed-outline'></ion-icon></span >", Environment.NewLine);
                    HTMLFormat.AppendFormat("          </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("          <div class='col'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              <div class='card-body pt-2'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <h3 class='mb-0'>{0}</h3>", bedno, Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p class='text'></p>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <h4 class='mb-0'>Empty</h4>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p class='text'></p>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p class='text'>Empty</p>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p class='text'></p>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("          </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("      </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("      <div class='card-body pt-2'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("          <div class='row'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              <div class='col'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p><a href='AddPatientInfo.aspx?hn={0}&bed={1}&name={2}&zone={3}' class='btn btn-sm btn-primary btn-block'>Register</a></p>", hn, bedno, name, zone, Environment.NewLine);
                    HTMLFormat.AppendFormat("              </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("          </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("      </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("   </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("</li>", Environment.NewLine);

                    return HTMLFormat.ToString();
                }
                else
                {
                    StringBuilder HTMLFormat = new StringBuilder();
                    HTMLFormat.AppendFormat("<li class='splide__slide'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("   <div class='card'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("      <div class='row'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("          <div class='col'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              <span class='iconedbox iconedbox-xxl'><ion-icon name='person'></ion-icon></span >", Environment.NewLine);
                    HTMLFormat.AppendFormat("          </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("          <div class='col'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              <div class='card-body pt-2'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <h3 class='mb-0'>{0}</h3>",bedno,  Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p class='text'></p>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <h4 class='mb-0'>{0}</h4>", hn, Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p class='text'></p>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p class='text'>{0}</p>", name, Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p class='text'></p>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("          </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("      </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("      <div class='card-body pt-2'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("          <div class='row'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              <div class='col'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p><a href='AddEvent.aspx?hn={0}&name={1}' class='btn btn-sm btn-primary btn-block'>Add Event</a></p>", hn, name, Environment.NewLine);
                    HTMLFormat.AppendFormat("              </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              <div class='col'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p><a href='Event.aspx' class='btn btn-sm btn-primary btn-block'>View Event</a></p>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("              <div class='col'>", Environment.NewLine);
                    HTMLFormat.AppendFormat("                  <p><a href='MoveBed.aspx?hn={0}&name={1}&zone={2}&bed={3}' class='btn btn-sm btn-primary btn-block'>Move</a></p>", hn, name, zone, bedno, Environment.NewLine);
                    HTMLFormat.AppendFormat("              </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("          </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("      </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("   </div>", Environment.NewLine);
                    HTMLFormat.AppendFormat("</li>", Environment.NewLine);

                    return HTMLFormat.ToString();
                }
            }
            catch 
            {
                return "";
            }
        }
        private async void GetBedInfo_FromAPI()
        {
            try
            {
                AllBedInfo dataResult = new AllBedInfo();
                string responseBody = "";
                using (HttpClient client = new HttpClient())
                {
                    string RestURL = string.Format("{0}/GetAllBedInfo/", LR.Properties.Settings.Default.API);
                    var response = await client.GetAsync(RestURL);
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                dataResult = JsonConvert.DeserializeObject<AllBedInfo>(responseBody);

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
                    DataTable dt = new DataTable();
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();
                    dt.Columns.Add("hn", typeof(String));
                    dt.Columns.Add("name", typeof(String));
                    dt.Columns.Add("bed", typeof(int));
                    dt.Columns.Add("zone", typeof(String));

                    dt2.Columns.Add("hn", typeof(String));
                    dt2.Columns.Add("name", typeof(String));
                    dt2.Columns.Add("bed", typeof(int));
                    dt2.Columns.Add("zone", typeof(String));

                    dt3.Columns.Add("hn", typeof(String));
                    dt3.Columns.Add("name", typeof(String));
                    dt3.Columns.Add("bed", typeof(int));
                    dt3.Columns.Add("zone", typeof(String));

                    foreach (var bed in dataResult.bedList)
                    {
                        if(bed.zone.ToString() == "Wait")
                        {
                            dt.Rows.Add(bed.hn.ToString(), bed.name.ToString(), bed.bed.ToString(), bed.zone.ToString());
                        }
                        if (bed.zone.ToString() == "Safe")
                        {
                            dt2.Rows.Add(bed.hn.ToString(), bed.name.ToString(), bed.bed.ToString(), bed.zone.ToString());
                        }
                        if (bed.zone.ToString() == "Other")
                        {
                            dt3.Rows.Add(bed.hn.ToString(), bed.name.ToString(), bed.bed.ToString(), bed.zone.ToString());
                        }
                    }

                    rptBedWaiting.DataSource = dt;
                    rptBedWaiting.DataBind();


                    rptBedNoCovid.DataSource = dt2;
                    rptBedNoCovid.DataBind();

                    //rptBedOther.DataSource = dt3;
                    //rptBedOther.DataBind();

                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        protected string Displaybedempty(object bedno)
        {
            try
            {
                if (bedno.ToString() == "0")
                {
                    return "EMPTY";
                }
                else
                {
                    return string.Format("BED.{0}", bedno); 
                }                
            }
            catch
            {
                return "EMPTY";
            }
        }
    }
}