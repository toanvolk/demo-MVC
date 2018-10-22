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
        [HttpGet]
        public JsonResult loadKeyNoiCap(string skey)
        {
            string strReplace = "<b>" + skey + "</b>";
            string outString = "<ul class='list-unstyled'>";

            List<string> lstString = model.LoadKeyNoiCap(skey);
            if (lstString.Count > 0)
            {
                foreach (string str in lstString)
                {
                    string strFormat = str.Replace(skey, strReplace);
                    outString += "<li style='cursor: pointer; '>" + strFormat + "</li>";
                }
            }
            else
            {
                outString += "<li>Không tìm thấy</li>";
            }
            outString += "</ul>";

            return Json(outString, JsonRequestBehavior.AllowGet);
        }
    }
}