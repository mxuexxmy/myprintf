using myprint.web.Interceptor;
using System.Web;
using System.Web.Mvc;

namespace myprint.web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ActionFilter());
        }
    }
}
