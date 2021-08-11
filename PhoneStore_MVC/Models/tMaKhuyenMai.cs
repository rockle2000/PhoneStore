namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tMaKhuyenMai")]
    public partial class tMaKhuyenMai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tMaKhuyenMai()
        {
            tHoaDonBans = new HashSet<tHoaDonBan>();
        }

        [Key]
        [StringLength(10)]
        public string MaKhuyenMai { get; set; }

        public int? KhuyenMai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tHoaDonBan> tHoaDonBans { get; set; }
    }
}
