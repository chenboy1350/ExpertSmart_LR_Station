using Newtonsoft.Json;
using System.Collections.Generic;

namespace LR_Station
{
    public class AllBedInfo
    {
        public string message;
        public int code;

        [JsonProperty(PropertyName = "bedList", NullValueHandling = NullValueHandling.Ignore)]
        public List<BedList> bedList;
    }

    public class BedList
    {
        public string hn;
        public string name;
        public int bed;
        public string zone;
    }
}