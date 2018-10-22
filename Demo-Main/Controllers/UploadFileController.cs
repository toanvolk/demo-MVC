using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Main.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile1(HttpPostedFileBase[] file)
        {
            try
            {
                foreach (var item in file)
                {

                    if (item.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(item.FileName);
                        string _path = Path.Combine(Server.MapPath("~/uploads"), _FileName);
                        item.SaveAs(_path);
                    }
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return Json(new { status= "success1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!!";
                return Json(new { status = "error1" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/uploads"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
                return Json(new { status = "error" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return Json(new { status = "error" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}