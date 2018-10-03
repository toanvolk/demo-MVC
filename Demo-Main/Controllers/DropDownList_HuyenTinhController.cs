using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Main.Models.BusinessModel;

namespace Demo_Main.Controllers
{
    public class DropDownList_HuyenTinhController : Controller
    {
        // GET: DropDownList_HuyenTinh
        DropDownList_HuyenTinhModel model = new DropDownList_HuyenTinhModel();
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
        [HttpGet]
        public JsonResult loadQuanHuyen(int idTinhThanh)
        {
            var data = model.loadQuanHuyen(idTinhThanh);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}