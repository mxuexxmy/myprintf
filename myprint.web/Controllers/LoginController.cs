using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myprint.BLL.impl;
using myprint.Entity;
using myprint.web.Interceptor;

namespace print.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private UserBllImpl userBllImpl = new UserBllImpl();

        [ActionFilter(IsLogin = true)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionFilter(IsLogin = true)]
        public ActionResult Login(string phone, string password)
        {
            User user = userBllImpl.getUser(phone, password);
            if(user == null)
            {
                ViewBag.Message = "你的手机号或密码错误";
                return View("Index");
            }
            /// 存储 session
            Session["userId"] = user.id;
            Session["userName"] = user.user_name;
            Session["createTime"] = DateTime.Parse(user.create_time.ToString()).ToString("yyyy-MM-dd HH:mm:ss");

           /// Session["createTime"] = user.create_time;
            /// 重定向到首页
            return RedirectToAction("Index", "Index");
             
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [ActionFilter(IsLogin = true)]
        public ActionResult Logout()
        {
            /// 清除 session
            Session.Clear();
            return View("Index");
        }

    }
}