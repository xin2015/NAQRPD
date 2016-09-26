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
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetIndexData()
        {
            List<AQRPDView> list;
            if (HttpContext.Request.UrlReferrer.AbsoluteUri == "http://cityphoto.suncereltd.cn:18407/Home/Index") list = DataQuery.GetLive<AQRPDView>("View_AQRPCDLive");
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
            if (HttpContext.Request.UrlReferrer.AbsoluteUri == "http://cityphoto.suncereltd.cn:18407/Home/CityDayPublish") list = DataQuery.GetLive<AQDPDView>("View_AQDPCDLive");
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
            if (HttpContext.Request.UrlReferrer.AbsoluteUri == "http://cityphoto.suncereltd.cn:18407/Home/StationRealtimePublish") list = DataQuery.GetLive<AQRPDView>("View_AQRPSDLive");
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
            if (HttpContext.Request.UrlReferrer.AbsoluteUri == "http://cityphoto.suncereltd.cn:18407/Home/StationDayPublish") list = DataQuery.GetLive<AQDPDView>("View_AQDPSDLive");
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