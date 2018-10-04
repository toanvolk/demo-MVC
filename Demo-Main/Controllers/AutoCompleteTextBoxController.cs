using Demo_Main.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Main.Controllers
{
    public class AutoCompleteTextBoxController : Controller
    {
        AutoCompleteTextBoxModel model = new AutoCompleteTextBoxModel();
        // GET: AutoCompleteTextBox
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAutoText(string maNganh)
        {
            var data = model.GetAutoText(maNganh);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}