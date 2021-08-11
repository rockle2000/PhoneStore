using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore_MVC.Models;

namespace PhoneStore_MVC.Controllers
{
    public class NhanViensController : Controller
    {
        Model1 db = new Model1();
        // GET: NhanViens
        public ActionResult Index()
        {
            var nv = db.tNhanViens;
            return View(nv.ToList());
        }
    }
}