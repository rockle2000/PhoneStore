using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore_MVC.Models;
using PhoneStore_MVC.Utils;

namespace PhoneStore_MVC.Controllers
{
    public class AdminController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin
        [CheckSession]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tNhanVien tk)
        {
            var matkhau = CryptPassword.MD5Hash(tk.MatKhau);
            var taikhoan = db.tNhanViens.Where(a => a.TenDangNhap == tk.TenDangNhap && a.MatKhau == matkhau && a.VaiTro == "Admin").SingleOrDefault();
            if (taikhoan != null)
            {
                Session["Admin"] = taikhoan.TenDangNhap;
                return RedirectToAction("TrangChu", "Admin");
            }
            else
            {
                TempData["Message"] = "Đăng nhập thất bại";
            }
            return View();
        }
        public ActionResult Logout()
        {
            //HttpContext.Session.Clear();
            //HttpContext.Session.Abandon();
            //HttpContext.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Session["Admin"] = null;
            return RedirectToAction("Login", "Admin");
        }

        [CheckSession]
        public ActionResult DoiMatKhauAdmin()
        {
            ViewBag.TenTK = Session["Admin"].ToString();
            return View();
        }

        [CheckSession]
        public ActionResult NhaSanXuat()
        {
            return View();
        }
        [CheckSession]
        public ActionResult DanhSachTaiKhoan()
        {
            return View();
        }
        [CheckSession]
        public ActionResult DanhSachSanPham()
        {
            return View();
        }
        [HttpGet]
        [CheckSession]
        public ActionResult ThemSanPham()
        {
            return View();
        }
        [CheckSession]
        public ActionResult TrangChu()
        {
            var order = db.tHoaDonBans.Where(x => x.TrangThai == "Pending").Count();
            ViewBag.HoaDonMoi = order;
            var user = db.tKhachHangs.Count();
            ViewBag.NguoiDung = user;
            var product = db.tDienThoais.Where(x => x.TrangThai == "Instock").Count();
            ViewBag.TongSP = product;
            return View();
        }

        public ActionResult DoanhThuTheoNam()
        {
            return View();
        }
        public ActionResult ThongKeTheoHang()
        {
            return View();
        }
    }
}