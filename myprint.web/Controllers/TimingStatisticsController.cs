using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myprint.BLL.impl;

namespace print.Controllers
{
    public class TimingStatisticsController : Controller
    {
        // GET: TimingStatistics
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 日记录
        /// </summary>
        /// <returns></returns>
        public ActionResult DayStatistical()
        {
            OrderDayBLLImpl orderDayBLLImpl = new OrderDayBLLImpl();
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            var start = new DateTime(year, month, day, 0, 0, 0);
            var end = new DateTime(year, month, day, 23, 59, 59);

            ViewBag.Message = orderDayBLLImpl.dayStatistical(start, end);

            return View("Index");
        }

        /// <summary>
        /// 月记录
        /// </summary>
        /// <returns></returns>
        public ActionResult MonthStatistical()
        {
            OrderMonthBLLImpl orderMonthBLLImpl = new OrderMonthBLLImpl();
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            DateTime CurDate = Convert.ToDateTime(DateTime.Now.ToString());  // 组装当前指定月份
            var start = new DateTime(year, month, 1);
            var end = CurDate.AddDays(1 - CurDate.Day).AddMonths(1).AddDays(-1);

            ViewBag.Message = orderMonthBLLImpl.monthStatistical(start, end);

            return View("Index");
        }

        public ActionResult YearStatistical()
        {
            OrderYearBLLImpl orderYearBLLImpl = new OrderYearBLLImpl();
            var year = DateTime.Now.Year;
            var start = new DateTime(year, 1, 1);
            var end = new DateTime(year, 12, 31, 23, 59,59);
            ViewBag.Message = orderYearBLLImpl.yearStatistical(start, end);
            return View("Index");
        }
    }

   
}