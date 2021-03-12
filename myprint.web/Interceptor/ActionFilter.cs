using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myprint.web.Interceptor
{
    /// <summary>
    /// 拦截器
    /// </summary>
    public class ActionFilter : ActionFilterAttribute
    {
        #region 是否登录
        public bool IsLogin { get; set; }
        #endregion

        #region 执行action前执行这个方法
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var varget = filterContext.HttpContext.Session["userName"];
            if (IsLogin == false)
            {
                if (varget == null)
                {
                    filterContext.Result = new RedirectResult("/Login/Index");
                }
                return;

            }
            
        }

        #endregion
    }
}