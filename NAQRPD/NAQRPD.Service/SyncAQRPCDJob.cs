﻿using Common.Logging;
using NAQRPD.Common;
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
        public static string FastRecoverJob { get; set; }

        static SyncAQRPCDJob()
        {
            logger = LogManager.GetLogger<SyncAQRPCDJob>();
            CronExpression = Configuration.SyncAQRPCDJobCronExpression;
            TableName = "AQRPCDLive";
            FastRecoverJob = "FastRecoverRDJob";
        }

        public void Execute(IJobExecutionContext context)
        {
            Recover();
            Sync();
        }

        public static void FastRecover(MissingData missingData)
        {
            try
            {
                try
                {
                    List<AQRPD> list = DataQuery.GetAQRPCDFromLive();
                    if (list.Any())
                    {
                        SqlHelper.Default.ExecuteNonQuery(string.Format("delete {0}", TableName));
                        DataTable dt = list.GetDataTable(TableName);
                        SqlHelper.Default.Insert(dt);
                        dt.TableName = TableName.Replace("Live", "History");
                        SqlHelper.Default.Insert(dt);
                        missingData.Status = true;
                    }
                }
                catch (Exception e)
                {
                    missingData.Exception = e.Message;
                }
                missingData.Time = DateTime.Now;
                MissingDataHelper.Update(missingData);
            }
            catch (Exception e)
            {
                logger.Error("FastRecover failed.", e);
            }
        }

        void Sync()
        {
            try
            {
                List<AQRPD> list = DataQuery.GetAQRPCDFromLive();
                if (list.Any())
                {
                    SqlHelper.Default.ExecuteNonQuery(string.Format("delete {0}", TableName));
                    DataTable dt = list.GetDataTable(TableName);
                    SqlHelper.Default.Insert(dt);
                    dt.TableName = TableName.Replace("Live", "History");
                    SqlHelper.Default.Insert(dt);
                }
                else
                {
                    Fail(new Exception());
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
                List<MissingData> missingDataList = MissingDataHelper.GetList(TableName);
                missingDataList.ForEach(o =>
                {
                    try
                    {
                        List<AQRPD> list = DataQuery.GetAQRPCDFromHistory(o.CTime);
                        if (list.Any())
                        {
                            DateTime liveTime = DataQuery.GetLiveTime(TableName);
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
                        else
                        {
                            o.MissTimes += 1;
                            o.Time = DateTime.Now;
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
