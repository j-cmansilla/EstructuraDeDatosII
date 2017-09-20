﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos.Utilities
{
    static class Compress
    {

        private static List<byte> RLECompression(byte[] dataToCompress)
        {
            List<byte> listaBytes = new List<byte>();
            listaBytes.Add((byte)'R');
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
                    if (i + 1 == dataToCompress.Length)
                    {
                        listaBytes.Add((byte)(1));
                        listaBytes.Add(actualByte);
                    }
                    countB = 1;
                }
            }
            return listaBytes;
        }

        public static void CompressAllBytes(byte [] dataToCompress, string filePath)
        {
            List<byte> listaBytes = RLECompression(dataToCompress);
            FileStream file = new FileStream(filePath+CommadLine.COMPRESSION_EXTENSION,FileMode.Create,FileAccess.Write);
            file.Write(listaBytes.ToArray(), 0, listaBytes.Count);
            file.Flush();
        }

        public static bool DeCompressAllBytes(byte[] dataToDeCompress, string filePath)
        {
            List<byte> listaBytes = new List<byte>();
            string linea = string.Empty;
            if (dataToDeCompress[0].Equals('R'))
            {
                int count = (int)dataToDeCompress[1];
                for (int i = 1; i < dataToDeCompress.Length - 1; i++)
                {
                    for (int j = 1; j < count; j++)
                    {
                        listaBytes.Add(dataToDeCompress[i + 1]);
                    }
                    i = i + 1;
                    if (i + 1 != dataToDeCompress.Length)
                    {
                        count = (int)dataToDeCompress[i + 1];
                    }
                }
                FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                file.Write(listaBytes.ToArray(), 0, listaBytes.Count);
                file.Flush();
                return true;
            }
            return false;
        }
    }
}
