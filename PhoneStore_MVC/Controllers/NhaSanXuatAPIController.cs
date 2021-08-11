using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneStore_MVC.Models;

namespace PhoneStore_MVC.Controllers
{
    public class NhaSanXuatAPIController : ApiController
    {
        Model1 db = new Model1();
        public IHttpActionResult Get()
        {
            return Ok(db.tNhaSanXuats.Select(a=> new { a.MaNSX,a.TenNSX,a.Diachi,a.SDT,a.Email}));
        }

        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var cate = db.tNhaSanXuats.Find(id);
            if (cate == null) return NotFound();
            return Ok(cate);
        }
        [HttpPost]
        public IHttpActionResult Add([FromBody] tNhaSanXuat s)
        {
            if (string.IsNullOrWhiteSpace(s.MaNSX)) return Content(HttpStatusCode.NotFound, "Mã nhà sản xuất không được để trống");
            if (string.IsNullOrWhiteSpace(s.TenNSX)) return Content(HttpStatusCode.NotFound, "Tên nhà sản xuất không được để trống");
            if (s == null) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    db.tNhaSanXuats.Add(s);
                    db.SaveChanges();
                    return Ok("Thêm nhà sản xuất mới thành công");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            return Content(HttpStatusCode.BadRequest, ModelState);
        }
        [HttpPut]
        public IHttpActionResult Edit([FromBody] tNhaSanXuat s)
        {
            if (s == null || string.IsNullOrWhiteSpace(s.TenNSX)) return NotFound();
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok("Sửa thông tin nhà cung cấp thành công");
        }
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var s = db.tNhaSanXuats.Find(id);
            if (s == null) return NotFound();
            db.tNhaSanXuats.Remove(s);
            db.SaveChanges();
            return Ok("Xóa nhà cung cấp thành công");
        }
    }
}
