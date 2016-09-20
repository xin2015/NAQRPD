using Common.Logging;
using NAQRPD.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAQRPD.WindowsForms
{
    public partial class NAQRPDForm : Form
    {
        static ILog logger = LogManager.GetLogger<NAQRPDForm>();

        public NAQRPDForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime beginTime = new DateTime(2016, 1, 1);
            DateTime endTime = new DateTime(2016, 9, 20, 12, 0, 0);
            try
            {
                List<AQRPD> stationList = DataQuery.GetAQRPSDFromHistory(beginTime, endTime);
                SqlHelper.Default.Insert(stationList.GetDataTable("AQRPSDHistory"));
            }
            catch (Exception ex)
            {
                logger.Error("Insert AQRPSDHistory failed.", ex);
            }
            try
            {
                List<AQRPD> cityList = DataQuery.GetAQRPCDFromHistory(beginTime, endTime);
                SqlHelper.Default.Insert(cityList.GetDataTable("AQRPCDHistory"));
            }
            catch (Exception ex)
            {
                logger.Error("Insert AQRPSDHistory failed.", ex);
            }
            endTime = DateTime.Today.AddDays(-1);
            try
            {
                List<AQDPD> stationList = DataQuery.GetAQDPSDFromHistory(beginTime, endTime);
                SqlHelper.Default.Insert(stationList.GetDataTable("AQDPSDHistory"));
            }
            catch (Exception ex)
            {
                logger.Error("Insert AQDPSDHistory failed.", ex);
            }
            try
            {
                List<AQDPD> cityList = DataQuery.GetAQDPCDFromHistory(beginTime, endTime);
                SqlHelper.Default.Insert(cityList.GetDataTable("AQDPCDHistory"));
            }
            catch (Exception ex)
            {
                logger.Error("Insert AQDPCDHistory failed.", ex);
            }
            textBox1.Text = "Done";
        }
    }
}
