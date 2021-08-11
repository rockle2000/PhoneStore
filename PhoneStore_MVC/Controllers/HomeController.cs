using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore_MVC.Models;
using PhoneStore_MVC.Utils;
using PagedList;
using PagedList.Mvc;

namespace PhoneStore_MVC.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult RenderNavBottom()
        {
            var list = db.tNhaSanXuats;
            return PartialView("NavBarBottom", list.ToList());
        }
        public ActionResult TrangChu()
        {
            var dt = from a in db.tDienThoais.Where(x => x.tNhaSanXuat.TenNSX == "Apple" && x.TrangThai != "Ngừng kinh doanh").Select(a => new { a.MaDT, a.TenDT, a.BaoHanh, a.BoNhoTrong, a.Chip, a.HeDieuHanh, a.KichThuoc, a.Pin, a.Ram, a.tNhaSanXuat.TenNSX })
                     orderby a.MaDT
                     select new tDienThoaiViewModel { MaDT = a.MaDT, TenDT = a.TenDT, BaoHanh = a.BaoHanh, BoNhoTrong = a.BoNhoTrong, Chip = a.Chip, HeDieuHanh = a.HeDieuHanh, KichThuoc = a.KichThuoc, Pin = a.Pin, Ram = a.Ram, MaNSX = a.TenNSX, Anh = db.tAnhs.Where(e => e.MaDT == a.MaDT).Select(e => e.Anh).ToList(), Gia = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.DonGiaBan).ToList(), Mau = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.Mau).ToList(), SoLuong = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.SoLuong).ToList() };

            var ss = from a in db.tDienThoais.Where(x => x.tNhaSanXuat.TenNSX == "Samsung" && x.TrangThai != "Ngừng kinh doanh").Select(a => new { a.MaDT, a.TenDT, a.BaoHanh, a.BoNhoTrong, a.Chip, a.HeDieuHanh, a.KichThuoc, a.Pin, a.Ram, a.tNhaSanXuat.TenNSX })
                     orderby a.MaDT
                     select new tDienThoaiViewModel { MaDT = a.MaDT, TenDT = a.TenDT, BaoHanh = a.BaoHanh, BoNhoTrong = a.BoNhoTrong, Chip = a.Chip, HeDieuHanh = a.HeDieuHanh, KichThuoc = a.KichThuoc, Pin = a.Pin, Ram = a.Ram, MaNSX = a.TenNSX, Anh = db.tAnhs.Where(e => e.MaDT == a.MaDT).Select(e => e.Anh).ToList(), Gia = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.DonGiaBan).ToList(), Mau = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.Mau).ToList(), SoLuong = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.SoLuong).ToList() };

            ViewBag.Samsung = ss;

            var xx = from a in db.tDienThoais.Where(x => x.tNhaSanXuat.TenNSX == "Xiaomi" && x.TrangThai != "Ngừng kinh doanh").Select(a => new { a.MaDT, a.TenDT, a.BaoHanh, a.BoNhoTrong, a.Chip, a.HeDieuHanh, a.KichThuoc, a.Pin, a.Ram, a.tNhaSanXuat.TenNSX })
                     orderby a.MaDT
                     select new tDienThoaiViewModel { MaDT = a.MaDT, TenDT = a.TenDT, BaoHanh = a.BaoHanh, BoNhoTrong = a.BoNhoTrong, Chip = a.Chip, HeDieuHanh = a.HeDieuHanh, KichThuoc = a.KichThuoc, Pin = a.Pin, Ram = a.Ram, MaNSX = a.TenNSX, Anh = db.tAnhs.Where(e => e.MaDT == a.MaDT).Select(e => e.Anh).ToList(), Gia = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.DonGiaBan).ToList(), Mau = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.Mau).ToList(), SoLuong = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.SoLuong).ToList() };

            ViewBag.Xiaomi = xx;
            return View(dt);
        }

        public ActionResult ChiTietSanPham(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var nsx = db.tDienThoais.Where(x => x.MaDT == id).Select(x => x.tNhaSanXuat.TenNSX).FirstOrDefault();
                var sp_cungnsx = from a in db.tDienThoais.Where(x => x.tNhaSanXuat.TenNSX == nsx && x.MaDT != id).Select(a => new { a.MaDT, a.TenDT, a.BaoHanh, a.BoNhoTrong, a.Chip, a.HeDieuHanh, a.KichThuoc, a.Pin, a.Ram, a.tNhaSanXuat.TenNSX })
                                 join b in db.tAnhs.GroupBy(x => x.MaDT).Select(x => x.FirstOrDefault()) on a.MaDT equals b.MaDT
                                 orderby a.MaDT
                                 select new tDienThoaiViewModel { MaDT = a.MaDT, TenDT = a.TenDT, BaoHanh = a.BaoHanh, BoNhoTrong = a.BoNhoTrong, Chip = a.Chip, HeDieuHanh = a.HeDieuHanh, KichThuoc = a.KichThuoc, Pin = a.Pin, Ram = a.Ram, MaNSX = a.TenNSX, Anh = db.tAnhs.Where(e => e.MaDT == a.MaDT).Select(e => e.Anh).ToList(), Gia = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.DonGiaBan).ToList(), Mau = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.Mau).ToList() };
                ViewBag.SPCungNSX = sp_cungnsx;
                ViewBag.SoLuong = sp_cungnsx.ToList().Count;
                ViewBag.MaDT = id;
                return View();
            }
            return HttpNotFound();

        }
        [HttpGet]
        public ActionResult GetProductByManufacture(string name, string sort, int? page)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return HttpNotFound();
            }
            var dt = from a in db.tDienThoais.Where(x => x.tNhaSanXuat.TenNSX == name && x.TrangThai != "Ngừng kinh doanh").Select(a => new { a.MaDT, a.TenDT, a.BaoHanh, a.BoNhoTrong, a.Chip, a.HeDieuHanh, a.KichThuoc, a.Pin, a.Ram, a.tNhaSanXuat.TenNSX })
                     join b in db.tAnhs.GroupBy(x => x.MaDT).Select(x => x.FirstOrDefault()) on a.MaDT equals b.MaDT
                     orderby a.MaDT
                     select new tDienThoaiViewModel { MaDT = a.MaDT, TenDT = a.TenDT, BaoHanh = a.BaoHanh, BoNhoTrong = a.BoNhoTrong, Chip = a.Chip, HeDieuHanh = a.HeDieuHanh, KichThuoc = a.KichThuoc, Pin = a.Pin, Ram = a.Ram, MaNSX = a.TenNSX, Anh = db.tAnhs.Where(e => e.MaDT == a.MaDT).Select(e => e.Anh).ToList(), Gia = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.DonGiaBan).ToList(), Mau = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.Mau).ToList(), SoLuong = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.SoLuong).ToList() };
            if (dt == null) return HttpNotFound();
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "name_desc":
                        dt = dt.OrderByDescending(a => a.TenDT);
                        break;
                    case "name_asc":
                        dt = dt.OrderBy(a => a.TenDT);
                        break;
                    case "price_desc":

                        dt = dt.OrderByDescending(a => a.Gia.FirstOrDefault());
                        break;
                    case "price_asc":
                        dt = dt.OrderBy(a => a.Gia.FirstOrDefault());
                        break;
                    default:
                        break;
                }

            }
            return View(dt.ToPagedList(page ?? 1, 8));
        }

        [HttpGet]
        public ActionResult TimKiem(string tensp, string nsx)
        {
            ViewBag.TenSP = tensp;
            ViewBag.NSX = nsx;
            return View();
        }

        [HttpGet]
        public ActionResult GioHang()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ThanhToan()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string pass, string remember)
        {
            //if (ModelState.IsValid)
            //{
            //    string password = CryptPassword.MD5Hash(kh.MatKhau);
            //    var khachang = db.tKhachHangs.Where(a => a.TenDangNhap == kh.TenDangNhap && a.MatKhau == password).SingleOrDefault();
            //    if (khachang != null)
            //    {
            //        Session["UserName"] = khachang.TenDangNhap;
            //        return Json(new { code = "success" });
            //    }
            //    else
            //    {
            //        return Json(new { code = "Username or Password incorrect" });
            //    }
            //}
            //else
            //{
            //    return Json(new { code = "Login fail" });
            //}
            string password = CryptPassword.MD5Hash(pass);
            var khachang = db.tKhachHangs.Where(a => a.TenDangNhap == username && a.MatKhau == password).SingleOrDefault();
            if (khachang != null)
            {
                if (remember == "false")
                    Session["UserName"] = khachang.TenDangNhap;
                else if (remember == "true")
                {
                    Session["UserName"] = khachang.TenDangNhap;
                    HttpCookie cookie = new HttpCookie("RememberCookies", khachang.TenDangNhap);
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                //CreateRememberCookie(khachang.TenDangNhap);
                return Json(new { code = "success" });
            }
            else
            {
                return Json(new { code = "Username or Password incorrect" });
            }
        }

        private HttpCookie CreateRememberCookie(string name)
        {
            HttpCookie RememberCookies = new HttpCookie("RememberCookies");
            RememberCookies.Value = name;
            RememberCookies.Expires = DateTime.Now.AddHours(1);
            return RememberCookies;
        }
        public ActionResult Logout()
        {
            //HttpContext.Session.Clear();
            //HttpContext.Session.Abandon();
            //HttpContext.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Session["UserName"] = null;
            if (Request.Cookies["RememberCookies"] != null)
            {
                var c = new HttpCookie("RememberCookies");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("TrangChu", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult Register(string username, string password, string name, string phonenumber)
        public ActionResult Register(DangKyViewModel model)
        {
            if (ModelState.IsValid)
            {

                tKhachHang khach = new tKhachHang()
                {
                    TenDangNhap = model.UserName,
                    MatKhau = CryptPassword.MD5Hash(model.Password),
                    TenKhach = model.FullName,
                    DienThoai = model.PhoneNumber
                };
                db.tKhachHangs.Add(khach);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }


    }
}
