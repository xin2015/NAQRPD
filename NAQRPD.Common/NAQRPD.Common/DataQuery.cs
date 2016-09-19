using Common.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Common
{
    public static class DataQuery
    {
        static ILog logger = LogManager.GetLogger("DataQuery");

        public static List<AQRPD> GetAQRPCDFromLive()
        {
            List<AQRPD> list;
            try
            {
                string cmdText = "select UniqueCode Code,TimePoint Time,(case when SO2 = '—' then null else SO2 end) SO2,(case when NO2 = '—' then null else NO2 end) NO2,(case when PM10 = '—' then null else PM10 end) PM10,(case when CO = '—' then null else CO end) CO,(case when O3_24h = '—' then null else O3_24h end) O3,(case when PM2_5 = '—' then null else PM2_5 end) PM25,(case when AQI = '—' then null else AQI end) AQI,(case when PrimaryPollutant = '—' then null else PrimaryPollutant end) PrimaryPollutant,(case when Quality = '—' then null else Quality end) Type from AQIDataPublishLive a join StationConfig b on a.StationCode = b.StationCode";
                list = SqlHelper.EnvPublish.ExecuteList<AQRPD>(cmdText);
            }
            catch (Exception e)
            {
                list = new List<AQRPD>();
                logger.Error("GetAQRPCDFromLive failed.", e);
            }
            return list;
        }

        public static List<AQRPD> GetAQRPCDFromHistory(DateTime beginTime, DateTime endTime)
        {
            List<AQRPD> list;
            try
            {
                string cmdText = "select UniqueCode Code,TimePoint Time,(case when SO2 = '—' then null else SO2 end) SO2,(case when NO2 = '—' then null else NO2 end) NO2,(case when PM10 = '—' then null else PM10 end) PM10,(case when CO = '—' then null else CO end) CO,(case when O3_24h = '—' then null else O3_24h end) O3,(case when PM2_5 = '—' then null else PM2_5 end) PM25,(case when AQI = '—' then null else AQI end) AQI,(case when PrimaryPollutant = '—' then null else PrimaryPollutant end) PrimaryPollutant,(case when Quality = '—' then null else Quality end) Type from AQIDataPublishHistory a join Station b on a.StationCode = b.StationCode where TimePoint between @BeginTime and @EndTime";
                SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@BeginTime",beginTime),
                    new SqlParameter("@EndTime",endTime)
                };
                list = SqlHelper.EnvPublish.ExecuteList<AQRPD>(cmdText, parameters);
            }
            catch (Exception e)
            {
                list = new List<AQRPD>();
                logger.Error("GetAQRPCDFromHistory failed.", e);
            }
            return list;
        }
    }
}
