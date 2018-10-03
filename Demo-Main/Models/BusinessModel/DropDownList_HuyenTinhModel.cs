using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo_Main.Models.Entity;

namespace Demo_Main.Models.BusinessModel
{
    public class DropDownList_HuyenTinhModel
    {
        DemoDbContext db = new DemoDbContext();
        public List<tbl_TinhThanhPho> loadTinhThanh()
        {
            return db.tbl_TinhThanhPho.OrderBy(o=>o.TinhThanhPhoName).ToList();
        }
        public List<tbl_QuanHuyen> loadQuanHuyen(int idTinhThanh)
        {
            return db.tbl_QuanHuyen.Where(o => o.TinhThanhPhoID == idTinhThanh).OrderBy(o => o.QuanHuyenID).ToList();
        }
    }
}