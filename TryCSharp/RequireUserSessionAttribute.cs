using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TryCSharp
{
    public class RequireUserSessionAttribute : ActionFilterAttribute
    {
        private static long SessionCount = 99;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction && !filterContext.HttpContext.Response.IsRequestBeingRedirected)
            {
                if (!filterContext.RouteData.Values.ContainsKey("sid"))
                {
                    Interlocked.Increment(ref SessionCount);
                    var sessionId = BijectiveRandomGenerator.Encode(SessionCount);
                    var redirectUrl = UrlHelper.GenerateUrl("Default", "Index", "Home", 
                        new RouteValueDictionary(new { sid = sessionId}), 
                        RouteTable.Routes, filterContext.RequestContext, false);
                    filterContext.Result = new RedirectResult(redirectUrl);
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}