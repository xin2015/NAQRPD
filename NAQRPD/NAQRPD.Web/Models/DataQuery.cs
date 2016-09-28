using NAQRPD.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAQRPD.Web.Models
{
    public class DataQuery
    {
        public static Dictionary<string, string> pollutantCodeHtmlDic { get; set; }
        static DataQuery()
        {
            pollutantCodeHtmlDic = new Dictionary<string, string>();
            //pollutantCodeHtmlDic.Add("AQI", "AQI");
            pollutantCodeHtmlDic.Add("SO2", "SO<sub>2</sub>");
            pollutantCodeHtmlDic.Add("NO2", "NO<sub>2</sub>");
            pollutantCodeHtmlDic.Add("PM10", "PM<sub>10</sub>");
            pollutantCodeHtmlDic.Add("CO", "CO");
            pollutantCodeHtmlDic.Add("O3", "O<sub>3</sub>");
            pollutantCodeHtmlDic.Add("PM25", "PM<sub>2.5</sub>");
        }
        public static List<SelectListItem> GetProvinceSelectList()
        {
            DataTable dt = SqlHelper.Default.ExecuteDataTable("select * from Province where ProvinceCode != 710000");
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow dr in dt.Rows)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr["ProvinceCode"].ToString().Substring(0, 2);
                item.Text = dr["ProvinceName"].ToString();
                list.Add(item);
            }
            return list;
        }

        public static List<SelectListItem> GetPollutantSelectList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var dicItem in pollutantCodeHtmlDic)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dicItem.Key;
                item.Text = dicItem.Value;
                list.Add(item);
            }
            return list;
        }
    }
}