using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3DPrinterUA.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Index()
        {
            return new FilePathResult("~/Views/Home.html", "text/html");
        }
        [HttpPost]
        public ActionResult UploadImage()
        {
           
                var pic0 = System.Web.HttpContext.Current.Request.Files["swatch0"];
                var pic1 = System.Web.HttpContext.Current.Request.Files["swatch1"];
                var pic2 = System.Web.HttpContext.Current.Request.Files["swatch2"];
                var pic3 = System.Web.HttpContext.Current.Request.Files["swatch3"];
                var pic4 = System.Web.HttpContext.Current.Request.Files["swatch4"];
            return RedirectToAction("Home", "Index");
        }
    }
}
