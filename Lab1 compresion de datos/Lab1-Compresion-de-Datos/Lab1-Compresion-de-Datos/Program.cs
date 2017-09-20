using Lab1_Compresion_de_Datos.Huffman;
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
            Console.Title = "RLE AND HUFFMAN COMPRESSION BY MANSILLA AND CHANG";

            Instructions();
            Console.Clear();
            InstructionsSecondLevel();
            Console.ReadKey();
        }

        private static void RLECOMP()
        {
            Console.WriteLine("                                            RLE and Huffman COMPRESSOR V 1.1");
            Console.WriteLine();
            Console.Write("RLE> ");
            while (!CommadLine.RecognizeCommandRLE(Console.ReadLine()))
            {
                Console.WriteLine();
                Console.Write("RLE> ");
            }
        }

        private static void HUFFMANCOMP()
        {
            Console.WriteLine("                                            RLE and Huffman COMPRESSOR V 1.1");
            Console.WriteLine();
            Console.Write("HUFFMAN> ");
            while (!CommadLine.RecognizeCommandHuffman(Console.ReadLine()))
            {
                Console.WriteLine();
                Console.Write("HUFFMAN> ");
            }
        }

        private static void Instructions()
        {
            Console.WriteLine("                                       Welcome to RLE and Huffman COMPRESSOR V 1.1");
            Console.WriteLine("                                                    -INSTRUCTIONS-");
            Console.WriteLine();
            Console.WriteLine("RLE COMPRESSION:");
            Console.WriteLine();
            Console.WriteLine("1) Compress: To compress a file follow these steps:");
            Console.WriteLine("1.1)Write in COMPRESSOR level: rle.exe -c -f (directory where the file is saved)");
            Console.WriteLine("1.2)Press Enter");
            Console.WriteLine("1.3)Enjoy the statistics.");
            Console.WriteLine("1.4)Search your file in the same directory with .comp at the end.");
            Console.WriteLine();
            Console.WriteLine("2) Decompress: To decompress a file follow these steps:");
            Console.WriteLine("2.1)Write in COMPRESSION level: rle.exe -d -f (directory where the file is saved).comp");
            Console.WriteLine("2.2)Press Enter");
            Console.WriteLine("2.3)Search your file in the same directory with the original extension at the start.");
            Console.WriteLine();
            Console.WriteLine("HUFFMAN COMPRESSION:");
            Console.WriteLine();
            Console.WriteLine("1) Compress: To compress a file follow these steps:");
            Console.WriteLine("1.1)Write in COMPRESSION level: hfm.exe -c -f (directory where the file is saved)");
            Console.WriteLine("1.2)Press Enter");
            Console.WriteLine("1.3)Enjoy the statistics.");
            Console.WriteLine("1.4)Search your file in the same directory with .comp at the end.");
            Console.WriteLine();
            Console.WriteLine("2) Decompress: To decompress a file follow these steps:");
            Console.WriteLine("2.1)Write in COMPRESSION level: hfm.exe -d -f (directory where the file is saved).comp");
            Console.WriteLine("2.2)Press Enter");
            Console.WriteLine("2.3)Search your file in the same directory with the original extension at the start.");
            Console.WriteLine("PRESS ENTER TO CONTINUE!");
            Console.ReadKey();
        }

        private static void InstructionsSecondLevel()
        {
            Console.WriteLine();
            Console.WriteLine("                                                -SELECT YOUR COMPRESSION METHOD-");
            Console.WriteLine();
            Console.WriteLine("Type HF to Huffman then press enter, or type RL to RLE then press enter!");
            Console.WriteLine();
            Console.Write("> ");
            string answer = string.Empty;
            answer = Console.ReadLine();
            switch (answer)
            {
                case "HF":
                    HUFFMANCOMP();
                    break;
                case "RL":
                    RLECOMP();
                    break;
                case "hf":
                    HUFFMANCOMP();
                    break;
                case "rl":
                    RLECOMP();
                    break;
                default:
                    Console.Clear();
                    InstructionsSecondLevel();
                    break;
            }
        }
    }
}
