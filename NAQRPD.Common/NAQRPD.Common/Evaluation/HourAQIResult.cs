using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Common.Evaluation
{
    /// <summary>
    /// 空气质量指数详细结果
    /// </summary>
    public class HourAQIResult : HourAQIReport, IAQIResult
    {
        /// <summary>
        /// 对健康影响情况
        /// </summary>
        public string Effect { get; set; }
        /// <summary>
        /// 建议采取的措施
        /// </summary>
        public string Measure { get; set; }
        /// <summary>
        /// 超标污染物
        /// </summary>
        public string NonAttainmentPollutant { get; set; }

        /// <summary>
        /// 构造函数（赋初值）
        /// </summary>
        public HourAQIResult()
        {
            Effect = AQIHelper.EmptyValueString;
            Measure = AQIHelper.EmptyValueString;
            NonAttainmentPollutant = AQIHelper.EmptyValueString;
        }

        /// <summary>
        /// 计算对健康影响情况和建议采取的措施
        /// </summary>
        public virtual void CalculateEffectAndMeasure()
        {
            AQIHelper.CalculateEffectAndMeasure(this);
        }

        /// <summary>
        /// 计算超标污染物
        /// </summary>
        public virtual void CalculateNonAttainmentPollutant()
        {
            AQIHelper.CalculateNonAttainmentPollutant(this);
        }

        /// <summary>
        /// 计算空气质量指数详细结果
        /// </summary>
        public virtual void CalculateAQIResult()
        {
            AQIHelper.CalculateHourAQI(this);
        }
    }
}
