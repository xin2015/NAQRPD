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
            TableName = "AQRPCDLive";
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
                List<AQRPD> list = DataQuery.GetAQRPCDFromLive();
                SqlHelper.Default.ExecuteNonQuery(string.Format("delete {0}", TableName));
                DataTable dt = list.GetDataTable(TableName);
                SqlHelper.Default.Insert(dt);
                dt.TableName = TableName.Replace("Live", "History");
                SqlHelper.Default.Insert(dt);
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
                        List<AQRPD> list = DataQuery.GetAQRPCDFromHistory(o.CTime, o.CTime);
                        if (list.Any())
                        {
                            DateTime liveTime = DateTime.Now;
                            DataTable dt;
                            if (list.First().Time > liveTime)
                            {
                                SqlHelper.Default.ExecuteNonQuery(string.Format("delete {0}", TableName));
                                dt = list.GetDataTable(TableName);
                                SqlHelper.Default.Insert(dt);
                                dt.TableName = TableName.Replace("Live", "History");
                            }
                            else
                            {
                                dt = list.GetDataTable(TableName.Replace("Live", "History"));
                            }
                            SqlHelper.Default.Insert(dt);
                            o.Status = true;
                        }
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
                logger.Error("SyncAQRPCDJob.Recover failed.", e);
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
            logger.Error("SyncAQRPCD failed.", e);
        }
    }
}
