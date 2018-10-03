using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo_Main.Models.ViewModel;
using Demo_Main.Models.Entity;
namespace Demo_Main.Models.BusinessModel
{
    public class AutoCompleteTextBoxModel
    {
        DemoDbContext db = new DemoDbContext();
        public List<AutoCompleteTextBox> GetAutoText(string maNganh)
        {
            List<CapNganhNghe> lstob = db.CapNganhNghes.ToList();
            var data = (from m in lstob
                       select new AutoCompleteTextBox() {Id = m.NganhNgheID, TenNganh = m.TenNganh }).ToList();
            return data;
        }
    }
}