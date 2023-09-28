using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Collections.Generic;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/GetPatientInfo")]
    [ApiController]

    public class GetPatientInfo
    {
        [HttpPost]
        public ActionResult<ClsResultMessage> Post(ClsInputHN clsInput)
        {
            try
            {
                this.ValidationInput(clsInput);
                APILibrary APIDB = new APILibrary();
                APIDB.hn = clsInput.hn;

                DataTable dtPatientInfo = APIDB.GetPatientInfo();
                ClsResultPatientInfo resultPatientInfo = null;

                if (dtPatientInfo.Rows != null && dtPatientInfo.Rows.Count > 0)
                {
                    resultPatientInfo = new ClsResultPatientInfo();
                    resultPatientInfo.AncList = new List<ClsAnc>();

                    foreach (DataRow row in dtPatientInfo.Rows)
                    {
                        resultPatientInfo.hn = row["pt_hn"].ToString();
                        resultPatientInfo.name = row["pt_name"].ToString();
                        resultPatientInfo.age = row["pt_age"].ToString();
                        resultPatientInfo.gpal = row["pt_gpal"].ToString();
                        resultPatientInfo.edc = row["pt_edc"].ToString();
                        resultPatientInfo.ga = row["pt_ga"].ToString();
                        resultPatientInfo.admit_at = row["pt_admit_at"].ToString();
                        resultPatientInfo.admit_times = row["pt_admit_times"].ToString();
                        resultPatientInfo.lab1 = row["pt_lab1"].ToString();
                        resultPatientInfo.lab1_note = row["pt_lab1_note"].ToString();
                        resultPatientInfo.lab2 = row["pt_lab2"].ToString();
                        resultPatientInfo.lab2_note = row["pt_lab2_note"].ToString();
                        resultPatientInfo.hct1 = row["pt_hct1"].ToString();
                        resultPatientInfo.hct2 = row["pt_hct2"].ToString();
                        resultPatientInfo.allergy = row["pt_allergy"].ToString();
                        resultPatientInfo.allergy_note = row["pt_allergy_note"].ToString();
                        resultPatientInfo.surgery = row["pt_surgery"].ToString();
                        resultPatientInfo.surgery_note = row["pt_surgery_note"].ToString();
                        resultPatientInfo.uc = row["pt_uc"].ToString();
                        resultPatientInfo.uc_note = row["pt_uc_note"].ToString();
                        resultPatientInfo.risk = row["pt_risk"].ToString();
                        resultPatientInfo.risk_note = row["pt_risk_note"].ToString();
                        resultPatientInfo.covid_status = row["pt_covid_status"].ToString();

                        DataTable dtAnc = APIDB.GetANC(row["pt_hn"].ToString());
                        foreach (DataRow row2 in dtAnc.Rows)
                        {
                            ClsAnc anc = new ClsAnc();

                            anc.hn = row2["pt_hn"].ToString();
                            anc.anc_id = row2["anc_id"].ToString();
                            anc.anc_at = row2["anc_at"].ToString();
                            anc.anc_times = row2["anc_times"].ToString();
                            anc.anc_case_state = row2["anc_case_state"].ToString();

                            resultPatientInfo.AncList.Add(anc);
                        }
                    }
                }

                if (resultPatientInfo != null)
                {
                    resultPatientInfo.Code = 100;
                    resultPatientInfo.Message = "Success";
                    return resultPatientInfo;
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
