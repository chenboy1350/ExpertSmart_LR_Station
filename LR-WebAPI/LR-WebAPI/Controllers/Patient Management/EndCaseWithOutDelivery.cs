using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/EndCaseWithOutDelivery")]
    [ApiController]

    public class EndCaseWithOutDelivery
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            ClsResultMessage clsResult = new ClsResultMessage(100, "Hello EndCaseWithOutDelivery");
            return JsonConvert.SerializeObject(clsResult);
        }

        [HttpPost]
        public ActionResult<ClsResultMessage> Post(ClsInputEndWithOutDeliver clsInput)
        {
            try
            {
                this.ValidationInput(clsInput);
                APILibrary APIDB = new APILibrary
                {
                    hn = clsInput.hn,
                    name = clsInput.name,
                    datetime = clsInput.date,
                    delivery = clsInput.Delivery
                };

                ClsResultMessage ResultAddNewEvent = null;
                ResultAddNewEvent = new ClsResultMessage();

                if (APIDB.EndWithOutDelivery())
                {
                    ResultAddNewEvent.Code = 100;
                    ResultAddNewEvent.Message = "Success";
                    return ResultAddNewEvent;
                }
                else
                {
                    ResultAddNewEvent.Code = 400;
                    ResultAddNewEvent.Message = string.Format("Unsuccess");
                    return ResultAddNewEvent;
                }
            }
            catch (Exception ex)
            {
                ClsResultMessage clsResult = new ClsResultMessage(201, ex.Message);
                return clsResult;
            }
        }

        private void ValidationInput(ClsInputEndWithOutDeliver input)
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


