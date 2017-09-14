using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos.Utilities
{
    static class CommadLine
    {
        private static void ChangeColor(string color)
        {
            if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static bool RecognizeCommand(string command)
        {
            string[] commands = command.Split(' ');
            string filePath = string.Empty;
            if (commands.Length > 4)
            {
                for (int i = 3; i < commands.Length; i++)
                {
                    filePath = filePath +" "+commands[i];
                }
            }
            else
            {
                filePath = commands[3];
            }
            if (commands.Length<4)
            {
                return false;
            }
            else
            {
                if (commands[0].Equals("rle.exe"))
                {
                    if (!commands[1].ToLower().Equals("-c"))
                    {
                        if (!commands[1].ToLower().Equals("-d"))
                        {
                            ChangeColor("red");
                            Console.WriteLine("Sentence '-c or -d' is missing!");
                            ChangeColor("white");
                            return false;
                        }
                        else
                        {
                            if (!commands[2].ToLower().Equals("-f"))
                            {
                                ChangeColor("red");
                                Console.WriteLine("Sentence '-f' is missing!");
                                ChangeColor("s");
                                return false;
                            }
                            else
                            {
                                string originalFilePath = filePath;
                                if (!File.Exists(filePath))
                                {
                                    ChangeColor("red");
                                    Console.WriteLine("The file specified not exists!");
                                    ChangeColor("r");
                                    return false;
                                }
                                else
                                {
                                    string ext = string.Empty;
                                    for (int i = filePath.Length-1; i > 0; i--)
                                    {
                                        if (filePath[i] != '.')
                                        {
                                            ext = ext + filePath[i];
                                            filePath = filePath.Remove(i,1);
                                        }
                                        else
                                        {
                                            if (ext != "xelr")
                                            {
                                                ChangeColor("red");
                                                Console.WriteLine("File is not valid. You must add a file with .rlex extension!");
                                                ChangeColor("s");
                                                return false;
                                            }
                                            else
                                            {
                                                filePath = filePath.Remove(i,1);
                                                i = 0;
                                            }
                                        }
                                    }
                                    //Decompress
                                    FileStream original = new FileStream(originalFilePath,FileMode.Open);
                                    BinaryReader lecturaBinaria = new BinaryReader(original);
                                    var bytes = lecturaBinaria.ReadBytes((int)original.Length);
                                    Compress.DeCompressAllBytes(bytes,filePath);
                                    Console.WriteLine("File Decompressed!");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!commands[2].ToLower().Equals("-f"))
                        {
                            ChangeColor("red");
                            Console.WriteLine("Sentence '-f' is missing!");
                            ChangeColor("s");
                            return false;
                        }
                        else
                        {
                            if (!File.Exists(filePath))
                            {
                                ChangeColor("red");
                                Console.WriteLine("The file specified not exists!");
                                ChangeColor("r");
                                return false;
                            }
                            else
                            {
                                //Compress
                                FileStream original = new FileStream(filePath, FileMode.Open);
                                BinaryReader lecturaBinaria = new BinaryReader(original);
                                var bytes = lecturaBinaria.ReadBytes((int)original.Length);
                                Compress.CompressAllBytes(bytes,filePath);
                                long previousLenght = new System.IO.FileInfo(filePath).Length;
                                Console.WriteLine("File Compressed!");
                                long newLenght = new System.IO.FileInfo(filePath+".rlex").Length;
                                Report.PrintReport((double)previousLenght, (double)newLenght);
                            }
                        }
                    }

                    return true;
                }
                else
                {
                    ChangeColor("red");
                    Console.WriteLine("Sentence 'rle.exe' is missing!");
                    ChangeColor("r");
                    return false;
                }
            }
        }
    }
}
