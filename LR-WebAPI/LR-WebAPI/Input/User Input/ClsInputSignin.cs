using Newtonsoft.Json;

namespace LR_WebAPI.Input.User_Input
{
    public class ClsInputSignin
    {
        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }
    }
}
