using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3DPrinterUA.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult LogIn(string loginName, string password)
        {

            return View();
        }
        public ActionResult Admin()
        {

            return View();
        }
    }
}
