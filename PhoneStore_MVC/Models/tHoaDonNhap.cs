namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tHoaDonNhap")]
    public partial class tHoaDonNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tHoaDonNhap()
        {
            tChiTietHDNs = new HashSet<tChiTietHDN>();
        }

        [Key]
        public int SoHDN { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNSX { get; set; }

        public DateTime? NgayNhap { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tChiTietHDN> tChiTietHDNs { get; set; }

        public virtual tNhanVien tNhanVien { get; set; }

        public virtual tNhaSanXuat tNhaSanXuat { get; set; }
    }
}
