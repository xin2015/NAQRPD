using Common.Logging;
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
    class SyncOtherDJob : IJob
    {
        private static ILog logger;
        public static string CronExpression { get; set; }

        static SyncOtherDJob()
        {
            logger = LogManager.GetLogger<SyncOtherDJob>();
            CronExpression = Configuration.SyncOtherDJobCronExpression;
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                string[] tableNames = Configuration.OtherTables.Split(',');
                foreach (string tableName in tableNames)
                {
                    DataTable dt = SqlHelper.EnvPublish.ExecuteDataTable(string.Format("select * from {0}", tableName));
                    dt.TableName = tableName;
                    SqlHelper.Default.ExecuteNonQuery(string.Format("delete {0}", tableName));
                    SqlHelper.Default.Insert(dt);
                }
            }
            catch (Exception e)
            {
                logger.Error("SyncOtherDJob Execute failed.", e);
            }
        }
    }
}
