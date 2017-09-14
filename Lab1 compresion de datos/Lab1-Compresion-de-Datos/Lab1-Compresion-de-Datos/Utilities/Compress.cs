using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos.Utilities
{
    static class Compress
    {

        public static void CompressAllBytes(byte [] dataToCompress, string filePath)
        {
            List<byte> listaBytes = new List<byte>();
            byte actualByte = 0;
            byte countByte = 0;
            int countB = 0;
            actualByte = dataToCompress[0];
            for (int i = 0; i < dataToCompress.Length; i++)
            {
                if (actualByte == dataToCompress[i])
                {
                    countB++;
                }
                else
                {
                    countByte = (byte)countB;
                    listaBytes.Add(countByte);
                    listaBytes.Add(actualByte);
                    actualByte = dataToCompress[i];
                    if (i+1 == dataToCompress.Length)
                    {
                        listaBytes.Add((byte)(1));
                        listaBytes.Add(actualByte);
                    }
                    countB = 1;
                }
            }
            FileStream file = new FileStream(filePath+".rlex",FileMode.Create,FileAccess.Write);
            file.Write(listaBytes.ToArray(), 0, listaBytes.Count);
            file.Flush();
        }

        public static void DeCompressAllBytes(byte[] dataToDeCompress, string filePath)
        {
            List<byte> listaBytes = new List<byte>();
            string linea = string.Empty;
            int count = (int)dataToDeCompress[0];
            for (int i = 0; i < dataToDeCompress.Length-1; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    listaBytes.Add(dataToDeCompress[i+1]);
                }
                i = i + 1;
                if (i+1 != dataToDeCompress.Length)
                {
                    count = (int)dataToDeCompress[i + 1];
                }
            }
            FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            file.Write(listaBytes.ToArray(), 0, listaBytes.Count);
            file.Flush();
        }

        public static void HuffmanEncoding(string [] data)
        {
            if (data.Length>0)
            {
                string actual = data[0];
                for (int i = 0; i < data.Length; i++)
                {

                }
            }
        }
        
    }
}
