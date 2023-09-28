using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/GetPreviousData")]
    [ApiController]

    public class GetPreviousData
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            ClsResultMessage clsResult = new ClsResultMessage(100, "Hello GetPreviousData");
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
                    hn = clsInput.hn
                };

                ClsResultPreviousData ResultPreviousData = null;
                ResultPreviousData = new ClsResultPreviousData();
                DataTable dtPreviousData = APIDB.GetPreviousData();

                foreach (DataRow row in dtPreviousData.Rows)
                {
                    ResultPreviousData.hn = row["pt_hn"].ToString();
                    ResultPreviousData.fhs = row["se_fhs"].ToString();
                    ResultPreviousData.fhs_note = row["se_fhs_note"].ToString();
                    ResultPreviousData.fhs_twin = row["se_fhs_twin"].ToString();
                    ResultPreviousData.fhs_twin_note = row["se_fhs_twin_note"].ToString();
                    ResultPreviousData.utene = row["se_uc"].ToString();
                    ResultPreviousData.pv_dilate = row["se_pv_dilate"].ToString();
                    ResultPreviousData.pv_effacement = row["se_pv_effacement"].ToString();
                    ResultPreviousData.pv_membrane = row["se_pv_membrane"].ToString();
                    ResultPreviousData.pv_membrane_note = row["se_pv_membrane_note"].ToString();
                    ResultPreviousData.pv_present = row["se_pv_present"].ToString();
                    ResultPreviousData.pv_present_twin = row["se_pv_present_twin"].ToString();
                    ResultPreviousData.pv_station = row["se_pv_station"].ToString();
                    ResultPreviousData.plan = row["se_plan"].ToString();
                    ResultPreviousData.status = row["se_status"].ToString();
                    ResultPreviousData.note = row["se_note"].ToString();
                }

                if (ResultPreviousData != null)
                {
                    ResultPreviousData.Code = 100;
                    ResultPreviousData.Message = "Success";
                    return ResultPreviousData;
                }
                else
                {
                    throw new Exception("Data not found");
                }
            }
            catch(Exception ex)
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
                    throw new Exception("GetPreviousData Fail! Please check input: " + Environment.NewLine + msgError);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
