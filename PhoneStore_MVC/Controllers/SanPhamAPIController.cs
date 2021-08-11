using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using PhoneStore_MVC.Models;

namespace PhoneStore_MVC.Controllers
{
    public class SanPhamAPIController : ApiController
    {
        Model1 db = new Model1();



        [HttpGet, Route("api/LayDanhSachSanPham")]
        public IHttpActionResult LayDanhSachSanPham()
        {

            var dt = from a in db.tDienThoais.Select(a => new { a.MaDT, a.TenDT, a.BaoHanh, a.BoNhoTrong, a.Chip, a.HeDieuHanh, a.KichThuoc, a.Pin, a.Ram, a.tNhaSanXuat.TenNSX,a.TrangThai})
                     join b in db.tAnhs.GroupBy(x => x.MaDT).Select(x => x.FirstOrDefault()) on a.MaDT equals b.MaDT
                     orderby a.MaDT
                     select new tDienThoaiViewModel { MaDT = a.MaDT, TenDT = a.TenDT, BaoHanh = a.BaoHanh, BoNhoTrong = a.BoNhoTrong, Chip = a.Chip, HeDieuHanh = a.HeDieuHanh, KichThuoc = a.KichThuoc, Pin = a.Pin, Ram = a.Ram,TrangThai = a.TrangThai, MaNSX = a.TenNSX, Anh = db.tAnhs.Where(e => e.MaDT == a.MaDT).Select(e => e.Anh).ToList(), Gia = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.DonGiaBan).ToList(), Mau = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.Mau).ToList() };
            return Ok(dt);
        }

        [HttpGet]
        public IHttpActionResult ChiTietSanPham(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var dt = from a in db.tDienThoais.Where(x => x.MaDT == id).Select(a => new { a.MaDT, a.TenDT, a.BaoHanh, a.BoNhoTrong, a.Chip, a.HeDieuHanh, a.KichThuoc, a.Pin, a.Ram, a.tNhaSanXuat.TenNSX })
                         join b in db.tAnhs.GroupBy(x => x.MaDT).Select(x => x.FirstOrDefault()) on a.MaDT equals b.MaDT
                         orderby a.MaDT
                         select new tDienThoaiViewModel { MaDT = a.MaDT, TenDT = a.TenDT, BaoHanh = a.BaoHanh, BoNhoTrong = a.BoNhoTrong, Chip = a.Chip, HeDieuHanh = a.HeDieuHanh, KichThuoc = a.KichThuoc, Pin = a.Pin, Ram = a.Ram, MaNSX = a.TenNSX, Anh = db.tAnhs.Where(e => e.MaDT == a.MaDT).Select(e => e.Anh).ToList(), Gia = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.DonGiaBan).ToList(), Mau = db.tSoLuongs.Where(e => e.MaDT == id).Select(e => e.Mau).ToList(), SoLuong = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.SoLuong).ToList() };
                return Ok(dt.First());
            }
            return NotFound();
        }

        [HttpGet, Route("api/SPTheoNSX")]
        public IHttpActionResult LaySanPhamTheoNSX(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var dt = from a in db.tDienThoais.Where(x => x.tNhaSanXuat.TenNSX == name).Select(a => new { a.MaDT, a.TenDT, a.BaoHanh, a.BoNhoTrong, a.Chip, a.HeDieuHanh, a.KichThuoc, a.Pin, a.Ram, a.tNhaSanXuat.TenNSX })
                         join b in db.tAnhs.GroupBy(x => x.MaDT).Select(x => x.FirstOrDefault()) on a.MaDT equals b.MaDT
                         orderby a.MaDT
                         select new tDienThoaiViewModel { MaDT = a.MaDT, TenDT = a.TenDT, BaoHanh = a.BaoHanh, BoNhoTrong = a.BoNhoTrong, Chip = a.Chip, HeDieuHanh = a.HeDieuHanh, KichThuoc = a.KichThuoc, Pin = a.Pin, Ram = a.Ram, MaNSX = a.TenNSX, Anh = db.tAnhs.Where(e => e.MaDT == a.MaDT).Select(e => e.Anh).ToList(), Gia = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.DonGiaBan).ToList(), Mau = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.Mau).ToList() };
                return Ok(dt);
            }
            return NotFound();
        }
        [HttpGet, Route("api/CheckMaSP")]
        public IHttpActionResult CheckMaSP(string masp)
        {
            if (!string.IsNullOrWhiteSpace(masp))
            {
                var dt = db.tDienThoais.Where(x => x.MaDT == masp).Select(a => a.MaDT);
                return Ok(dt);
            }
            return NotFound();
        }


        //[HttpPut, Route("api/DanhGia")]
        //public IHttpActionResult DanhGia(string masp, int a)
        //{
        //    var dt = db.tDienThoais.Find(masp);
        //    db.tDienThoais.Attach(dt);
        //    dt.DanhGia = a;
        //    db.SaveChanges();
        //    return Ok("Đánh giá thành công");
        //}
        public IHttpActionResult GetProductPrice(string id, string color)
        {
            if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(color))
            {
                var dt = db.tSoLuongs.Where(a => a.MaDT == id && a.Mau == color).Select(a => new {a.DonGiaBan,a.SoLuong });
                return Ok(dt);
            }
            return NotFound();
        }

        [HttpGet,Route("api/SearchProduct")]
        public IHttpActionResult SearchProduct(string name,string nsx)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var dt = from a in db.tDienThoais.Where(x => x.TenDT.Contains(name)).Select(a => new { a.MaDT, a.TenDT,a.tNhaSanXuat.TenNSX })
                         join b in db.tAnhs.GroupBy(x => x.MaDT).Select(x => x.FirstOrDefault()) on a.MaDT equals b.MaDT
                         orderby a.MaDT
                         select new tDienThoaiViewModel { MaDT = a.MaDT, TenDT = a.TenDT, MaNSX = a.TenNSX, Anh = db.tAnhs.Where(e => e.MaDT == a.MaDT).Select(e => e.Anh).ToList(), Gia = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.DonGiaBan).ToList(), Mau = db.tSoLuongs.Where(e => e.MaDT == a.MaDT).Select(e => e.Mau).ToList() };
                if (!string.IsNullOrWhiteSpace(nsx) && nsx != "all")
                {
                    dt = dt.Where(x => x.MaNSX == nsx);
                }
                return Ok(dt);
            }
            else return NotFound();
        }

        [HttpPost]
        public IHttpActionResult InsertNewProduct()
        {
            if (HttpContext.Current.Request.Files.Count == 0) return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "You must add pictures"));
            
            tDienThoai dt = new tDienThoai
            {
                MaDT = HttpContext.Current.Request.Params["MaDT"],
                TenDT = HttpContext.Current.Request.Params["TenDT"],
                MaNSX = HttpContext.Current.Request.Params["MaNSX"],
                BaoHanh = HttpContext.Current.Request.Params["BaoHanh"],
                Chip = HttpContext.Current.Request.Params["Chip"],
                Ram = HttpContext.Current.Request.Params["Ram"],
                BoNhoTrong = HttpContext.Current.Request.Params["BoNhoTrong"],
                Pin = HttpContext.Current.Request.Params["Pin"],
                HeDieuHanh = HttpContext.Current.Request.Params["HDH"],
                KichThuoc = HttpContext.Current.Request.Params["KichThuoc"],
                TrangThai = "Instock"
            };
            db.tDienThoais.Add(dt);
            db.SaveChanges();

            tSoLuong sl = new tSoLuong
            {
                MaDT = HttpContext.Current.Request.Params["MaDT"],
                Mau = HttpContext.Current.Request.Params["Mau"],
                SoLuong = int.Parse(HttpContext.Current.Request.Params["SoLuong"]),
                DonGiaBan = decimal.Parse(HttpContext.Current.Request.Params["GiaBan"]),
                DonGiaNhap = decimal.Parse(HttpContext.Current.Request.Params["GiaNhap"]),
            };
            db.tSoLuongs.Add(sl);
            db.SaveChanges();

            if (HttpContext.Current.Request.Files.Count != 0)
            {
                for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                {
                    tAnh anh = new tAnh
                    {
                        MaDT = HttpContext.Current.Request.Params["MaDT"]
                    };
                    var file = HttpContext.Current.Request.Files[i];
                    string fileName = Guid.NewGuid().ToString().Replace("-", "") + file.FileName;
                    anh.Anh = fileName;
                    db.tAnhs.Add(anh);
                    db.SaveChanges();
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/PhoneImages/"), fileName);
                    // Save the uploaded file  
                    file.SaveAs(fileSavePath);
                }
            }

            return Ok("Thêm sản phẩm mới thành công");
        }

        

        [HttpPut]
        public IHttpActionResult DeleteProduct(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            tDienThoai sp = db.tDienThoais.Find(id);
            if (sp == null) return NotFound();
            db.tDienThoais.Attach(sp);
            sp.TrangThai = "Ngừng kinh doanh";
            db.SaveChanges();
            return Ok("Xóa sản phẩm thành công");
        }

        
    }
}
