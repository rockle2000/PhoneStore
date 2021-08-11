namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tDanhGia")]
    public partial class tDanhGia
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaDT { get; set; }

        public int? DanhGia { get; set; }

        [StringLength(200)]
        public string NoiDung { get; set; }

        public virtual tDienThoai tDienThoai { get; set; }

        public virtual tKhachHang tKhachHang { get; set; }
    }
}
