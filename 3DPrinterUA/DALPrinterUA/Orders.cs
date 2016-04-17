using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3DPrinterUA.DALPrinterUA
{
    public class Orders
    {
        public int ID { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image4 { get; set; }
        public string image5 { get; set; }
        public bool IsVerify { get; set; }
        public Orders(int ID, string image1, string image2, string image3, string image4, string image5, bool isVerify)
        {
            this.ID = ID;
            this.image1 = image1;
            this.image2 = image2;
            this.image3 = image3;
            this.image4 = image4;
            this.image5 = image5;
            this.IsVerify = isVerify;
        }
        public Orders(string image1, string image2, string image3, string image4, string image5, bool isVerify)
        {
            this.image1 = image1;
            this.image2 = image2;
            this.image3 = image3;
            this.image4 = image4;
            this.image5 = image5;
            this.IsVerify = isVerify;
        }
    }
}
