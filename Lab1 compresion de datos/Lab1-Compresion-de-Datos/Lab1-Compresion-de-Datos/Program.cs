using Lab1_Compresion_de_Datos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = string.Empty;
            Dictionary<string, int> Characters = new Dictionary<string, int>();
            UploadFile UF = new UploadFile();
            AnalyzeTxt AT = new AnalyzeTxt();
            Instructions();
            Console.Clear();
            Console.WriteLine("                                             Welcome to RLE COMPRESSOR V 1.1");
            Console.WriteLine();
            Console.Write("RLE> ");
            filePath = Console.ReadLine();
            string[] array = Compress.CompressAllLines(UF.OpenFileString(filePath));
            Console.ReadKey();

        }
        
        private static void Instructions()
        {
            Console.WriteLine("                                             Welcome to RLE COMPRESSOR V 1.1");
            Console.WriteLine("                                                    -INSTRUCTIONS-");
            Console.WriteLine();
            Console.WriteLine("1) Compress: To compress a file follow these steps:");
            Console.WriteLine("1.1)Write in RLE level: rle.exe -c -f(directory where the file is saved)");
            Console.WriteLine("1.2)Press Enter");
            Console.WriteLine("1.3)Search your file in the same directory with .rlex at the end.");
            Console.WriteLine("1.4)Enjoy the statistics.");
            Console.WriteLine();
            Console.WriteLine("2) Decompress: To decompress a file follow these steps:");
            Console.WriteLine("2.1)Write in RLE level: rle.exe -d -f(directory where the file is saved).rlex");
            Console.WriteLine("2.2)Press Enter");
            Console.WriteLine("2.3)Search your file in the same directory with the original extension at the start.");
            Console.WriteLine();
            Console.WriteLine("PRESS ENTER TO CONTINUE!");
            Console.ReadKey();
        }
    }
}
