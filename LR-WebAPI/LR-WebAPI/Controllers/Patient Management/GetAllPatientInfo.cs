using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;
using LR_WebAPI;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/GetAllPatientInfo")]
    [ApiController]

    public class GetAllPatientInfo
    {
        [HttpGet]
        public ActionResult<ClsResultMessage> Get()
        {
            try
            {
                APILibrary apiLibrary = new APILibrary();
                DataTable dtPatientInfo = apiLibrary.GetAllPatientInfo();
                ClsResultAllPatientInfo resultAllPatientInfo = null;

                if (dtPatientInfo.Rows != null && dtPatientInfo.Rows.Count > 0)
                {
                    resultAllPatientInfo = new ClsResultAllPatientInfo();
                    resultAllPatientInfo.PatienList = new List<ClsAllPatientInfo>();
                    foreach (DataRow row in dtPatientInfo.Rows)
                    {
                        ClsAllPatientInfo allPatient = new ClsAllPatientInfo();
                        allPatient.EventList = new List<ClsEvent>();

                        allPatient.hn = row["pt_hn"].ToString();
                        allPatient.name = row["pt_name"].ToString();
                        allPatient.bed = Convert.ToInt32(row["bed_no"]);
                        allPatient.zone = row["bed_zone"].ToString();
                        allPatient.status = row["me_status"].ToString();
                        allPatient.age = row["pt_age"].ToString();
                        allPatient.gpal = row["pt_gpal"].ToString();
                        allPatient.ga = row["pt_ga"].ToString();
                        allPatient.efw = row["me_baby_weight"].ToString();
                        allPatient.efw_twin = row["me_baby_weight_twin"].ToString();
                        allPatient.pv_dilate = row["me_pv_dilate"].ToString();
                        allPatient.pv_effacement = row["me_pv_effacement"].ToString();
                        allPatient.pv_membrane = row["me_pv_membrane"].ToString();
                        allPatient.pv_station = row["me_pv_station"].ToString();
                        allPatient.pv_present = row["me_pv_present"].ToString();
                        allPatient.fhs = row["me_baby_fhs"].ToString();
                        allPatient.utene = row["me_utene"].ToString();

                        DataTable dtEvent = apiLibrary.GetAllEvent(row["pt_hn"].ToString());
                        foreach (DataRow row2 in dtEvent.Rows)
                        {
                            ClsEvent allEvent = new ClsEvent();
                            allEvent.hn = row2["pt_hn"].ToString();
                            allEvent.se_id = row2["se_id"].ToString();
                            allEvent.datetime = row2["se_datetime"].ToString();
                            allEvent.fhs = row2["se_fhs"].ToString();
                            allEvent.fhs_note = row2["se_fhs_note"].ToString();
                            allEvent.fhs_twin = row2["se_fhs_twin"].ToString();
                            allEvent.fhs_twin_note = row2["se_fhs_twin_note"].ToString();
                            allEvent.utene = row2["se_uc"].ToString();
                            allEvent.pv_dilate = row2["se_pv_dilate"].ToString();
                            allEvent.pv_effacement = row2["se_pv_effacement"].ToString();
                            allEvent.pv_membrane = row2["se_pv_membrane"].ToString();
                            allEvent.pv_membrane_note = row2["se_pv_membrane_note"].ToString();
                            allEvent.pv_present = row2["se_pv_present"].ToString();
                            allEvent.pv_present_twin = row2["se_pv_present_twin"].ToString();
                            allEvent.pv_station = row2["se_pv_station"].ToString();
                            allEvent.plan = row2["se_plan"].ToString();
                            allEvent.status = row2["se_status"].ToString();
                            allEvent.note = row2["se_note"].ToString();
                            allEvent.eventtype = row2["se_type"].ToString();

                            allPatient.EventList.Add(allEvent);
                        }

                        resultAllPatientInfo.PatienList.Add(allPatient);
                    }
                }

                if (resultAllPatientInfo != null)
                {
                    resultAllPatientInfo.Code = 100;
                    resultAllPatientInfo.Message = "Success";
                    return resultAllPatientInfo;
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
    }
}
