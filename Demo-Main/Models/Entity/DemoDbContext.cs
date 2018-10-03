namespace Demo_Main.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DemoDbContext : DbContext
    {
        public DemoDbContext()
            : base("name=DemoDbContext")
        {
        }

        public virtual DbSet<CapNganhNghe> CapNganhNghes { get; set; }
        public virtual DbSet<tbl_QuanHuyen> tbl_QuanHuyen { get; set; }
        public virtual DbSet<tbl_TinhThanhPho> tbl_TinhThanhPho { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CapNganhNghe>()
                .Property(e => e.MaNganh)
                .IsUnicode(false);
        }
    }
}
