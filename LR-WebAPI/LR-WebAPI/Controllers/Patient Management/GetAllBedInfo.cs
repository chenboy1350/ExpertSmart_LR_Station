using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;
using LR_WebAPI;

namespace LR_WebAPI
{
    [Route("LR_WebAPI/GetAllBedInfo")]
    [ApiController]

    public class GetAllBedInfo
    {
        [HttpGet]
        public ActionResult<ClsResultMessage> Get()
        {
            try
            {
                APILibrary apiLibrary = new APILibrary();
                DataTable dtBedInfo = apiLibrary.GetAllBedInfo();
                ClsResultAllBedInfo resultAllBedInfo = null;

                if (dtBedInfo.Rows != null && dtBedInfo.Rows.Count > 0)
                {
                    resultAllBedInfo = new ClsResultAllBedInfo();
                    resultAllBedInfo.BedList = new List<ClsAllBedInfo>();
                    foreach (DataRow row in dtBedInfo.Rows)
                    {
                        ClsAllBedInfo allBed = new ClsAllBedInfo();
                        allBed.bed = Convert.ToInt32(row["bed_no"]);
                        if(row["pt_hn"] != null)
                        {
                            allBed.hn = (string)row["pt_hn"];
                        }
                        else
                        {
                            allBed.hn = "";
                        }
                        if (row["pt_name"] != null)
                        {
                            allBed.name = (string)row["pt_name"];
                        }
                        else
                        {
                            allBed.name = "";
                        }
                        allBed.zone = (string)row["bed_zone"];
                        resultAllBedInfo.BedList.Add(allBed);
                    }
                }

                if (resultAllBedInfo != null)
                {
                    resultAllBedInfo.Code = 100;
                    resultAllBedInfo.Message = "Success";
                    return resultAllBedInfo;
                }
                else
                {
                    throw new Exception("Data not found");
                }
            }
            catch(Exception ex)
            {
                ClsResultMessage clsResult = new ClsResultMessage(201, ex.Message);
                return clsResult;
            }
        }
    }
}
