using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Common
{
    public class Configuration
    {
        /// <summary>
        /// 默认数据库连接
        /// </summary>
        public static string DefaultConnection { get; set; }
        /// <summary>
        /// 全国空气质量实时发布平台数据库连接
        /// </summary>
        public static string EnvPublishConnection { get; set; }

        static Configuration()
        {
            DefaultConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            EnvPublishConnection = System.Configuration.ConfigurationManager.ConnectionStrings["EnvPublishConnection"].ConnectionString;
        }
    }
}
