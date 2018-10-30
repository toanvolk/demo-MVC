using Demo_Main.Common;
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
        public ActionResult ViewMain()
        {
            return View();
        }
        public ActionResult ViewMainAjax()
        {
            return View();
        }
        public ActionResult View1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase[] file)
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
                return Json(new { status = "success1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!!";
                return Json(new { status = "error1" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult UploadFile1(HttpPostedFileBase file)
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

        [HttpPost]
        public ActionResult Upload1(HttpPostedFileBase uploadFile)
        {
            //Create upload directory first
            if (!Directory.Exists(Server.MapPath("/uploads")))
            {
                Directory.CreateDirectory(Server.MapPath("/uploads"));
            }


            if (uploadFile != null)
            {
                string fileName = GenerateFileName.Generate(uploadFile);//Get file name
                string pathUploadFileServer = "/uploads/" + fileName;

                //if another file with the same name is existed, add number behind
                if (System.IO.File.Exists(Server.MapPath(pathUploadFileServer)))
                {
                    pathUploadFileServer = GenerateFileName.NextAvailableFilename(Server, pathUploadFileServer);
                }

                uploadFile.SaveAs(Server.MapPath(pathUploadFileServer));
                return Json(new { Result = true, Message = "Upload hoàn tất" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Result = false, Message = "Không có file" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase[] uploadFiles)
        {
            //Create upload directory first
            if (!Directory.Exists(Server.MapPath("/Upload")))
            {
                Directory.CreateDirectory(Server.MapPath("/Upload"));
            }
            if (uploadFiles.Length > 0)
                foreach (var uploadFile in uploadFiles)
                {
                    if (uploadFile != null)
                    {
                        string fileName = GenerateFileName.Generate(uploadFile);
                        string pathUploadFileServer = "/uploads/" + fileName;

                        //if another file with the same name is existed, add number behind
                        if (System.IO.File.Exists(Server.MapPath(pathUploadFileServer)))
                        {
                            pathUploadFileServer = GenerateFileName.NextAvailableFilename(Server, pathUploadFileServer);
                        }

                        uploadFile.SaveAs(Server.MapPath(pathUploadFileServer));
                    }

                }
            else
                return Json(new { Result = false, Message = "Không có file" }, JsonRequestBehavior.AllowGet);

            return Json(new { Result = true, Message = "Upload hoàn tất" }, JsonRequestBehavior.AllowGet);

        }
    }
}