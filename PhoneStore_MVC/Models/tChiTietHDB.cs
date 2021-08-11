namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tChiTietHDB")]
    public partial class tChiTietHDB
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoHDB { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaDT { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string Mau { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal? DonGiaBan { get; set; }

        public virtual tDienThoai tDienThoai { get; set; }

        public virtual tHoaDonBan tHoaDonBan { get; set; }
    }
}
