using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myprint.Entity;
using myprint.BLL.impl;
using System.Data;
using System.Web.SessionState;

namespace print.Controllers
{
    public class ProfileController : Controller
    {
        private UserBllImpl userBllImpl = new UserBllImpl();

        // GET: Profile
        public ActionResult Index()
        {
            long id = (long) Session["userId"];
            User user = userBllImpl.getUserOne(id);
            return View(user);
        }

        /// <summary>
        /// 更新个人信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult updateProfile(User user)
        {
            userBllImpl.updateProfile(user);
            return Redirect("/Profile");
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="old_password"></param>
        /// <param name="new_password"></param>
        /// <returns></returns>
        public ActionResult updatePassword(long id,string old_password, string new_password)
        {
            User user = userBllImpl.getUserOne(id);
            if (user.password != old_password)
            {
                ViewBag.Message = "你的原始密码错误！";
                return Redirect("/profile");
            }
            userBllImpl.updatePassword(id, new_password);
            return Redirect("/login");
        }

    }
}