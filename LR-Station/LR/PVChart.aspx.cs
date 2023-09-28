using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace LR_Station
{
    public partial class PVChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString.Count > 0)
                    {
                        GetBedInfo_FromAPI(Request.QueryString["hn"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                }
            }
        }

        private async void GetBedInfo_FromAPI(string hn)
        {
            try
            {
                HNOnly parameter = new HNOnly()
                {
                    hn = hn,
                };

                PVChartData dataResult = new PVChartData();
                string responseBody = "";
                string JsonData = JsonConvert.SerializeObject(parameter);
                var buffer = Encoding.UTF8.GetBytes(JsonData);
                var bytes = new ByteArrayContent(buffer);
                bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpClient client = new HttpClient())
                {
                    string RestURL = string.Format("{0}/GetPVChart/", LR.Properties.Settings.Default.API);
                    var response = await client.PostAsync(RestURL, bytes);
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                dataResult = JsonConvert.DeserializeObject<PVChartData>(responseBody);

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
                    DataTable dtDIL = new DataTable();
                    DataTable dtSTR = new DataTable();
                    dtDIL.Columns.Add("PV_Dilate", typeof(String));
                    dtSTR.Columns.Add("PV_Station", typeof(String));

                    foreach (var items in dataResult.PVList)
                    {
                        dtDIL.Rows.Add(items.PV_Dilate.ToString());
                        dtSTR.Rows.Add(items.PV_Station.ToString());
                    }

                    if (dtDIL.Rows.Count > 0 && dtSTR.Rows.Count > 0)
                    {
                        StringBuilder chartData = new StringBuilder();
                        string DILdata = string.Empty;
                        string STRdata = string.Empty;
                        int PreviousIndex = 0;

                        // [1, 1, 4, 4, 5, 5, 3, 3, 2, 2, 1, 1]
                        foreach (DataRow drDIL in dtDIL.Rows)
                        {
                            double index = 0;
                            if (PreviousIndex != 0)
                            {
                                if (PreviousIndex > Convert.ToInt32(drDIL[0]))
                                {
                                    index = PreviousIndex - Convert.ToInt32(drDIL[0]);

                                    if (index == 1)
                                    {
                                        DILdata += String.Format("{0},", (Convert.ToDouble(drDIL[0]) + 0.5).ToString());
                                    }
                                    else if (index == 2)
                                    {
                                        DILdata += String.Format("{0},", (Convert.ToDouble(drDIL[0]) + 1).ToString());
                                    }
                                    else if (index == 3)
                                    {
                                        DILdata += String.Format("{0},", (Convert.ToDouble(drDIL[0]) + 1.5).ToString());
                                    }
                                    else if (index == 4)
                                    {
                                        DILdata += String.Format("{0},", (Convert.ToDouble(drDIL[0]) + 2).ToString());
                                    }
                                    else if (index == 5)
                                    {
                                        DILdata += String.Format("{0},", (Convert.ToDouble(drDIL[0]) + 2.5).ToString());
                                    }
                                    else if (index == 6)
                                    {
                                        DILdata += String.Format("{0},", (Convert.ToDouble(drDIL[0]) + 3).ToString());
                                    }
                                    else if (index == 7)
                                    {
                                        DILdata += String.Format("{0},", (Convert.ToDouble(drDIL[0]) + 3.5).ToString());
                                    }
                                    else if (index == 8)
                                    {
                                        DILdata += String.Format("{0},", (Convert.ToDouble(drDIL[0]) + 4).ToString());
                                    }
                                    else if (index == 9)
                                    {
                                        DILdata += String.Format("{0},", (Convert.ToDouble(drDIL[0]) + 4.5).ToString());
                                    }
                                    else if (index == 10)
                                    {
                                        DILdata += String.Format("{0},", (Convert.ToDouble(drDIL[0]) + 5).ToString());
                                    }
                                }
                                else if (PreviousIndex < Convert.ToInt32(drDIL[0]))
                                {
                                    index = Convert.ToInt32(drDIL[0]) - PreviousIndex;

                                    if (index == 1)
                                    {
                                        DILdata += String.Format("{0},", (PreviousIndex + 0.5).ToString());
                                    }
                                    else if (index == 2)
                                    {
                                        DILdata += String.Format("{0},", (PreviousIndex + 1).ToString());
                                    }
                                    else if (index == 3)
                                    {
                                        DILdata += String.Format("{0},", (PreviousIndex + 1.5).ToString());
                                    }
                                    else if (index == 4)
                                    {
                                        DILdata += String.Format("{0},", (PreviousIndex + 2).ToString());
                                    }
                                    else if (index == 5)
                                    {
                                        DILdata += String.Format("{0},", (PreviousIndex + 2.5).ToString());
                                    }
                                    else if (index == 6)
                                    {
                                        DILdata += String.Format("{0},", (PreviousIndex + 3).ToString());
                                    }
                                    else if (index == 7)
                                    {
                                        DILdata += String.Format("{0},", (PreviousIndex + 3.5).ToString());
                                    }
                                    else if (index == 8)
                                    {
                                        DILdata += String.Format("{0},", (PreviousIndex + 4).ToString());
                                    }
                                    else if (index == 9)
                                    {
                                        DILdata += String.Format("{0},", (PreviousIndex + 4.5).ToString());
                                    }
                                    else if (index == 10)
                                    {
                                        DILdata += String.Format("{0},", (PreviousIndex + 5).ToString());
                                    }
                                }
                            }
                            else
                            {
                                DILdata += String.Format("{0},", drDIL[0].ToString());
                            }

                            DILdata += String.Format("{0},", drDIL[0].ToString());

                            PreviousIndex = Convert.ToInt32(drDIL[0]);
                        }

                        foreach (DataRow drSTR in dtSTR.Rows)
                        {

                            STRdata += String.Format("{0},", drSTR[0].ToString());
                            STRdata += String.Format("{0},", drSTR[0].ToString());
                        }

                        DILdata = DILdata.Substring(0, DILdata.Length - 1);
                        STRdata = STRdata.Substring(0, STRdata.Length - 1);

                        chartData.AppendFormat("DILchartData = [{0}]; STRchartData = [{1}];", DILdata, STRdata, Environment.NewLine);

                        ltChartData.Text = chartData.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }
    }
}