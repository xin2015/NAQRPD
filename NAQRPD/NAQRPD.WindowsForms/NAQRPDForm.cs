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
        static DateTime beginTime;
        static DateTime endTime;

        public NAQRPDForm()
        {
            InitializeComponent();
        }

        private bool GetTime()
        {
            bool result= DateTime.TryParse(textBox1.Text, out beginTime) && DateTime.TryParse(textBox2.Text, out endTime);
            if (!result) textBox3.Text = "获取时间失败";
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetTime())
                {
                    List<AQRPD> stationList = DataQuery.GetAQRPSDFromHistory(beginTime, endTime);
                    SqlHelper.Default.Insert(stationList.GetDataTable("AQRPSDHistory"));
                    textBox3.Text = string.Format("Succeed,{0}", DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                textBox3.Text = string.Format("failed,{0}", DateTime.Now);
                logger.Error("Insert AQRPSDHistory failed.", ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetTime())
                {
                    List<AQRPD> list = DataQuery.GetAQRPCDFromHistory(beginTime, endTime);
                    SqlHelper.Default.Insert(list.GetDataTable("AQRPCDHistory"));
                    textBox3.Text = string.Format("Succeed,{0}", DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                textBox3.Text = string.Format("failed,{0}", DateTime.Now);
                logger.Error("Insert AQRPCDHistory failed.", ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetTime())
                {
                    List<AQDPD> stationList = DataQuery.GetAQDPSDFromHistory(beginTime, endTime);
                    SqlHelper.Default.Insert(stationList.GetDataTable("AQDPSDHistory"));
                    textBox3.Text = string.Format("Succeed,{0}", DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                textBox3.Text = string.Format("failed,{0}", DateTime.Now);
                logger.Error("Insert AQDPSDHistory failed.", ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetTime())
                {
                    List<AQDPD> stationList = DataQuery.GetAQDPCDFromHistory(beginTime, endTime);
                    SqlHelper.Default.Insert(stationList.GetDataTable("AQDPCDHistory"));
                    textBox3.Text = string.Format("Succeed,{0}", DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                textBox3.Text = string.Format("failed,{0}", DateTime.Now);
                logger.Error("Insert AQDPCDHistory failed.", ex);
            }
        }
    }
}
