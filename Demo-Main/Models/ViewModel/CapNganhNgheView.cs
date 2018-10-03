using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Main.Models.ViewModel
{
    public class CapNganhNgheView
    {
        public int Id { get; set; }
        public int? ParentID { get; set; }
        public string MaNganh { get; set; }
        public string TenNganh {get;set;}
        public string alevel { get; set; }
    }
}