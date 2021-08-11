using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore_MVC.Utils;

namespace PhoneStore_MVC.Controllers
{
    public class NhaSanXuatController : Controller
    {
        // GET: NhaSanXuat
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CheckSession]
        public ActionResult AddSupplier()
        {
            return View();
        }
    }
}