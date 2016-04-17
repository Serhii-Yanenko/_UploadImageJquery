using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3DPrinterUA.DALPrinterUA;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
namespace _3DPrinterUA.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return new FilePathResult("~/Views/Home.html", "text/html");
        }
        [HttpPost]
        public JsonResult UploadImage()
        {

            HttpPostedFile pic0 = System.Web.HttpContext.Current.Request.Files["swatch0"];
            HttpPostedFile pic1 = System.Web.HttpContext.Current.Request.Files["swatch1"];
            HttpPostedFile pic2 = System.Web.HttpContext.Current.Request.Files["swatch2"];
            HttpPostedFile pic3 = System.Web.HttpContext.Current.Request.Files["swatch3"];
            HttpPostedFile pic4 = System.Web.HttpContext.Current.Request.Files["swatch4"];
            ArrayList listOfPics = new ArrayList();
            listOfPics.Add(pic0);
            listOfPics.Add(pic1);
            listOfPics.Add(pic2);
            listOfPics.Add(pic3);
            listOfPics.Add(pic4);

            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            var ep = new EncoderParameters(1);
            ep.Param[0] = new EncoderParameter(Encoder.Quality, 200L);
            string path = @"D:\Books\Work\TheeDPrinter\_UploadImageJquery\3DPrinterUA\images\";
            DirectoryInfo di;
            string fname = HomeController.GetUnicalFolderName();
            string explPAth = path + fname;
            di = System.IO.Directory.CreateDirectory(explPAth);
            string[] locations = new string[5];
            
            long ordersID=-1;
            try
            {
                foreach (HttpPostedFile pic in listOfPics)
                {
                    if (pic.ContentLength > 0)
                    {
                        string FileName = pic.FileName;
                        byte[] input = new byte[pic.ContentLength];
                        Stream stream = pic.InputStream;
                        stream.Read(input, 0, pic.ContentLength);
                        Image image = Image.FromStream(pic.InputStream);

                        locations[listOfPics.IndexOf(pic)] = explPAth + @"\" + FileName;
                        image.Save(locations[listOfPics.IndexOf(pic)], jpgEncoder, ep);

                    }
                }
                ConnectDB conn = new ConnectDB();
                ordersID = conn.InsertImage(locations[0], locations[1], locations[2], locations[3], locations[4]);
                


            }
            catch (NullReferenceException ex)
            {
                return Json(ordersID, JsonRequestBehavior.AllowGet);
            }
            
            return Json(new { Id=ordersID }, JsonRequestBehavior.AllowGet);
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        [HttpPost]
        public JsonResult VerifyOrder()
        {
            ConnectDB conn = new ConnectDB();
            var req = System.Web.HttpContext.Current.Request.Form["VerifID"];
            long idToVerify = (long)Convert.ToInt32(req);
            conn.VerifyOrder(idToVerify);
            return Json(new { result = "Your Order Was Succesfully Submited" });
        }
        private static string GetUnicalFolderName()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N");
        }

        
    }

}

