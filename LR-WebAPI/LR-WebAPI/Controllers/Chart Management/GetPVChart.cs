using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;
using LR_WebAPI;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/GetPVChart")]
    [ApiController]

    public class GetPVChart
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            ClsResultMessage clsResult = new ClsResultMessage(100, "Hello PV Cahrt");
            return JsonConvert.SerializeObject(clsResult);
        }

        [HttpPost]
        public ActionResult<ClsResultMessage> Post(ClsInputHN clsInput)
        {
            try
            {
                this.ValidationInput(clsInput);
                APILibrary APIDB = new APILibrary
                {
                    hn = clsInput.hn,
                };

                DataTable dtChartData = APIDB.GetPVChart();
                ClsResultChartData resultChartData = null;

                if (dtChartData.Rows != null && dtChartData.Rows.Count > 0)
                {
                    resultChartData = new ClsResultChartData();
                    resultChartData.ChartData = new List<ClsChartData>();

                    resultChartData.hn = clsInput.hn;

                    foreach (DataRow row in dtChartData.Rows)
                    {
                        ClsChartData data = new ClsChartData();
                        data.PV_Dilate = Convert.ToInt32(row["PV_Dilate"]);

                        data.PV_Station = Convert.ToInt32(row["PV_Station"]);

                        resultChartData.ChartData.Add(data);
                    }
                }

                if (resultChartData != null)
                {
                    resultChartData.Code = 100;
                    resultChartData.Message = "Success";
                    return resultChartData;
                }
                else
                {
                    throw new Exception("Data not found");
                }
            }
            catch (Exception ex)
            {
                ClsResultMessage clsResult = new ClsResultMessage(201, ex.Message);
                return clsResult;
            }
        }

        private void ValidationInput(ClsInputHN input)
        {
            try
            {
                string msgError = string.Empty;
                if (string.IsNullOrEmpty(input.hn))
                    msgError = "HN not found." + Environment.NewLine;

                if (msgError != string.Empty)
                {
                    throw new Exception("RegisterNewPatient Fail! Please check input: " + Environment.NewLine + msgError);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
