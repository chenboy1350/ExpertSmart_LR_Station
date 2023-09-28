using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/MoveBed")]
    [ApiController]

    public class MoveBed
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            ClsResultMessage clsResult = new ClsResultMessage(100, "Hello Let's Move");
            return JsonConvert.SerializeObject(clsResult);
        }

        [HttpPost]
        public ActionResult<ClsResultMessage> Post(ClsInputMoveBed clsInput)
        {
            try
            {
                this.ValidationInput(clsInput);
                APILibrary APIDB = new APILibrary
                {
                    hn = clsInput.hn,
                    name = clsInput.name,
                    curZone = clsInput.curZone,
                    curBed = clsInput.curBed,
                    toZone = clsInput.toZone,
                    toBed = clsInput.toBed
                };

                ClsResultMessage ResultAddNewEvent = null;
                ResultAddNewEvent = new ClsResultMessage();

                string result = APIDB.MoveBed();

                if (result == "100")
                {
                    ResultAddNewEvent.Code = 100;
                    ResultAddNewEvent.Message = "Success";
                    return ResultAddNewEvent;
                }
                else if(result == "201")
                {
                    ResultAddNewEvent.Code = 201;
                    ResultAddNewEvent.Message = "Unsuccess";
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

        private void ValidationInput(ClsInputMoveBed input)
        {
            try
            {
                string msgError = string.Empty;
                if (string.IsNullOrEmpty(input.hn))
                    msgError = "HN not found." + Environment.NewLine;

                if (msgError != string.Empty)
                {
                    throw new Exception("MoveBed Fail! Please check input: " + Environment.NewLine + msgError);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
