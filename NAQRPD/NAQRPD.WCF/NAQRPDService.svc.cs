using NAQRPD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NAQRPD.WCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“NAQRPDService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 NAQRPDService.svc 或 NAQRPDService.svc.cs，然后开始调试。
    public class NAQRPDService : INAQRPDService
    {
        #region Station
        /// <summary>
        /// 站点最新实时发布数据
        /// </summary>
        /// <returns></returns>
        public List<AQRPD> GetAQRPSDLive()
        {
            List<AQRPD> list = DataQuery.GetLive<AQRPD>("AQRPSDLive");
            return list;
        }

        /// <summary>
        /// 站点最新滑动24小时数据
        /// </summary>
        /// <returns></returns>
        public List<AQDPD> GetAQSPSDLive()
        {
            List<AQDPD> list = DataQuery.GetLive<AQDPD>("AQSPSDLive");
            return list;
        }

        /// <summary>
        /// 站点历史实时发布数据
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<AQRPD> GetAQRPSDHistory(DateTime beginTime, DateTime endTime)
        {
            List<AQRPD> list = DataQuery.GetHistory<AQRPD>("AQRPSDHistory", beginTime, endTime);
            return list;
        }

        /// <summary>
        /// 站点最新日均发布数据
        /// </summary>
        /// <returns></returns>
        public List<AQDPD> GetAQDPSDLive()
        {
            List<AQDPD> list = DataQuery.GetLive<AQDPD>("AQDPSDLive");
            return list;
        }

        /// <summary>
        /// 站点历史日均发布数据
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<AQDPD> GetAQDPSDHistory(DateTime beginTime, DateTime endTime)
        {
            List<AQDPD> list = DataQuery.GetHistory<AQDPD>("AQDPSDHistory", beginTime, endTime);
            return list;
        }
        #endregion
        #region City
        /// <summary>
        /// 城市最新实时发布数据
        /// </summary>
        /// <returns></returns>
        public List<AQRPD> GetAQRPCDLive()
        {
            List<AQRPD> list = DataQuery.GetLive<AQRPD>("AQRPCDLive");
            return list;
        }

        /// <summary>
        /// 城市历史实时发布数据
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<AQRPD> GetAQRPCDHistory(DateTime beginTime, DateTime endTime)
        {
            List<AQRPD> list = DataQuery.GetHistory<AQRPD>("AQRPCDHistory", beginTime, endTime);
            return list;
        }

        /// <summary>
        /// 城市最新日均发布数据
        /// </summary>
        /// <returns></returns>
        public List<AQDPD> GetAQDPCDLive()
        {
            List<AQDPD> list = DataQuery.GetLive<AQDPD>("AQDPCDLive");
            return list;
        }

        /// <summary>
        /// 城市历史日均发布数据
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public List<AQDPD> GetAQDPCDHistory(DateTime beginTime, DateTime endTime)
        {
            List<AQDPD> list = DataQuery.GetHistory<AQDPD>("AQDPCDHistory", beginTime, endTime);
            return list;
        }
        #endregion
    }
}
