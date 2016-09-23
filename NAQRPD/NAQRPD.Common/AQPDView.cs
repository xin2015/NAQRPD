using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAQRPD.Common
{
    public class AQRPDView : AQRPD
    {
        public string Name { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }

    public class AQDPDView : AQDPD
    {
        public string Name { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}