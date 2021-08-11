using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneStore_MVC.Models
{
    public class DangKyViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string TenKhach { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string DienThoai { get; set; }
    }
}