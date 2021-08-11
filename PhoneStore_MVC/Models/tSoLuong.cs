namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tSoLuong")]
    public partial class tSoLuong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaDT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Mau { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGiaBan { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGiaNhap { get; set; }

        public int? KhuyenMai { get; set; }

        public virtual tDienThoai tDienThoai { get; set; }
    }
}
