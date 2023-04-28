using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hastane_Otomasyonu
{
    class Human
    {
        public int[] yas = new int[100];
        public string[] tc = new string[100];
        public string[] isim = new string[100];
        public string[] hastalikTuru = { "Grip", "Soğuk Algınlığı", "Boğaz iltihaplanması" };
        public string[] kalpHastaliklari = { "Koroner arter hastalığı", "Kalp krizi (miyokard enfarktüsü)", "Kalp yetmezliği", "Kalp kapakçığı hastalıkları", "Ritim bozuklukları (aritmi)", "Kalp kası hastalıkları (kardiyomiyopatiler)", "Kalp damar hastalıkları (arteriyel ve venöz hastalıklar)", "Konjenital kalp hastalıkları (doğuştan kalp hastalıkları)", "Perikardit (kalp zarı iltihabı)", "Aort hastalıkları" };


    }

    class Hospital : Human
    {
        public int HastaNumarasi;
        public string[] bolumler = { "Kalp Hastalıkları", "Klinik Hastalıkları" };
        public int[] sira = new int[100];
        public string[] hastaHastalikleri = new string[100];

        

        public void HastaSorgulama()
        {
            Console.Clear();
            KlinikSorgulama();

        }

        public void kalpGiris()
        {
            Random rnd = new Random();
        a:
            Console.WriteLine("Hasta türü Seçiniz\n1-Yeni Hasta\n2-Kayıtlı Hasta");
            string secenek = Console.ReadLine();
            int secenekler;
            Console.Clear();
            if(!int.TryParse(secenek,out secenekler))
            {
                Console.WriteLine("Doğru bir seçim yapınız.");
                Console.Clear();
                goto a;
            }

            switch (secenekler)
            {
                case 1:
                    KalpKayit();
                    break;
                case 2:
                    KalpSorgulama();
                    break;
            }
        }

        public void KalpKayit()
        {
            Random rnd = new Random();

            HastaNumarasi++;
            int sira = HastaNumarasi;
            string HastalikNo;

            Console.WriteLine(HastaNumarasi);
            Console.WriteLine("Hastanın Hastanın Bilgilerini giriniz.");
            Console.WriteLine("Hasta ismini giriniz");

            isim[HastaNumarasi] = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hasta yaşını giriniz");
            bool var = false;
            while (!var)
            {
                Console.WriteLine("Hasta yaşını giriniz:");
                string Yas = Console.ReadLine();
                if (int.TryParse(Yas, out yas[HastaNumarasi]))
                {
                    var = true;

                }
                else
                {
                    Console.Error.Write("Lütfen geçerli bir yaş giriniz.");
                }
            }

            while (true)
            {
                Console.WriteLine("Hasta TC kimlik numarasını giriniz:");
                string tcNumarasi = Console.ReadLine();

                // TC numarasının doğru uzunlukta girildiğinden emin olun
                if (tcNumarasi.Length != 11)
                {
                    Console.WriteLine("TC kimlik numarası 11 haneli olmalıdır. Lütfen tekrar giriniz.");
                    continue;
                }

                // TC numarasının sadece rakamlardan oluştuğunu kontrol edin
                if (!long.TryParse(tcNumarasi, out long n))
                {
                    Console.WriteLine("TC kimlik numarası sadece rakamlardan oluşabilir. Lütfen tekrar giriniz.");
                    continue;
                }

                // TC numarasının daha önce kaydedilip kaydedilmediğini kontrol edin
                bool isTcKayitli = false;
                for (int i = 1; i <= HastaNumarasi; i++)
                {
                    if (tc[i] == tcNumarasi)
                    {
                        isTcKayitli = true;
                        Console.WriteLine("Bu TC kimlik numarası daha önce kaydedilmiştir. Lütfen farklı bir numara giriniz.");
                        break;
                    }
                }

                if (!isTcKayitli)
                {
                    tc[HastaNumarasi] = tcNumarasi;
                    break;
                }
            }
            donus:
            Console.WriteLine("Hastalık Türü Seçiniz");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + 1 + "-" + kalpHastaliklari[i]);
            }
            HastalikNo = Console.ReadLine();
            int hastaliklarNo;
            if(!int.TryParse(HastalikNo,out hastaliklarNo))
            {
                Console.Clear();
                goto donus;
            }
            hastaliklarNo = hastaliklarNo - 1;
            hastaHastalikleri[HastaNumarasi] += kalpHastaliklari[hastaliklarNo]; //Hastalığın diziye eklendiği yeni dizi 
            Console.Clear();
            Console.WriteLine("Hasta Bilgileri;");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Hastanın Adı: " + isim[HastaNumarasi]);
            Console.WriteLine("Hastanın TC Kimliği: " + tc[HastaNumarasi]);
            Console.WriteLine("Hastanın yaşı: " + yas[HastaNumarasi]);
            Console.WriteLine("Hasta Sıra Numarası: " + sira);
            Console.WriteLine("Hastanın Hastalığı: " + kalpHastaliklari[hastaliklarNo]);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Diğer ekrana geçmek için herhangi bir tuşa basınız tuşuna basınız.");
            Console.ReadKey();
            Console.Clear();
        }


        public void KlinikKayit()
        {
            Random rnd = new Random();

            HastaNumarasi++;
            int sira = HastaNumarasi;
            int HastalikNo;

            Console.WriteLine(HastaNumarasi);
            Console.WriteLine("Hastanın Hastanın Bilgilerini giriniz.");
            Console.WriteLine("Hasta ismini giriniz");
            isim[HastaNumarasi] = Console.ReadLine();
            Console.WriteLine("Hasta yaşını giriniz");
            isim[HastaNumarasi] = Console.ReadLine();

            bool var = false;
            while (!var)
            {
                Console.WriteLine("Hasta yaşını giriniz:");
                string Yas = Console.ReadLine();
                if (int.TryParse(Yas, out yas[HastaNumarasi]))
                {
                    var = true;
                }
                else
                {
                    Console.Error.Write("Lütfen geçerli bir yaş giriniz.");
                }
            }

            while (true)
            {
                Console.WriteLine("Hasta TC kimlik numarasını giriniz:");
                string tcNumarasi = Console.ReadLine();

                // TC numarasının doğru uzunlukta girildiğinden emin olun
                if (tcNumarasi.Length != 11)
                {
                    Console.WriteLine("TC kimlik numarası 11 haneli olmalıdır. Lütfen tekrar giriniz.");
                    continue;
                }

                // TC numarasının sadece rakamlardan oluştuğunu kontrol edin
                if (!long.TryParse(tcNumarasi, out long n))
                {
                    Console.WriteLine("TC kimlik numarası sadece rakamlardan oluşabilir. Lütfen tekrar giriniz.");
                    continue;
                }

                // TC numarasının daha önce kaydedilip kaydedilmediğini kontrol edin
                bool isTcKayitli = false;
                for (int i = 1; i <= HastaNumarasi; i++)
                {
                    if (tc[i] == tcNumarasi)
                    {
                        isTcKayitli = true;
                        Console.WriteLine("Bu TC kimlik numarası daha önce kaydedilmiştir. Lütfen farklı bir numara giriniz.");
                        break;
                    }
                }

                if (!isTcKayitli)
                {
                    tc[HastaNumarasi] = tcNumarasi;
                    break;
                }
            }

            Console.WriteLine("Hastalık Türü Seçiniz");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i + 1 + "-" + hastalikTuru[i]);
            }
            HastalikNo = Convert.ToInt32(Console.ReadLine());
            HastalikNo = HastalikNo - 1;
            hastaHastalikleri[HastaNumarasi] += hastalikTuru[HastalikNo]; //Hastalığın diziye eklendiği yeni dizi 
            Console.Clear();
            Console.WriteLine("Hasta Bilgileri;");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Hastanın Adı: " + isim[HastaNumarasi]);
            Console.WriteLine("Hastanın TC Kimliği: " + tc[HastaNumarasi]);
            Console.WriteLine("Hastanın yaşı: " + yas[HastaNumarasi]);
            Console.WriteLine("Hasta Sıra Numarası: " + sira);
            Console.WriteLine("Hastanın Hastalığı: " + hastaHastalikleri[HastaNumarasi]);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Diğer ekrana geçmek için herhangi bir tuşa basınız tuşuna basınız.");
            Console.ReadKey();
            Console.Clear();
        }

        public void KlinikSorgulama()
        {
            Console.WriteLine("Hasta Sorgulama Bölümüne Hoşgeldiniz");
            Console.WriteLine("------------------------------------");
            
            Thread.Sleep(2500);

            Console.Clear();
            Console.WriteLine("Hastanın TC kimlik Numarasını giriniz");
            string search = Console.ReadLine();
            bool var = false;
            for (int i = 0; i <= 99; i++)
            {
                if (search == tc[i])
                {
                    Console.WriteLine("Hasta Bilgileri;");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Hastanın Adı: " + isim[i]);
                    Console.WriteLine("Hastanın TC Kimliği: " + tc[i]);
                    Console.WriteLine("Hastanın yaşı: " + yas[i]);
                    Console.WriteLine("Hastanın Hastalığı: " + hastaHastalikleri[i]);
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Ana Sayfaya geçmek için herhangi bir tuşa basın");
                    Console.ReadKey();
                    Console.Clear();
                    var = true;
                    break;
                }
            }
            if (!var)
            {
                Console.WriteLine("Hasta kaydı bulunmamaktadır lütfen TC numaranızı doğru girdiğinizden emin olun");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void KalpSorgulama()
        {
            Console.WriteLine("Hasta Sorgulama Bölümüne Hoşgeldiniz");
            Console.WriteLine("------------------------------------");
            
            Thread.Sleep(2500);

            Console.Clear();
            Console.WriteLine("Hastanın TC kimlik Numarasını giriniz");
            string search = Console.ReadLine();
            bool var = false;
            for (int i = 0; i <= 99; i++)
            {
                if (search == tc[i])
                {
                    Console.WriteLine("Hasta Bilgileri;");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Hastanın Adı: " + isim[i]);
                    Console.WriteLine("Hastanın TC Kimliği: " + tc[i]);
                    Console.WriteLine("Hastanın yaşı: " + yas[i]);
                    Console.WriteLine("Hastanın Hastalığı: " + hastaHastalikleri[i]);
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Ana Sayfaya geçmek için herhangi bir tuşa basın");
                    Console.ReadKey();
                    Console.Clear();
                    var = true;
                    break;
                }
            }
            if (!var)
            {
                Console.WriteLine("Hasta kaydı bulunmamaktadır lütfen TC numaranızı doğru girdiğinizden emin olun");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human();
            Hospital hospital = new Hospital();
            
            while(true)
            {
                Console.WriteLine("Merhaba Hastane Merkezine Hoş geldiniz\nBir Adet İşlem Seçiniz\n1-Kalp Hastalıkları Randevu Kayıt/Giriş İşlemleri\n2-Klinik Sıra Numarası Almak İçin Kullanın\n3-Hasta Sorgulama\n4-Çıkış");
                string secimString = Console.ReadLine();
                int secim;
                if(!int.TryParse(secimString, out secim )) 
                {
                    Console.Clear();
                    Console.WriteLine("Hatalı tuşlama yaptınız doğru bir tuşlama yapınız.");
                    Console.WriteLine("--------------------------------------------------");
                    continue;
                }
                
                Console.Clear();
                switch (secim)
                {
                    case 1:
                        hospital.kalpGiris();
                        break;        //kalp hastalıkları hasta kayıt/giriş işlemleri
                    case 2:
                        hospital.KlinikKayit();
                        break;     //klinik Hastaları sıra numarası almak için kullanılır
                    case 3:
                        hospital.HastaSorgulama();
                        break; //Hasta tc numarası ile bilgilerini verir
                    case 4:
                        Console.WriteLine("Bizi tercih ettiğiniz için teşekkür ederiz.\nSağlıklı günler dileriz.");
                        Thread.Sleep(2000);
                        return;
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim yaptınız doğru seçim yapınız");
                        break;
                }
            }
        }
    }
}