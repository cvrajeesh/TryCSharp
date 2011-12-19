using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roslyn.Scripting.CSharp;

namespace TryCSharp.Controllers
{
    [Authorize]
    [RequireUserSession]
    public class HomeController : Controller
    {
        public ActionResult Index(string sid)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string sid, string statement)
        {
            var se = new ScriptExecutionService();
            var result = se.Execute(sid, statement);
            if (string.IsNullOrEmpty(result))
            {
                return Content("Executed...");
            }

            return Content(result);
        }
       

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }
    }

}
