using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneStore_MVC.Models;

namespace PhoneStore_MVC.Controllers
{
    public class HoaDonAPIController : ApiController
    {
        Model1 db = new Model1();
        [HttpGet,Route("api/GetListBill")]
        public IHttpActionResult GetListBill()
        {
            var bill = db.tHoaDonBans.Select(x => new {x.SoHDB,x.EmailKH,x.NgayBan,x.DiaChi,x.TongTien,x.SoDienThoai,x.TrangThai,x.MaKhuyenMai,});
            return Ok(bill);
        }
        [HttpGet,Route("api/GetBillDetails")]
        public IHttpActionResult GetBillDetails(int id)
        {
            if (id > 0 && !string.IsNullOrWhiteSpace(id.ToString()))
            {
                var bill = db.tChiTietHDBs.Where(x => x.SoHDB == id).Select(x => new { x.SoHDB, x.MaDT, x.Mau, x.SoLuong, x.DonGiaBan })
                    .Join(db.tDienThoais,
                        ct => ct.MaDT,
                        dt => dt.MaDT,
                        (ct,dt) => new { ct.SoHDB,ct.MaDT,dt.TenDT, ct.Mau, ct.SoLuong, ct.DonGiaBan }
                    );
                return Ok(bill);
            }
            return NotFound();
        }
        [HttpPut,Route("api/FinishBill")]
        public IHttpActionResult FinishBill(int id)
        {
            if (id <= 0) return NotFound();
            tHoaDonBan hd = db.tHoaDonBans.Find(id);
            if (hd == null) return NotFound();
            db.tHoaDonBans.Attach(hd);
            hd.TrangThai = "Completed";
            db.SaveChanges();
            return Ok("Xác nhận đơn hàng thành công");
        }
        [HttpDelete, Route("api/CancelBill")]
        public IHttpActionResult CancelBill(int id)
        {
            if (id <= 0) return NotFound();
            tHoaDonBan hd = db.tHoaDonBans.Find(id);
            if (hd == null) return NotFound();
            db.tHoaDonBans.Remove(hd);
            //hd.TrangThai = "Canceled";
            db.SaveChanges();
            return Ok("Hủy đơn hàng thành công");
        }
    }
}
