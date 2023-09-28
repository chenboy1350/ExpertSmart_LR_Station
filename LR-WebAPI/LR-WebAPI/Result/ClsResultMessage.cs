using Newtonsoft.Json;
using System;

namespace LR_WebAPI
{

    [Serializable]
    public class ClsResultMessage
    {
        public ClsResultMessage()
        {

        }

        public ClsResultMessage(int code, string message)
        {
            Code = code;
            Message = message;
        }

        [JsonProperty("Code")]
        public int Code { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

    }
}
