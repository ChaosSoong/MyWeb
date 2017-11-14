using Filter;
using System.Web;
using System.Web.Mvc;

namespace MyWebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());//mvc用的拦截器
            filters.Add(new SystemAutherFilter());
        }
    }
}
