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
            List<string> listaStrings = new List<string>();
            Console.Write("Type file path>");
            //List<byte[]> txtlines = UF.OpenFile(Console.ReadLine());
            string[] array = UF.OpenFileString(Console.ReadLine());
            for (int i = 0; i < array.Length; i++)
            {
                listaStrings.Add(RleEncoding.Compress(array[i]));
            }
            //Console.WriteLine(txtlines[0].ToString());
            //Console.WriteLine();
            //Console.WriteLine(AT.GetTxt(txtlines[0]));
            Console.ReadKey();

        }
    }
}
