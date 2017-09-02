using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos.Utilities
{
    class AnalyzeTxt
    {
        public string GetTxt(byte[] CharactersTxt) //Comprimir
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
                    strResult.Add(((char)(CountA)).ToString() + characterA);
                    characterA = CharactersTxt[i];
                    CountA = 1;
                }
            }
            return string.Join("", strResult);
        }

        public char getcharacter(int count)//int->ascii
        {
            return Convert.ToChar(count);
        }
        public int getNumber(char character)//ascii->int
        {
            return (int)character;
        }
        public List<string> splitsting(string line)
        {
            char[] dsf  = line.ToCharArray();

            string[] a = new string[2];
            List<string> result = new List<string>();
            for (int i = 0; i < dsf.Length; i++)
            {
               //a12b56c2
               if(Char.IsDigit(dsf[i])) //if number
                {

                    a[1] += dsf[i];
                }
               else 
                {
                    result.Add(a[0] + a[1]);
                    a[0] = dsf[i].ToString();
                    a[1] = "";
                }
            }

            return result;
        }


        public string DesTxt(string line)
        {
            List<string> strResult = new List<string>();
            List<string> characters = splitsting(line);
            string[] a = new string[2];
            for (int i = 1; i < characters.Count; i++)
            {
                a[0] = characters[i].Substring(1, 1);
                a[1] = characters[i].Substring(2);
                int b = int.Parse((Encoding.ASCII.GetBytes(a[0])).ToString());
                for (int j = 0; j < b ; j++)
                {
                    strResult[i] += (char)(int.Parse(a[1]));
                }
            }
            return string.Join("", strResult);

        }

    }
}
