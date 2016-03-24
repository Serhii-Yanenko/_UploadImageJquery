using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3DPrinterUA.DALPrinterUA;
using MySql.Data;
using MySql.Data.MySqlClient;

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
                var connDb = ConnectionClass.Instance();
            System.IO.BufferedStream image0 = new System.IO.BufferedStream(pic0.InputStream);
            byte[] buffer0 = new byte[image0.Length];
            image0.Read(buffer0, 0, buffer0.Length);
            System.IO.BufferedStream image1 = new System.IO.BufferedStream(pic1.InputStream);
            byte[] buffer1 = new byte[image1.Length];
            image1.Read(buffer1, 0, buffer1.Length);

            System.IO.BufferedStream image2 = new System.IO.BufferedStream(pic2.InputStream);
            byte[] buffer2 = new byte[image2.Length];
            image2.Read(buffer2, 0, buffer2.Length);

            System.IO.BufferedStream image3 = new System.IO.BufferedStream(pic3.InputStream);
            byte[] buffer3 = new byte[image3.Length];
            image3.Read(buffer3, 0, buffer3.Length);

            System.IO.BufferedStream image4 = new System.IO.BufferedStream(pic4.InputStream);
            byte[] buffer4 = new byte[image4.Length];
            image4.Read(buffer4, 0, buffer4.Length);
            connDb.DataBaseName = "3dprinterua";
            if (connDb.IsConnect())
            {

                string query = "Insert into orderprint(image1, image2 ,image3, image4, image5, isVerified)"+
                    " Values(@image1, @image2, @image3, @image4, @image5, @isVerified)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connDb.Connection;
                cmd.CommandText = query;
                cmd.Parameters.Add("@image1", MySqlDbType.LongBlob);
                cmd.Parameters.Add("@image2", MySqlDbType.LongBlob);
                cmd.Parameters.Add("@image3", MySqlDbType.LongBlob);
                cmd.Parameters.Add("@image4", MySqlDbType.LongBlob);
                cmd.Parameters.Add("@image5", MySqlDbType.LongBlob);
                cmd.Parameters.Add("@isVerified", MySqlDbType.Bit);
                cmd.Parameters["@image1"].Value = image0;
                cmd.Parameters["@image2"].Value = image1;
                cmd.Parameters["@image3"].Value = image2;
                cmd.Parameters["@image4"].Value = image3;
                cmd.Parameters["@image5"].Value = image4;
                cmd.Parameters["@isVerified"].Value = false;

                


                 

                cmd.ExecuteNonQuery();
            }
            connDb.Close();

            return RedirectToAction("Home", "Index");
        }
    }
}
