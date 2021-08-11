namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tHoaDonBan")]
    public partial class tHoaDonBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tHoaDonBan()
        {
            tChiTietHDBs = new HashSet<tChiTietHDB>();
        }

        [Key]
        public int SoHDB { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailKH { get; set; }

        public DateTime? NgayBan { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(11)]
        public string SoDienThoai { get; set; }

        [StringLength(10)]
        public string MaKhuyenMai { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tChiTietHDB> tChiTietHDBs { get; set; }

        public virtual tKhachHang tKhachHang { get; set; }

        public virtual tMaKhuyenMai tMaKhuyenMai { get; set; }
    }
}
