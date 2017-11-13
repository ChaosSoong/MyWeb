using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filter
{
    public class SystemAutherFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 权限判断
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            Controller controller = ((Controller)filterContext.Controller);
            string controll = filterContext.RouteData.Values["Controller"].ToString();
            //filterContext.Result = new ContentResult() { Content = "<script>alert('权限不足');history.go(-1);</script>" };
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();
        }
    }

    public class ApiFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext) {
            base.OnActionExecuting(actionContext);
        }
        public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext) {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
