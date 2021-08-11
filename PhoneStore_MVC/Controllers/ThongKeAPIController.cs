using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneStore_MVC.Models;

namespace PhoneStore_MVC.Controllers
{
    public class ThongKeAPIController : ApiController
    {
        Model1 db = new Model1();
        //[HttpGet]
        //public IHttpActionResult DoanhThuTheoNam(int nam)
        //{
        //    var list = db.DoanhThuTheoNam(nam);
        //    List<ThongKe> l = new List<ThongKe>();
        //    foreach (var item in list)
        //    {
        //        l.Add(new ThongKe() { ThongTin = "Jan", DuLieu = item.Tháng_1.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "Feb", DuLieu = item.Tháng_2.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "March", DuLieu = item.Tháng_3.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "April", DuLieu = item.Tháng_4.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "May", DuLieu = item.Tháng_5.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "June", DuLieu = item.Tháng_6.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "July", DuLieu = item.Tháng_7.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "Aug", DuLieu = item.Tháng_8.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "Sep", DuLieu = item.Tháng_9.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "Oct", DuLieu = item.Tháng_10.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "Nov", DuLieu = item.Tháng_11.ToString() });
        //        l.Add(new ThongKe() { ThongTin = "Dec", DuLieu = item.Tháng_12.ToString() });
        //    }
        //    return Ok(l);
        //}
        //[HttpGet]
        //[Route("api/ThongKeTheoHang")]
        //public IHttpActionResult ThongKeTheoHang(int nam)
        //{
        //    var list = db.ThongKeTheoHang(nam);
        //    return Ok(list);
        //}

        [HttpGet]
        public IHttpActionResult DoanhThuTheoNam(int nam)
        {
            var year = new SqlParameter("@year", nam);
            var list = db.Database.SqlQuery<DoanhThuNam>("EXEC DoanhThuTheoNam @year", year).ToList();
            List<ThongKe> l = new List<ThongKe>();
            foreach (var item in list)
            {
                l.Add(new ThongKe() { ThongTin = "Jan", DuLieu = item.Jan.ToString() });
                l.Add(new ThongKe() { ThongTin = "Feb", DuLieu = item.Feb.ToString() });
                l.Add(new ThongKe() { ThongTin = "March", DuLieu = item.Mar.ToString() });
                l.Add(new ThongKe() { ThongTin = "April", DuLieu = item.Apr.ToString() });
                l.Add(new ThongKe() { ThongTin = "May", DuLieu = item.May.ToString() });
                l.Add(new ThongKe() { ThongTin = "June", DuLieu = item.Jun.ToString() });
                l.Add(new ThongKe() { ThongTin = "July", DuLieu = item.Jul.ToString() });
                l.Add(new ThongKe() { ThongTin = "Aug", DuLieu = item.Aug.ToString() });
                l.Add(new ThongKe() { ThongTin = "Sep", DuLieu = item.Sep.ToString() });
                l.Add(new ThongKe() { ThongTin = "Oct", DuLieu = item.Oct.ToString() });
                l.Add(new ThongKe() { ThongTin = "Nov", DuLieu = item.Nov.ToString() });
                l.Add(new ThongKe() { ThongTin = "Dec", DuLieu = item.Dec.ToString() });
            }
            return Ok(l);
        }
    }
}
