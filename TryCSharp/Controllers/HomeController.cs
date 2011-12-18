using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roslyn.Scripting.CSharp;

namespace TryCSharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var se = new ScriptEngine();
            var session = Roslyn.Scripting.Session.Create();
            se.Execute("using System; using System.IO;", session);
            var oldOut = Console.Out;
            var sw = new StringWriter();
            Console.SetOut(sw);
            se.Execute("Console.WriteLine(\"Rajeesh\");", session);
            ViewBag.Message = sw.ToString();
            Console.SetOut(oldOut);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }
    }
}
