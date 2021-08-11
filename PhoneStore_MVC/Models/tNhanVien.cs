namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tNhanVien")]
    public partial class tNhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNhanVien()
        {
            tHoaDonNhaps = new HashSet<tHoaDonNhap>();
        }

        [Key]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNV { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(15)]
        public string DienThoai { get; set; }

        [StringLength(10)]
        public string VaiTro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tHoaDonNhap> tHoaDonNhaps { get; set; }
    }
}
