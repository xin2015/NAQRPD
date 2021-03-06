﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAQRPD.Common.Evaluation
{
    /// <summary>
    /// 空气质量指数日报（计算）
    /// </summary>
    public class DayAQIReport : DayAQICalculate, IAQIReport
    {
        /// <summary>
        /// 二氧化硫（SO2）24小时平均分指数
        /// </summary>
        public int? ISO2 { get; set; }
        /// <summary>
        /// 二氧化氮（NO2）24小时平均分指数
        /// </summary>
        public int? INO2 { get; set; }
        /// <summary>
        /// 颗粒物（粒径小于等于10μm）24小时平均分指数
        /// </summary>
        public int? IPM10 { get; set; }
        /// <summary>
        /// 一氧化碳（CO）24小时平均分指数
        /// </summary>
        public int? ICO { get; set; }
        /// <summary>
        /// 臭氧（O3）最大8小时滑动平均分指数
        /// </summary>
        public int? IO3 { get; set; }
        /// <summary>
        /// 颗粒物（粒径小于等于2.5μm）24小时平均分指数
        /// </summary>
        public int? IPM25 { get; set; }
        /// <summary>
        /// 空气质量指数级别
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 空气质量指数类别颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 计算空气质量分指数
        /// </summary>
        public virtual void CalculateIAQI()
        {
            AQIHelper.CalculateDayIAQI(this);
        }

        /// <summary>
        /// 计算AQI相关（需要已经先计算好空气质量指数类别）
        /// </summary>
        public virtual void CalculateAQIAbout()
        {
            AQIHelper.CalculateAQIAboutByType(this);
        }

        /// <summary>
        /// 计算空气质量指数日报
        /// </summary>
        public virtual void CalculateAQIReport()
        {
            AQIHelper.CalculateDayAQI(this);
        }
    }
}
