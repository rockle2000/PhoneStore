namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tNhaSanXuat")]
    public partial class tNhaSanXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tNhaSanXuat()
        {
            tDienThoais = new HashSet<tDienThoai>();
            tHoaDonNhaps = new HashSet<tHoaDonNhap>();
        }

        [Key]
        [StringLength(10)]
        public string MaNSX { get; set; }

        [StringLength(100)]
        public string TenNSX { get; set; }

        [Required]
        [StringLength(50)]
        public string Diachi { get; set; }

        [Required]
        [StringLength(10)]
        public string SDT { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tDienThoai> tDienThoais { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tHoaDonNhap> tHoaDonNhaps { get; set; }
    }
}
