namespace Demo_Main.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_TinhThanhPho
    {
        [Key]
        public int TinhThanhPhoID { get; set; }

        [StringLength(500)]
        public string TinhThanhPhoName { get; set; }

        public bool? StatID { get; set; }

        [StringLength(500)]
        public string NguoiTao { get; set; }

        [StringLength(500)]
        public string NguoiCapNhat { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }
    }
}
