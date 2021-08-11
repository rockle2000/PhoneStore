using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace PhoneStore_MVC.Utils
{
    public class CheckSession:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var MySession = HttpContext.Current.Session;

           if (MySession["Admin"] == null)
            {
                filterContext.Result = new RedirectResult(string.Format("/Admin/Login"));
            }
        }

    }
}