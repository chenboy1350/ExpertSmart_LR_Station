using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/InsertNewEvent")]
    [ApiController]

    public class InsertNewEvent
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            ClsResultMessage clsResult = new ClsResultMessage(100, "Hello InsertNewEvent");
            return JsonConvert.SerializeObject(clsResult);
        }

        [HttpPost]
        public ActionResult<ClsResultMessage> Post(ClsInputNewEvent clsInput)
        {
            try
            {
                this.ValidationInput(clsInput);
                APILibrary APIDB = new APILibrary
                {
                    saveas = clsInput.saveas,
                    hn = clsInput.hn,
                    name = clsInput.name,
                    datetime = clsInput.datetime,
                    baby_fhs = clsInput.baby_fhs,
                    baby_fhs_note = clsInput.baby_fhs_note,
                    baby_fhs_twin = clsInput.baby_fhs_twin,
                    baby_fhs_twin_note = clsInput.baby_fhs_twin_note,
                    utene = clsInput.utene,
                    pv_dilate = clsInput.pv_dilate,
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

                ClsResultAddNewEvent ResultAddNewEvent = null;
                ResultAddNewEvent = new ClsResultAddNewEvent();

                if (APIDB.AddNewEvent())
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

        private void ValidationInput(ClsInputNewEvent input)
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
