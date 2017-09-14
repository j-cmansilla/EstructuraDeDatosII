using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos.Utilities
{
    static class Report
    {
        public static void PrintReport(double previousLenght, double newLenght)
        {
            double compessionRatio = (newLenght / previousLenght);
            double compressionFactor = previousLenght / newLenght;
            double savingPercentage = ((previousLenght - newLenght) / previousLenght) * 100;
            Console.WriteLine();
            Console.WriteLine("# Statistics of generated file");
            Console.WriteLine();
            Console.WriteLine("* Original Size in bytes: "+previousLenght);
            Console.WriteLine("* Final Size in bytes   : "+newLenght);
            Console.WriteLine("* Compression Ratio     : " +Math.Round(compessionRatio,2));
            Console.WriteLine("* Factor Ratio          : " + Math.Round(compressionFactor, 2));
            Console.WriteLine("* Saving Percentage     : " + savingPercentage);
            Console.WriteLine();
        }
    }
}
