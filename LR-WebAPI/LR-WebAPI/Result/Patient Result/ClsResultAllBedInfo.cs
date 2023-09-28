using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LR_WebAPI
{
    public class ClsResultAllBedInfo : ClsResultMessage
    {
        public ClsResultAllBedInfo()
        { }

        public List<ClsAllBedInfo> BedList { get; set; }
    }

    [Serializable]
    public class ClsAllBedInfo
    {
        public ClsAllBedInfo()
        { }

        [JsonProperty("hn")]
        public string hn { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("bed")]
        public int bed { get; set; }

        [JsonProperty("zone")]
        public string zone { get; set; }
    }
}
