using Demo_Main.Models.BusinessModel;
using Demo_Main.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Main.Controllers
{
    public class CapNganhNgheController : Controller
    {
        CapNganhNgheModel model = new CapNganhNgheModel();
        // GET: CapNganhNghe
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetCapParent()
        {
            var data = model.LoadData();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InsertData(CapNganhNghe ob)
        {
            var data = model.InsertData(ob);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public  JsonResult GetForTreeGrid()
        {
            var data = model.GetForTreeGrid();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}