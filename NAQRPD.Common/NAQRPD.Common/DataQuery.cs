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
        static string liveString = "select * from {0}";
        static string historyString = "select * from {0} where TimePoint between @BeginTime and @EndTime";

        //public static List<T> GetLive<T>(string tableName) where T : class, new()
        //{
        //    List<T> list;
        //    try
        //    {
        //        list = SqlHelper.EnvPublish.ExecuteList<T>(string.Format(liveString, tableName));
        //    }
        //    catch (Exception e)
        //    {
        //        list = new List<T>();
        //        logger.Error(string.Format("Get {0} failed.", tableName), e);
        //    }
        //    return list;
        //}

        //public static List<T> GetHistory<T>(string tableName, DateTime beginTime, DateTime endTime) where T : class, new()
        //{
        //    List<T> list;
        //    try
        //    {
        //        SqlParameter[] parameters = new SqlParameter[] {
        //            new SqlParameter("@BeginTime",beginTime),
        //            new SqlParameter("@EndTime",endTime)
        //        };
        //        list = SqlHelper.EnvPublish.ExecuteList<T>(string.Format(historyString, tableName), parameters);
        //    }
        //    catch (Exception e)
        //    {
        //        list = new List<T>();
        //        logger.Error(string.Format("Get {0} failed.", tableName), e);
        //    }
        //    return list;
        //}

        public static DataTable GetLive(string tableName)
        {
            DataTable dt;
            try
            {
                dt = SqlHelper.EnvPublish.ExecuteDataTable(string.Format(liveString, tableName));
                dt.TableName = tableName;
            }
            catch (Exception e)
            {
                dt = new DataTable();
                logger.Error(string.Format("Get {0} failed.", tableName), e);
            }
            return dt;
        }

        public static DataTable GetHistory(string tableName, DateTime beginTime, DateTime endTime)
        {
            DataTable dt;
            try
            {
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@BeginTime",beginTime),
                    new SqlParameter("@EndTime",endTime)
                };
                dt = SqlHelper.EnvPublish.ExecuteDataTable(string.Format(historyString, tableName), parameters);
                dt.TableName = tableName;
            }
            catch (Exception e)
            {
                dt = new DataTable();
                logger.Error(string.Format("Get {0} failed.", tableName), e);
            }
            return dt;
        }
    }
}
