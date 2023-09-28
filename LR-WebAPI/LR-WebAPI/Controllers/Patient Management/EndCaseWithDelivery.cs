using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/EndCaseWithDelivery")]
    [ApiController]

    public class EndCaseWithDelivery
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            ClsResultMessage clsResult = new ClsResultMessage(100, "Hello EndCaseWithDelivery");
            return JsonConvert.SerializeObject(clsResult);
        }

        [HttpPost]
        public ActionResult<ClsResultMessage> Post(ClsInputEndWithDeliver clsInput)
        {
            try
            {
                this.ValidationInput(clsInput);
                APILibrary APIDB = new APILibrary
                {
                    hn = clsInput.hn,
                    name = clsInput.name,
                    datetime = clsInput.date,
                    endEFW = clsInput.EFW,
                    endAGPAR = clsInput.AGPAR,
                    follow = clsInput.Follow
                };

                ClsResultMessage ResultAddNewEvent = null;
                ResultAddNewEvent = new ClsResultMessage();

                if (APIDB.EndWithDelivery())
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

        private void ValidationInput(ClsInputEndWithDeliver input)
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
