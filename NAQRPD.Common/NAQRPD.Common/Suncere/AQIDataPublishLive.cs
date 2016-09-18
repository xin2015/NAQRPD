using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Common.Suncere
{
    public class AQIDataPublishLive
    {
        public string Area { get; set; }
        public string StationCode { get; set; }
        public string PositionName { get; set; }
        public DateTime TimePoint { get; set; }
        public string SO2 { get; set; }
        public string SO2_24h { get; set; }
        public string NO2 { get; set; }
        public string NO2_24h { get; set; }
        public string PM10 { get; set; }
        public string PM10_24h { get; set; }
        public string CO { get; set; }
        public string CO_24h { get; set; }
        public string O3 { get; set; }
        public string O3_24h { get; set; }
        public string O3_8h { get; set; }
        public string O3_8h_24h { get; set; }
        public string PM2_5 { get; set; }
        public string PM2_5_24h { get; set; }
        public string AQI { get; set; }
        public string PrimaryPollutant { get; set; }
        public string Quality { get; set; }
        public string Unheathful { get; set; }
        public string Measure { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
