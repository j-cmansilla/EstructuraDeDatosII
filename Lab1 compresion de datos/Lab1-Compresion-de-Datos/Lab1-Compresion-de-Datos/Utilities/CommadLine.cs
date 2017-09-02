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
        static UploadFile UF = new UploadFile();
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
                            if (!commands[3].ToLower().Equals("-f"))
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
                                        //Decompress
                                        string[] array = Compress.CompressAllLines(UF.OpenFileString(commands[4]));
                                        File.WriteAllLines(filePath + ".rlex", array);
                                        Console.WriteLine("File Compressed!");
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
                                string[] array = Compress.CompressAllLines(UF.OpenFileString(filePath));
                                File.WriteAllLines(filePath+".rlex",array);
                                Console.WriteLine("File Compressed!");
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
