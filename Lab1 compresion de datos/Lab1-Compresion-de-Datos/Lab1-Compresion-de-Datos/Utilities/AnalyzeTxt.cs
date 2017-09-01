using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos.Utilities
{
    class AnalyzeTxt
    {
        public string GetTxt(byte[] CharactersTxt)
        {
           // byte[] CharactersTxt = txtline.ToCharArray();
            byte characterA = CharactersTxt[0];
            List<string> strResult = new List<string>();
            int CountA = 0;

            for (int i = 0; i < CharactersTxt.Length; i++)
            {
                if (characterA == CharactersTxt[i])
                {
                    CountA++;
                }
                else
                {
                    strResult.Add(CountA.ToString() + characterA);
                    characterA = CharactersTxt[i];
                    CountA = 1;
                }
            }
            
            return string.Join("", strResult);
        }
    }
}
