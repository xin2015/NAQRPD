using Common.Logging;
using NAQRPD.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Service
{
    public class MissingData
    {
        public string Code { get; set; }
        public DateTime Time { get; set; }
        public int MissTimes { get; set; }
        public bool Status { get; set; }
        public string Exception { get; set; }
        public string MCode { get; set; }
        public string PCode { get; set; }
        public DateTime CTime { get; set; }
    }

    public class MissingDataHelper
    {
        static ILog logger = LogManager.GetLogger<MissingDataHelper>();

        public static List<MissingData> GetList()
        {
            List<MissingData> list = new List<MissingData>();
            //TODO 添加数据获取代码
            return list;
        }

        public static List<MissingData> GetList(string code)
        {
            List<MissingData> list;
            try
            {
                string cmdText = "select * from MissingData where Code = @Code";
                SqlParameter param = new SqlParameter("@Code", code);
                list = SqlHelper.Default.ExecuteList<MissingData>(cmdText, param);
            }
            catch (Exception e)
            {
                list = new List<MissingData>();
                logger.Error("GetList failed.", e);
            }
            return list;
        }

        public static List<MissingData> GetList(DateTime time)
        {
            List<MissingData> list;
            try
            {
                string cmdText = "select * from MissingData where Time = @Time";
                SqlParameter param = new SqlParameter("@Time", time);
                list = SqlHelper.Default.ExecuteList<MissingData>(cmdText, param);
            }
            catch (Exception e)
            {
                list = new List<MissingData>();
                logger.Error("GetList failed.", e);
            }
            return list;
        }

        public static void Insert(MissingData missingData)
        {
            //TODO 添加插入代码
        }

        public static void Update(List<MissingData> list)
        {
            //TODO 添加更新代码
        }


    }
}
