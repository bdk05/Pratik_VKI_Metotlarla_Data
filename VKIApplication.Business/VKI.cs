using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKIApplication.Business
{
    public class VKI
    {
        public string ad;
        public string soyad;
        public double boy;
        public double kilo;
        

        public double VKI_Hesapla()
        {
            return (kilo / Math.Pow(boy, 2));
        }

    }
}
