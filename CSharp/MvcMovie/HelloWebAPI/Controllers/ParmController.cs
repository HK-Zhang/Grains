using HelloWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWebAPI.Controllers
{
    public class ParmController : ApiController
    {
        [HttpGet]
        public string GetAllChargingData(int id, string name)
        {
            return "ChargingData" + id;
        }

        [HttpGet]
        public string GetByModel(TB_CHARGING oData)
        {
            return "ChargingData" + oData.ID;
        }

        //Tested, request doesn't route to this action as exception.
        [HttpGet]
        public string GetAllChargingData([FromUri]TB_CHARGING obj)
        {
            return "ChargingData" + obj.ID;
        }

        [HttpGet]
        public string GetByModel(string strQuery)
        {
            TB_CHARGING oData = Newtonsoft.Json.JsonConvert.DeserializeObject<TB_CHARGING>(strQuery);
            return "ChargingData" + oData.ID;
        }

        //[HttpPost]
        //public bool SaveData([FromBody]string NAME)
        //{
        //    return true;
        //}

        //[HttpPost]
        //public object SaveObject(dynamic obj)
        //{
        //    var strName = Convert.ToString(obj.NAME);
        //    return strName;
        //}

        //[HttpPost]
        //public bool SaveData(TB_CHARGING oData)
        //{
        //    return true;
        //}

        //[HttpPost]
        //public object SaveJsonData(dynamic obj)
        //{
        //    var strName = Convert.ToString(obj.NAME);
        //    var oCharging = Newtonsoft.Json.JsonConvert.DeserializeObject<TB_CHARGING>(Convert.ToString(obj.Charging));
        //    return strName;
        //}

        //[HttpPost]
        //public bool SaveArrData(string[] ids)
        //{
        //    return true;
        //}

        [HttpPost]
        public bool SaveListData(List<TB_CHARGING> lstCharging)
        {
            return true;
        }
    }
}
