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
            Dictionary<string,int> Characters = new Dictionary<string, int>();
            UploadFile UF = new UploadFile();
            AnalyzeTxt AT = new AnalyzeTxt();
            Console.WriteLine("Type file path");
            string pathFile = Console.ReadLine();
            List<byte[]> txtlines = UF.OpenFile(pathFile);
            Console.WriteLine(txtlines[0]);
            Console.WriteLine();
            Console.WriteLine(AT.GetTxt(txtlines[0]));
            Console.WriteLine();
            Console.WriteLine(AT.DesTxt(AT.GetTxt(txtlines[0])));
            Console.ReadKey();

        }
    }
}
