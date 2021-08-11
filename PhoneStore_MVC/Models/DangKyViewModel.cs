using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneStore_MVC.Models
{
    public class DangKyViewModel
    {
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Bạn chưa nhập mật khẩu")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bạn chưa nhập xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Mật khẩu xác nhận không đúng")]
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }
    }
}