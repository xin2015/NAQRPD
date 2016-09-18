using Common.Logging;
using NAQRPD.Common.Evaluation;
using NAQRPD.Common.Suncere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Common
{
    public static class DataConvert
    {
        static ILog logger = LogManager.GetLogger("DataConvert");
        static string emptyValueString = "—";

        public static HourAQICalculate ToHourAQICalculate(AQIDataPublishLive source)
        {
            HourAQICalculate hac = new HourAQICalculate();
            if (source.SO2 != emptyValueString) hac.SO2 = decimal.Parse(source.SO2);
            if (source.NO2 != emptyValueString) hac.NO2 = decimal.Parse(source.NO2);
            if (source.PM10 != emptyValueString) hac.PM10 = decimal.Parse(source.PM10);
            if (source.CO != emptyValueString) hac.CO = decimal.Parse(source.CO);
            if (source.O3_24h != emptyValueString) hac.O3 = decimal.Parse(source.O3_24h);
            if (source.PM2_5 != emptyValueString) hac.PM25 = decimal.Parse(source.PM2_5);
            hac.CalculateAQI();
            return hac;
        }

        public static List<HourAQICalculate> ToHourAQICalculate(List<AQIDataPublishLive> sourceList)
        {
            List<HourAQICalculate> list = new List<HourAQICalculate>();
            try
            {
                sourceList.ForEach(o => list.Add(ToHourAQICalculate(o)));
            }
            catch(Exception e)
            {
                logger.Error("ToHourAQICalculate failed.", e);
            }
            return list;
        }
    }
}
