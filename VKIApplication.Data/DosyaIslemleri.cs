namespace VKIApplication.Data
{
    public class DosyaIslemleri
    {
        private const string dosyaYolu="data.txt";
        public static void Yaz(string data)
        {
            File.WriteAllText(dosyaYolu,data);
        }
        public static string Oku()
        {
            
            if (File.Exists(dosyaYolu))
             return File.ReadAllText(dosyaYolu);
            return string.Empty;
        }


    }
}