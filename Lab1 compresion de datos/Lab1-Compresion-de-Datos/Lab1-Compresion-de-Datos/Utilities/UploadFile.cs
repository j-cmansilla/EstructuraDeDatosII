using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos.Utilities
{
    class UploadFile
    {
        public string[] OpenFileString(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                return File.ReadAllLines(FilePath);
            }
            else
            {
                return null;
            }
        }
        public List<byte[]> OpenFile(string FilePath)
        {
            //string something = Encoding.ASCII.GetString(toBytes); byte to string
            if (File.Exists(FilePath))
            {
                List<byte[]> insta = new List<byte[]>();
                string [] filetxt = File.ReadAllLines(FilePath);
                for (int i = 0; i<filetxt.Length ; i++)
                {
                    byte[] bytesarrr = Encoding.ASCII.GetBytes(filetxt[i]);
                    insta.Add(bytesarrr);
                }
                return insta;
            }
            else
            {
                return null;
            }
        }
    }
}
