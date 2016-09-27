using Common.Logging;
using NAQRPD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAQRPD.Web.Controllers
{
    public class HomeController : Controller
    {
        static ILog logger = LogManager.GetLogger<HomeController>();
        static Dictionary<string, int> dic = new Dictionary<string, int>();

        private bool Validate()
        {
            if (dic.ContainsKey(Request.UserHostAddress)) dic[Request.UserHostAddress]++;
            else dic[Request.UserHostAddress] = 1;
            if (dic[Request.UserHostAddress] % 100 == 0) logger.InfoFormat("{0}：{1}", Request.UserHostAddress, dic[Request.UserHostAddress]);
            return dic[Request.UserHostAddress] < 30000 && Request.Url.Host == Request.UrlReferrer.Host;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetIndexData()
        {
            List<AQRPDView> list;
            if (Validate()) list = DataQuery.GetLive<AQRPDView>("View_AQRPCDLive");
            else list = new List<AQRPDView>();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CityDayPublish()
        {
            return View();
        }

        public JsonResult GetCityDayPublishData()
        {
            List<AQDPDView> list;
            if (Validate()) list = DataQuery.GetLive<AQDPDView>("View_AQDPCDLive");
            else list = new List<AQDPDView>();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult StationRealtimePublish()
        {
            return View();
        }

        public JsonResult GetStationRealtimePublishData()
        {
            List<AQRPDView> list;
            if (Validate()) list = DataQuery.GetLive<AQRPDView>("View_AQRPSDLive");
            else list = new List<AQRPDView>();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult StationDayPublish()
        {
            return View();
        }

        public JsonResult GetStationDayPublishData()
        {
            List<AQDPDView> list;
            if (Validate()) list = DataQuery.GetLive<AQDPDView>("View_AQDPSDLive");
            else list = new List<AQDPDView>();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}