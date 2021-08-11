namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tDienThoai")]
    public partial class tDienThoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tDienThoai()
        {
            tAnhs = new HashSet<tAnh>();
            tChiTietHDBs = new HashSet<tChiTietHDB>();
            tChiTietHDNs = new HashSet<tChiTietHDN>();
            tDanhGias = new HashSet<tDanhGia>();
            tSoLuongs = new HashSet<tSoLuong>();
        }

        [Key]
        [StringLength(10)]
        public string MaDT { get; set; }

        [StringLength(30)]
        public string TenDT { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNSX { get; set; }

        [StringLength(50)]
        public string BaoHanh { get; set; }

        [StringLength(50)]
        public string Chip { get; set; }

        [StringLength(20)]
        public string Ram { get; set; }

        [StringLength(20)]
        public string BoNhoTrong { get; set; }

        [StringLength(50)]
        public string Pin { get; set; }

        [StringLength(50)]
        public string HeDieuHanh { get; set; }

        [StringLength(50)]
        public string KichThuoc { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAnh> tAnhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tChiTietHDB> tChiTietHDBs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tChiTietHDN> tChiTietHDNs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tDanhGia> tDanhGias { get; set; }

        public virtual tNhaSanXuat tNhaSanXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tSoLuong> tSoLuongs { get; set; }
    }
}
