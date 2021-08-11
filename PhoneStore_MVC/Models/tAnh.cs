namespace PhoneStore_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tAnh")]
    public partial class tAnh
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaDT { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Anh { get; set; }

        public virtual tDienThoai tDienThoai { get; set; }
    }
}
