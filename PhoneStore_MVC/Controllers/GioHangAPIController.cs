using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneStore_MVC.Models;
using PhoneStore_MVC.Resources;

namespace PhoneStore_MVC.Controllers
{
    public class GioHangAPIController : ApiController
    {
        Model1 db = new Model1();
        [HttpPost,Route("api/ThanhToan")]
        public IHttpActionResult ThanhToan([FromBody] tHoaDonBan hd)
        {
            if (ModelState.IsValid)
            {
                hd.NgayBan = DateTime.Now;
                db.tHoaDonBans.Add(hd);
                db.SaveChanges();
                return Ok("Check out completed");
            }
            return NotFound();
        }
    }
}
