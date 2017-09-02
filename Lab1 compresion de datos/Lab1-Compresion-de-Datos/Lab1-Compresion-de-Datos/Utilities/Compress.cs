using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos.Utilities
{
    static class Compress
    {
        public static string[] CompressAllLines(string [] array)
        {
            string[] outPut = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                outPut[i] = RleEncoding.Compress(array[i]);
            }
            return outPut;
        }
    }
}
