using Demo_Main.Models.Entity;
using Demo_Main.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Main.Models.BusinessModel
{
    public class CapNganhNgheModel
    {
        DemoDbContext db = new DemoDbContext();
        public List<CapNganhNghe> LoadData()
        {
            return db.CapNganhNghes.ToList();
        }
        public int InsertData(CapNganhNghe ob)
        {
            db.CapNganhNghes.Add(ob);
            return db.SaveChanges();
        }
        public List<CapNganhNgheView> GetForTreeGrid()
        {            
            return db.Database.SqlQuery<CapNganhNgheView>("sp_LoadDataCapNganh").ToList();
        }
    }
}