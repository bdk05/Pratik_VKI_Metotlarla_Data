using System;
using System.Diagnostics;
using VKIApplication.Business;

namespace VKIApplication
{
    public class Program
    {
        public static void Main()
        {

            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1.Yeni Hasta Bilgisi Gir\n2.Hasta Listesi\n3.Hasta Arama \n4. Hasta Sil \n5.Çıkış\n ");
            MenuSelection();

        }

        static void MenuSelection()
        {
            Console.Write("Yapılacak işlemi seçiniz: ");
            int secim = Convert.ToInt32(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    HastaBilgileriniAl();
                    break;
                case 2:
                    HastaListesiniGetir();
                    break;
                case 3:
                    HastaAra();
                    break;
                case 4:
                    HastaSil();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Yanlış giriş yaptınız");
                    DevamMi();
                    break;
            }

        }

        private static void HastaSil()
        {
            Console.WriteLine("Hasta adi giriniz: ");
            string isim = Console.ReadLine();
            var data=VKIService.IsimdenSil(isim);
            if (data.Any())
               Console.WriteLine($"{isim} isimli hasta silindi");
            else
                Console.WriteLine("Böyle bir hasta yok");


            DevamMi();
            
        }

        private static void HastaAra()
        {
            Console.WriteLine("Hasta adi giriniz: ");
            string isim=Console.ReadLine(); 
            var data=VKIService.IsimdenArama(isim);

            if (!data.Any())
                Console.WriteLine("Böyle bir hasta yok");
            WriteFromList(data);

            DevamMi();

        }

        private static void HastaListesiniGetir()
        {
            var vkiList = VKIService.GetVKIList();
            WriteFromList(vkiList);
            DevamMi();
        }

        private static void WriteFromList(IReadOnlyCollection<VKI> vkiList)
        {
            foreach (VKI item in vkiList)
            {
                WriteToScreen(item);

            }
        }

        static void HastaBilgileriniAl()
        {
            VKI newVKI = new VKI();
            Console.Clear();
            Console.Write("Adinizi giriniz: ");
            newVKI.ad = Console.ReadLine();
            Console.Write("Soyadinizi giriniz: ");
            newVKI.soyad = Console.ReadLine();
            Console.Write("Kilonuzu giriniz (kg): ");
            newVKI.kilo = Convert.ToDouble(Console.ReadLine());
            Console.Write("Boyunuzu giriniz (metre): ");
            newVKI.boy = Convert.ToDouble(Console.ReadLine());

            VKIService.SaveVKI(newVKI);
            WriteToScreen(newVKI);
            DevamMi();

        }
        static void WriteToScreen(VKI v)
        {
          if (v.VKI_Hesapla() < 18.49)
            {
                Console.WriteLine($"{v.ad} {v.soyad} adlı hastanın; boyu: {v.boy}, kilosu: {v.kilo}, VKI indeksi: {v.VKI_Hesapla()}, Teşhis: ZAYIF");
            }
            else if (v.VKI_Hesapla() >= 18.5 && v.VKI_Hesapla() < 24.99)
            {
                Console.WriteLine($"{v.ad} {v.soyad} adlı hastanın; boyu: {v.boy}, kilosu: {v.kilo}, VKI indeksi:  {v.VKI_Hesapla()}, Teşhis: İDEAL");

            }
            else if (v.VKI_Hesapla() >= 25 && v.VKI_Hesapla() < 29.99)
            {
                Console.WriteLine($"{v.ad} {v.soyad} adlı hastanın; boyu: {0}, kilosu: {1}, VKI indeksi: {2}, Teşhis: HAFİF KİLOLU", v.boy, v.kilo, v.VKI_Hesapla());

            }
            else
            {
                Console.WriteLine($"{v.ad} {v.soyad} adlı hastanın; boyu: {0}, kilosu: {1}, VKI indeksi: {2}, Teşhis: OBEZ", v.boy, v.kilo, v.VKI_Hesapla());
            }
            

        }

        static void DevamMi()
        {
            string devamMi = "";

            Console.Write("Yeni bir işlem yapmak istiyor musunuz? (E/H)");

            devamMi = Console.ReadLine();

            switch (devamMi)
            {
                case "E":
                case "e":
                    Menu();
                    break;
                case "H":
                case "h":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Hatalı giriş yaptınız");
                    DevamMi();
                    break;
            }

        }

    }

}