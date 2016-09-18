using Common.Logging;
using NAQRPD.Common;
using NAQRPD.Common.Evaluation;
using NAQRPD.Common.Suncere;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Service
{
    class SyncAQRPCDJob : IJob
    {
        private static ILog logger;
        public static string CronExpression { get; set; }
        public static string TableName { get; set; }

        static SyncAQRPCDJob()
        {
            logger = LogManager.GetLogger<SyncAQRPCDJob>();
            CronExpression = Configuration.SyncAQRPCDJobCronExpression;
            TableName = "AQIDataPublishLive";
        }

        public void Execute(IJobExecutionContext context)
        {
            Sync();
            Recover();
        }

        void Sync()
        {
            try
            {
                DataTable dt = DataQuery.GetLive(TableName);
                List<AQIDataPublishLive> liveList = dt.GetList<AQIDataPublishLive>();
                List<HourAQICalculate> list = DataConvert.ToHourAQICalculate(liveList);
                SqlHelper.Default.ExecuteNonQuery(string.Format("delete {0}", TableName));
                SqlHelper.Default.Insert(dt);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                if (!e.Message.Contains("插入重复键"))
                {
                    Fail(e);
                }
            }
            catch (Exception e)
            {
                Fail(e);
            }
        }

        void Recover()
        {
            try
            {
                List<MissingData> missingDataList = MissingDataHelper.GetList();
                missingDataList.ForEach(o =>
                {
                    try
                    {
                        List<HourAQIReport> list = GetHistoryData(o);
                        SqlHelper.Default.Insert(list.GetDataTable(TableName));
                        o.Status = true;
                    }
                    catch (Exception e)
                    {
                        o.Exception = e.Message;
                        o.MissTimes += 1;
                        o.Time = DateTime.Now;
                    }
                });
                MissingDataHelper.Update(missingDataList);
            }
            catch (Exception e)
            {
                logger.Error("SyncAQMCRDataJob.Recover failed.", e);
            }
        }

        void Fail(Exception e)
        {
            MissingData missingData = new MissingData();
            missingData.Code = TableName;
            missingData.Time = DateTime.Now;
            missingData.CTime = DateTime.Today.AddHours(DateTime.Now.Hour);
            missingData.Exception = e.Message;
            MissingDataHelper.Insert(missingData);
            logger.Error("SyncAQMCRData failed.", e);
        }

        List<HourAQIReport> GetRealtimeData()
        {
            List<HourAQIReport> list = new List<HourAQIReport>();
            //TODO 添加数据获取代码
            return list;
        }

        List<HourAQIReport> GetHistoryData(object condition)
        {
            List<HourAQIReport> list = new List<HourAQIReport>();
            //TODO 添加数据获取代码
            return list;
        }
    }
}
