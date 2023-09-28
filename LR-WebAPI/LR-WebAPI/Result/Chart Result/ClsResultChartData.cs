using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LR_WebAPI
{
    public class ClsResultChartData : ClsResultMessage
    {
        public ClsResultChartData()
        { }

        [JsonProperty("hn")]
        public string hn { get; set; }

        public List<ClsChartData> ChartData { get; set; }
    }

    [Serializable]
    public class ClsChartData
    {
        public ClsChartData()
        { }

        [JsonProperty("PV_Dilate")]
        public int PV_Dilate { get; set; }

        [JsonProperty("PV_Station")]
        public int PV_Station { get; set; }
    }
}
