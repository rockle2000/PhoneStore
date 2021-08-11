using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneStore_MVC.Models;
using PhoneStore_MVC.Utils;

namespace PhoneStore_MVC.Controllers
{
    public class TaiKhoanAPIController : ApiController
    {
        Model1 db = new Model1();
        [Route("api/GetAccountList")]
        public IHttpActionResult GetAccountList()
        {
            return Ok(db.tKhachHangs.Select(a => new { a.TenDangNhap, a.TenKhach, a.DienThoai }));
        }

        public IHttpActionResult GetAccount(string id)
        {
            return Ok(db.tKhachHangs.Where(a => a.TenDangNhap == id).Select(a => new { a.TenDangNhap, a.TenKhach, a.DienThoai }));
        }

        [HttpPost]
        public IHttpActionResult CreateAccount([FromBody] tKhachHang tk)
        {
            if (tk == null || string.IsNullOrWhiteSpace(tk.TenDangNhap) || string.IsNullOrWhiteSpace(tk.DienThoai)) return NotFound();
            db.tKhachHangs.Add(tk);
            db.SaveChanges();
            return Ok("Tạo tài khoản mới thành công");
        }

        [HttpPut,Route("api/ResetPassword")]
        public IHttpActionResult ResetPassword(string tentk)
        {
            if (string.IsNullOrWhiteSpace(tentk)) return NotFound();
            tKhachHang kh = db.tKhachHangs.Find(tentk);
            db.tKhachHangs.Attach(kh);
            kh.MatKhau = CryptPassword.MD5Hash("123456");
            db.SaveChanges();
            return Ok("Cài lại mật khẩu cho tài khoản thành công");
        }

        //Change password admin
        [HttpPut, Route("api/ChangePasswordAdmin")]
        public IHttpActionResult ChangePasswordAdmin(string tentk, string oldPass, string newPass)
        {
            if (string.IsNullOrWhiteSpace(tentk) || string.IsNullOrWhiteSpace(oldPass) || string.IsNullOrWhiteSpace(newPass))
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Missing information"));
            tNhanVien nv = db.tNhanViens.Find(tentk);
            if (nv == null) return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Username incorrect"));
            if (CryptPassword.MD5Hash(oldPass) != nv.MatKhau)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Old password incorrect"));
            db.tNhanViens.Attach(nv);
            nv.MatKhau = CryptPassword.MD5Hash(newPass);
            db.SaveChanges();
            return Ok("Change password successfully");
        }

        //Change password user
        [HttpPut,Route("api/ChangePassword")]
        public IHttpActionResult ChangePassword(string tentk,string oldPass,string newPass)
        {
            if (string.IsNullOrWhiteSpace(tentk) || string.IsNullOrWhiteSpace(oldPass) || string.IsNullOrWhiteSpace(newPass)) 
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Missing information"));
            tKhachHang kh = db.tKhachHangs.Find(tentk);
            if (kh == null) return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Username incorrect"));
            if (CryptPassword.MD5Hash(oldPass) != kh.MatKhau)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Old password incorrect"));
            db.tKhachHangs.Attach(kh);
            kh.MatKhau = CryptPassword.MD5Hash(newPass);
            db.SaveChanges();
            return Ok("Change password successfully");
        }

        [HttpPut,Route("api/EditAccount")]
        public IHttpActionResult EditAccount(string tentk, string hoten, string dienthoai)
        {
            if (string.IsNullOrWhiteSpace(tentk)) return NotFound();

            tKhachHang taikhoan = db.tKhachHangs.Find(tentk);
            db.tKhachHangs.Attach(taikhoan);
            if (!string.IsNullOrWhiteSpace(hoten)) taikhoan.TenKhach = hoten;
            if (!string.IsNullOrWhiteSpace(dienthoai)) taikhoan.DienThoai = dienthoai;
            db.SaveChanges();
            return Ok("Sửa thông tin tài khoản thành công");
        }
        [HttpDelete]
        public IHttpActionResult DeleteAccount(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var tk = db.tKhachHangs.Find(id);
            if (tk == null) return NotFound();
            db.tKhachHangs.Remove(tk);
            db.SaveChanges();
            return Ok("Xóa tài khoản thành công");
        }
    }

}
