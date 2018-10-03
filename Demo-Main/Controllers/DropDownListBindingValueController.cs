using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Main.Models.BusinessModel;

namespace Demo_Main.Controllers
{
    public class DropDownListBindingValueController : Controller
    {
        DropDownListBindingValueModel model = new DropDownListBindingValueModel();
        // GET: DropDownListBindingValue
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult loadTinhThanh()
        {
            var data = model.loadTinhThanh();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}