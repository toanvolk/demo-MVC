using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Main.Controllers
{
    public class AutoCompleteTextBoxController : Controller
    {
        // GET: AutoCompleteTextBox
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAutoText(string maNganh)
        {
            return null;
        }
    }
}