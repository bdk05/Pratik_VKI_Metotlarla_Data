using System;
using System.Diagnostics;

namespace VKI
{
    public class Program
    {
        public static void Main()
        {
            
            VKIHesapla();
            
        }

        static (double kilo, double boy) KullaniciBilgileriniAl()
        {
            Console.Clear();
            Console.Write("Kilonuzu giriniz (kg): ");
            double kilo = Convert.ToDouble(Console.ReadLine());
            Console.Write("Boyunuzu giriniz (metre): ");
            double boy = Convert.ToDouble(Console.ReadLine());

            return(kilo, boy);  
        }
        static void VKIHesapla()
        {
            var operantlar=KullaniciBilgileriniAl();

            double sonuc = operantlar.kilo / Math.Pow(operantlar.boy, 2);

            if (sonuc < 18.49)
            {
                Console.WriteLine($"Hastanın; boyu: {operantlar.boy}, kilosu: {operantlar.kilo}, VKI indeksi: {sonuc}, Teşhis: ZAYIF" );
            }
            else if (sonuc >= 18.5 && sonuc < 24.99)
            {
                Console.WriteLine($"Hastanın; boyu: {operantlar.boy}, kilosu: {operantlar.kilo}, VKI indeksi:  {sonuc}, Teşhis: İDEAL");

            }
            else if (sonuc >= 25 && sonuc < 29.99)
            {
                Console.WriteLine("Hastanın; boyu: {0}, kilosu: {1}, VKI indeksi: {2}, Teşhis: HAFİF KİLOLU", operantlar.boy, operantlar.kilo, sonuc);

            }
            else
            {
                Console.WriteLine("Hastanın; boyu: {0}, kilosu: {1}, VKI indeksi: {2}, Teşhis: OBEZ", operantlar.boy, operantlar.kilo, sonuc);
            }
            DevamMi();

        }

        static void DevamMi()
        {
            string devamMi = "";

            Console.Write("Yeni bir hesaplama yapmak istiyor musunuz? (E/H)");

            devamMi = Console.ReadLine();

            switch (devamMi)
            {
                case "E":
                case "e":
                    VKIHesapla();
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