namespace Demo_Main.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CapNganhNghe")]
    public partial class CapNganhNghe
    {
        [Key]
        public int NganhNgheID { get; set; }

        [StringLength(10)]
        public string MaNganh { get; set; }

        public int? ParentID { get; set; }

        [StringLength(500)]
        public string TenNganh { get; set; }

        [StringLength(2000)]
        public string GhiChu { get; set; }

        public bool? StatID { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(500)]
        public string NguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        [StringLength(500)]
        public string NguoiCapNhat { get; set; }
    }
}
