using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Captura;

namespace screen_Recorder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            int input;

            start:
            Console.WriteLine("Ekran Kaydını Başlatmak İçin 1'e Basın... \nProgramı Kapatmak İçin 2'ye Basın...\nKare Hızı ve Kalite Belirlemek İçin 3'e Basın... (Opsiyon)");
            input = Convert.ToInt32(Console.ReadLine());
           if (input == 3) { 
                frm: Console.Write("Önerilen Kare Hızı 10'dur \nKare Hızı Belirlemek İçin Bir Değer Girin : "); int frame = Convert.ToInt16(Console.ReadLine());
              
                if (frame == null) { Console.Write("Kare Hızı Belirleyin: "); goto frm; }
               qlt: Console.Write("Önerilen Kalite Değeri 70'dir \nKalite Değeri Belirlemek İçin Bir Değer Girin : "); int quality = Convert.ToInt16(Console.ReadLine());
               
                if (quality == null) { Console.Write("Kalite Değeri Belirleyin: "); goto qlt; }

                Console.Write("Kayıt Adı Belirleyin : ");

                string input2 = Console.ReadLine();
                if (input2 == null || input2 == "" || input2 == " ") { input2 = "isimsiz "; }
                string filepath = AppDomain.CurrentDomain.BaseDirectory + input2 + "_" + DateTime.Now.Date.ToLongDateString().Replace('/', '_') + ".avi";
                var rec = new Recorder(new RecorderParams(filepath, frame, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, quality));
                Console.Clear();
                Console.WriteLine("Kayıt Başladı ...");

                Console.WriteLine("\nBelirlenen Kayıt Adı: "+input2+"\nBelirlenen Kare Hızı :"+frame+"\nBelirlenen Kalite Değeri :"+quality+"\n");
                Console.Write("\nKaydı Durdurmak İçi Herhangi Bir Tuşa  Basın ...");
                Console.ReadKey();
                rec.Dispose();
            }

            else if (input >= 4) { Console.WriteLine("Geçersiz Bir Değer Girdiniz.\nGirdiğiniz değer 1 veya 2 olabilir\n\n"); goto start; }

            else if (input == 1)
            {
                int frame = 10;int quality = 70;
                Console.Write("Kayıt Adı Belirleyin : ");

                string input2 = Console.ReadLine();
                if (input2 == null || input2 == "" || input2 == " ") { input2 = "isimsiz "; }
                string filepath = AppDomain.CurrentDomain.BaseDirectory + input2 + "_" + DateTime.Now.Date.ToLongDateString().Replace('/', '_') + ".avi";
                var rec = new Recorder(new RecorderParams(filepath, frame, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, quality));

                Console.WriteLine("Kayıt Başladı ...");
                Console.Write("\nKaydı Durdurmak İçi Herhangi Bir Tuşa  Basın ...");
                Console.ReadKey();

                // Finish Writing
                rec.Dispose();
            }
            else if (input == 2) { }

        }
    }
}
