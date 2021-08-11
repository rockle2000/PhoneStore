using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneStore_MVC.Models
{
    public class tDienThoaiViewModel
    {
        //public string MaDT { get; set; }
        //public string TenDT { get; set; }
        //public string MaNSX { get; set; }
        //public string BaoHanh { get; set; }
        //public string Chip { get; set; }
        //public string Ram { get; set; }
        //public string BoNhoTrong { get; set; }
        //public string Pin { get; set; }
        //public string HeDieuHanh { get; set; }
        //public string KichThuoc { get; set; }
        [Key]
        public string MaDT { get; set; }
        public string TenDT { get; set; }
        public string MaNSX { get; set; }
        public string BaoHanh { get; set; }
        public string Chip { get; set; }
        public string Ram { get; set; }
        public string BoNhoTrong { get; set; }
        public string Pin { get; set; }
        public string HeDieuHanh { get; set; }
        public string KichThuoc { get; set; }
        public string TrangThai { get; set; }
        public List<string> Anh { get; set; }
        public List<decimal> Gia { get; set; }

        public List<string> Mau { get; set; }
        public List<int> SoLuong { get; set; }

        public int? DanhGia { get; set; }


    }
}