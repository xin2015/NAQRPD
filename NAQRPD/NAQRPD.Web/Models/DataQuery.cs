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
    }
}