using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myprint.Entity;
using myprint.BLL.impl;

namespace print.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 录入输入
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Calculate(PrintOrder printOrder)
        {
            PrintOrderBLLImpl printOrderBLLImpl = new PrintOrderBLLImpl();
      
            ViewBag.Message = printOrderBLLImpl.addPrintOrder(printOrder);
            return View("Index");
        }

       
        public ActionResult Input()
        {
            return View();
        }

        /// <summary>
        /// 详细录入
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DetailInput(PrintOrder printOrder)
        {
            PrintOrderBLLImpl printOrderBLLImpl = new PrintOrderBLLImpl();

            ViewBag.Message = printOrderBLLImpl.addPrintOrder(printOrder);
            return View("Input");
        }

    }
}