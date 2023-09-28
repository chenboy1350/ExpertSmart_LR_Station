using Newtonsoft.Json;
using System.Collections.Generic;

namespace LR_Station
{
    public class PVChartData
    {
        public string hn;
        public string message;
        public int code;

        [JsonProperty(PropertyName = "ChartData", NullValueHandling = NullValueHandling.Ignore)]
        public List<ChartData> PVList;
    }

    public class ChartData
    {
        public string PV_Dilate;
        public string PV_Station;
    }
}