namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tKhachHang")]
    public partial class tKhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tKhachHang()
        {
            tDanhGias = new HashSet<tDanhGia>();
            tHoaDonBans = new HashSet<tHoaDonBan>();
        }

        [Key]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        public string MatKhau { get; set; }

        [StringLength(50)]
        public string TenKhach { get; set; }

        [StringLength(11)]
        public string DienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tDanhGia> tDanhGias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tHoaDonBan> tHoaDonBans { get; set; }
    }
}
