using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/EditPatientInfo")]
    [ApiController]

    public class EditPatientInfo
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            ClsResultMessage clsResult = new ClsResultMessage(100, "Hello EditPatientInfo");
            return JsonConvert.SerializeObject(clsResult);
        }

        [HttpPost]
        public ActionResult<ClsResultMessage> Post(ClsInputPatientInfo clsInput)
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
                };

                ClsResultAddNewEvent ResultAddNewEvent = null;
                ResultAddNewEvent = new ClsResultAddNewEvent();

                if (APIDB.EditPatient())
                {
                    ResultAddNewEvent.Code = 100;
                    ResultAddNewEvent.Message = "Success";
                    return ResultAddNewEvent;
                }
                else
                {
                    ResultAddNewEvent.Code = 400;
                    ResultAddNewEvent.Message = "Unsuccess";
                    return ResultAddNewEvent;
                }
            }
            catch (Exception ex)
            {
                ClsResultMessage clsResult = new ClsResultMessage(201, ex.Message);
                return clsResult;
            }
        }

        private void ValidationInput(ClsInputPatientInfo input)
        {
            try
            {
                string msgError = string.Empty;
                if (string.IsNullOrEmpty(input.hn))
                    msgError = "HN not found." + Environment.NewLine;

                if (msgError != string.Empty)
                {
                    throw new Exception("EditPatientInfo Fail! Please check input: " + Environment.NewLine + msgError);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
