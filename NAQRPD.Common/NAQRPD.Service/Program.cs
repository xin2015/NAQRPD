using NAQRPD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AQRPD> src = DataQuery.GetAQRPCDFromHistory(new DateTime(2010, 1, 1), DateTime.Today);
            src = src.OrderByDescending(o => o.AQI).ToList();
            List<AQRPD> app = new List<AQRPD>();
            src.ForEach(o =>
            {
                AQRPD data = new AQRPD();
                data.SO2 = o.SO2;
                data.NO2 = o.NO2;
                data.PM10 = o.PM10;
                data.CO = o.CO;
                data.O3 = o.O3;
                data.PM25 = o.PM25;
                data.CalculateAQI();
                app.Add(data);
            });
            for (int i = 0; i < src.Count; i++)
            {
                if (src[i].AQI != app[i].AQI) Console.WriteLine("src:{0},app:{1}", src[i].AQI, app[i].AQI);
            }
            Console.ReadLine();
        }
    }
}
