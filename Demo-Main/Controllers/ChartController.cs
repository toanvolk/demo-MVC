using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Main.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        //Sparkline Pie
        public ActionResult Index()
        {
            return View();
        }
        //Bar Chart
        public ActionResult BarChartView()
        {
            return View();
        }
    }
}