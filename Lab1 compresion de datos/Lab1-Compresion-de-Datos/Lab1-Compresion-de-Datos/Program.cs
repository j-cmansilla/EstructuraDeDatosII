using Lab1_Compresion_de_Datos.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
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
            filePath = Console.ReadLine();
            FileStream original = new FileStream(filePath, FileMode.Open);
            BinaryReader lecturaBinaria = new BinaryReader(original);
            var bytes = lecturaBinaria.ReadBytes((int)original.Length);
            Compress.HuffmanCompression(bytes, filePath);

            AnalyzeTxt AT = new AnalyzeTxt();
            Console.WriteLine("File Compressed!");
            Instructions();
            Console.Clear();
            Console.WriteLine("                                             Welcome to RLE COMPRESSOR V 1.1");
            Console.WriteLine();
            Console.Write("RLE> ");
            while (!CommadLine.RecognizeCommand(Console.ReadLine()))
            {
                Console.WriteLine();
                Console.Write("RLE> ");
            }
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
