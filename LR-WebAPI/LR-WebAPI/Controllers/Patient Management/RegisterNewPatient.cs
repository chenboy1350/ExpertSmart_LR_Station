using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/RegisterNewPatient")]
    [ApiController]

    public class RegisterNewPatient
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            ClsResultMessage clsResult = new ClsResultMessage(100, "Hello RegisterNewPatient");
            return JsonConvert.SerializeObject(clsResult);
        }

        [HttpPost]
        public ActionResult<ClsResultMessage> Post(ClsInputRegisterNewPatient clsInput)
        {
            try
            {
                this.ValidationInput(clsInput);
                APILibrary APIDB = new APILibrary
                {

                    hn = clsInput.hn,
                    name = clsInput.name,
                    age = clsInput.age,
                    gpal = clsInput.gpal,
                    edc = clsInput.edc,
                    ga = clsInput.ga,
                    admit_at = clsInput.admit_at,
                    admit_times = clsInput.admit_times,
                    bed = clsInput.bed,

                    lab1 = clsInput.lab1,
                    lab1_note = clsInput.lab1_note,
                    lab2 = clsInput.lab2,
                    lab2_note = clsInput.lab2_note,
                    hct1 = clsInput.hct1,
                    hct2 = clsInput.hct2,
                    allergy = clsInput.allergy,
                    allergy_note = clsInput.allergy_note,
                    surgery = clsInput.surgery,
                    surgery_note = clsInput.surgery_note,
                    uc = clsInput.uc,
                    uc_note = clsInput.uc_note,
                    risk = clsInput.risk,
                    risk_note = clsInput.risk_note,
                    covid_status = clsInput.covid_status,

                    datetime = clsInput.datetime,
                    chief_complaint = clsInput.chief_complaint,
                    vs = clsInput.vs,
                    baby_weight = clsInput.baby_weight,
                    baby_weight_twin = clsInput.baby_weight_twin,
                    baby_fhs = clsInput.baby_fhs,
                    baby_fhs_note = clsInput.baby_fhs_note,
                    baby_fhs_twin = clsInput.baby_fhs_twin,
                    baby_fhs_twin_note = clsInput.baby_fhs_twin_note,
                    utene = clsInput.utene,
                    pv_dilate = clsInput.pv_diate,
                    pv_effacement = clsInput.pv_effacement,
                    pv_membrane = clsInput.pv_membrane,
                    pv_membrane_note = clsInput.pv_membrane_note,
                    pv_present = clsInput.pv_present,
                    pv_present_twin = clsInput.pv_present_twin,
                    pv_station = clsInput.pv_station,
                    plan = clsInput.plan,
                    status = clsInput.status,
                    note = clsInput.note
                };

                ClsResultRegisterNewPatient ResultRegisterNewPatient = null;
                ResultRegisterNewPatient = new ClsResultRegisterNewPatient();

                if (APIDB.AddNewPatient())
                {
                    //if (clsInput.ANC_list == null)
                    //{
                    //    ResultRegisterNewPatient.Code = 200;
                    //    ResultRegisterNewPatient.Message = "Unsuccess";
                    //    return ResultRegisterNewPatient;
                    //}
                    //var anc = clsInput.ANC_list;
                    //foreach(var anx in clsInput.ANC_list)
                    //{
                    //    APIDB.hn = clsInput.hn;
                    //    APIDB.anc_at = anx.anc_at;
                    //    APIDB.anc_times = anx.anc_times;
                    //    APIDB.AddANC();
                    //}

                    ResultRegisterNewPatient.Code = 100;
                    ResultRegisterNewPatient.Message = "Success";
                    return ResultRegisterNewPatient;
                }
                else
                {
                    ResultRegisterNewPatient.Code = 400;
                    ResultRegisterNewPatient.Message = "Unsuccess";
                    return ResultRegisterNewPatient;
                }
            }
            catch (Exception ex)
            {
                ClsResultMessage clsResult = new ClsResultMessage(201, ex.Message);
                return clsResult;
            }
        }

        private void ValidationInput(ClsInputRegisterNewPatient input)
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
