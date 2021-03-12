using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myprint.Entity;
using myprint.BLL;
using myprint.BLL.impl;

namespace print.Controllers
{
    public class PrintOrderController : Controller
    {


        // GET: PrintOrder
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Day()
        {
            return View();
        }

        public ActionResult Month()
        {
            return View();
        }

        public ActionResult Year()
        {
            return View();
        }

        /// <summary>
        /// 打印记录分页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult IndexPage(string draw, string start, string length)
        {
            PrintOrderBLLImpl printOrderBLLImpl = new PrintOrderBLLImpl();
  
            int draw1 =  int.Parse(draw);
            int start1 = int.Parse(start);
            int length1 = int.Parse(length);

            PageInfo<PrintOrder> pageInfo = printOrderBLLImpl.page(start1, length1, draw1);
            return Json(pageInfo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 日记录分页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult DayPage(string draw, string start, string length)
        {
            OrderDayBLLImpl orderDayBLLImpl = new OrderDayBLLImpl();
            int draw1 = int.Parse(draw);
            int start1 = int.Parse(start);
            int length1 = int.Parse(length);

            PageInfo<OrderDay> pageInfo = orderDayBLLImpl.page(start1, length1, draw1);
            return Json(pageInfo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 月记录分页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult MonthPage(string draw, string start, string length)
        {
            OrderMonthBLLImpl orderMonthBLLImpl = new OrderMonthBLLImpl();
            int draw1 = int.Parse(draw);
            int start1 = int.Parse(start);
            int length1 = int.Parse(length);

            PageInfo<OrderMonth> pageInfo = orderMonthBLLImpl.page(start1, length1, draw1);
            return Json(pageInfo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 年记录分页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult YearPage(string draw, string start, string length)
        {
            OrderYearBLLImpl orderYearBLLImpl = new OrderYearBLLImpl();
            int draw1 = int.Parse(draw);
            int start1 = int.Parse(start);
            int length1 = int.Parse(length);

            PageInfo<OrderYear> pageInfo = orderYearBLLImpl.page(start1, length1, draw1);
            return Json(pageInfo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(long id)
        {
            PrintOrderBLLImpl printOrderBLLImpl = new PrintOrderBLLImpl();
            PrintOrder printOrder = printOrderBLLImpl.getPrintOrder(id);
            return View(printOrder);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(long id)
        {
            PrintOrderBLLImpl printOrderBLLImpl = new PrintOrderBLLImpl();
            bool b = printOrderBLLImpl.deleteById(id);
            if (b)
            {
                return Json(Result.success("序号" + id + "的打印记录删除成功!"), JsonRequestBehavior.AllowGet);
            } else
            {
                return Json(Result.fail("序号" + id + "的打印记录删除失败!"), JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 确认订单完成
        /// </summary>
        /// <param name="printOrder"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Confirm(long id)
        {
            PrintOrderBLLImpl printOrderBLLImpl = new PrintOrderBLLImpl();
            ViewBag.Message = printOrderBLLImpl.updateStatusByid(id);
            return View("Index");
        }


        public ActionResult UpdateDay(long id)
        {
            OrderDayBLLImpl orderDayBLLImpl = new OrderDayBLLImpl();
            OrderDay orderDay = orderDayBLLImpl.getOrderById(id);
            DateTime date = (DateTime) orderDay.stats_day;
            var end = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
            ViewBag.Message = DateTime.Parse(date.ToString()).ToString("yyyy年MM月dd") + orderDayBLLImpl.dayStatistical(date, end);
            return View("Day");
        }

        public ActionResult UpdateMonth(long id)
        {
            OrderMonthBLLImpl orderMonthBLLImpl = new OrderMonthBLLImpl();
            OrderMonth orderMonth = orderMonthBLLImpl.getOrderMonthById(id);
            DateTime date = (DateTime)orderMonth.stats_month;
            DateTime CurDate = Convert.ToDateTime(date.ToString());
            var end = CurDate.AddDays(1 - CurDate.Day).AddMonths(1).AddDays(-1);
            ViewBag.Message = DateTime.Parse(date.ToString()).ToString("yyyy年MM") + orderMonthBLLImpl.monthStatistical(date, end);
            return View("Month");
        }

        public ActionResult UpdateYear(long id)
        {
            OrderYearBLLImpl orderYearBLLImpl = new OrderYearBLLImpl();
            OrderYear orderYear = orderYearBLLImpl.getOrderYearById(id);
            DateTime date = (DateTime)orderYear.stats_year;
            var end = new DateTime(date.Year, 12, 31, 23, 59,59);
            ViewBag.Message = DateTime.Parse(date.ToString()).ToString("yyyy") + orderYearBLLImpl.yearStatistical(date, end);
            return View("Year");
        }


    }
}