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

            for (int i = 0; i < CharactersTxt.Length + 1; i++)
            {
                if (i < CharactersTxt.Length)
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
                else
                {
                    strResult.Add(((char)(CountA)).ToString() + characterA);
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
            for (int i = 0; i < dsf.Length + 1; i++)
            {
                if (i < dsf.Length)
                {
                    if (Char.IsDigit(dsf[i])) //if number
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
                else
                {
                    result.Add(a[0] + a[1]);
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
                a[0] = characters[i].Substring(0, 1);
                a[1] = characters[i].Substring(1);
                int b = int.Parse(getNumber(char.Parse(a[0])).ToString());
                for (int j = 0; j < b ; j++)
                {
                    strResult.Add( ((char)(int.Parse(a[1]))).ToString());
                }
            }
            return string.Join("", strResult);

        }

    }
}
