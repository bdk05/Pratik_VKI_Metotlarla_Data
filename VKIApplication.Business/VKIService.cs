using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using VKIApplication.Business;
using VKIApplication.Data;

namespace VKIApplication.Business
{
    public class VKIService
    {
        private static List<VKI> liste = new List<VKI>();

        public static void SaveVKI(VKI vki)
        {

            GetVKIList();
            liste.Add(vki);

            string json = JsonSerializer.Serialize(liste, new JsonSerializerOptions { IncludeFields = true });
            DosyaIslemleri.Yaz(json);
            
        }

        public static IReadOnlyCollection<VKI> GetVKIList()
        {

            string json=DosyaIslemleri.Oku();
            if (json != "")
            {
                liste = JsonSerializer.Deserialize<List<VKI>>(json, new JsonSerializerOptions { IncludeFields = true });
            }
            return liste.AsReadOnly();
        }

        public static IReadOnlyCollection<VKI> IsimdenArama(string isim)
        {
            GetVKIList();

           // var sonuc = liste.Where(q => q.ad.ToLower() == isim.ToLower());
             
            var sonuc=(from q in liste
                      where q.ad.ToLower() == isim.ToLower()
                      select q).ToList();

            if (!sonuc.Any())
                Console.WriteLine("Böyle bir hasta yok");
            return sonuc.AsReadOnly();

            //var sonuc = new List<VKI>();

            //foreach (var item in liste)
            //{
            //    if (item.ad.ToLower()==isim.ToLower())
            //    {
            //        sonuc.Add(item);
            //    }
            //}
            
        }

        public static void IsimdenSil(string isim)
        {
            var sonuc= IsimdenArama(isim);

            foreach (var item in sonuc)
            {
                liste.Remove(item);
            }
            if (sonuc.Any())
            Console.WriteLine($"{isim} isimli hasta silindi");

            string json = JsonSerializer.Serialize(liste, new JsonSerializerOptions { IncludeFields = true });
            DosyaIslemleri.Yaz(json);

           // return liste;


        }

    }
}
