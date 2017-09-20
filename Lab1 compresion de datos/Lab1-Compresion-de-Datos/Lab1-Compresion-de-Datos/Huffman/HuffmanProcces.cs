﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos.Huffman
{
    class HuffmanProcces
    {
        private List<HuffmanNode> MainList = new List<HuffmanNode>(); //Tree main list
        private Dictionary<string, string> BinaryCodes = new Dictionary<string, string>();
        public List<string> A = new List<string>(); //new file 
        public string CodesForDecompressFile; //Codes and extension for decompress
        string OrinilaExtenssion; //path 

        public void DoHuffman(byte[] bytes, string extension)
        {
            getMainList(bytes);
            CreateTree();
            getBinaryCodes(MainList.First(), null);
            ConvertHuffman(bytes); //checked
            EssentialInformation(Path.GetFileName(extension)); //get extension
            group(); 
            byte[] tempBytes = ConvertToBytes(); //checked
            CreateNewFile(extension, tempBytes);
        }


        #region Compress

        private void group()
        {
            List<string> B = new List<string>();
            string temp = string.Join("", A);
            for (int i = 0; i < temp.Length; i += 8)
            {
                try
                {
                    B.Add(temp.Substring(i, 8));
                }
                catch //fix this... ****
                {
                    B.Add(temp.Substring(i, temp.Length - i));
                }
            }
            A = B;
        }


        private byte[] ConvertToBytes()
        {
            List<byte> listConverted = new List<byte>();
            for (int i = 0; i < A.Count; i++)
            {
                int t = Convert.ToByte(A.ElementAt(i), 2);
                byte a = (byte)t;
                listConverted.Add(a);
            }
            return listConverted.ToArray();
        }

        private void getMainList(byte[] FS) //Create the mainlist of characters
        {
            for (int i = 0; i < FS.Length; i++)
            {
                string r = Convert.ToChar(FS[i]).ToString();
                if (MainList.Any(x => x.Character == r)) // check if element is already in list 
                {
                    MainList[MainList.FindIndex(a => a.Character == r)].ChangeCount(); //increase count
                }
                else
                {
                    HuffmanNode newNode = new HuffmanNode() { Character = r, Count = 1, leaf = true }; //create a new node
                    MainList.Add(newNode);
                }

            }
            MainList.Sort();
        }

        private void CreateTree()//The list is in order, theres no need to search.
        {
            int i = 0;
            for (i = 0; i < MainList.Count; i++)
            {
                HuffmanNode NodeA = MainList.First();
                MainList.RemoveAt(0);
                HuffmanNode NodeB = MainList.First();
                MainList.RemoveAt(0);
                HuffmanNode NewNode = new HuffmanNode(); //create new node 
                NewNode.CreateNode(NodeA, NodeB);
                MainList.Add(NewNode);
                MainList.Sort();
                i = 0;
            }
        }

        private void getBinaryCodes(HuffmanNode root, string LR) //Go throw tree setting codes
        {
            if (root != null)
            {
                root.binaryCode += LR;
                if (root.leaf)
                {
                    BinaryCodes.Add(root.Character, root.binaryCode);
                }
                getBinaryCodes(root.leftNode, LR + "0");
                getBinaryCodes(root.righNode, LR + "1");
            }
        }

        private void ConvertHuffman(byte[] original) //Translate to Binary huffman codes
        {
            for (int i = 0; i < original.Count(); i++)
            {
                string character = Convert.ToChar(original[i]).ToString();
                A.Add(BinaryCodes[character]); //Dictionary -> <ASCII, CODE>
            }
        }

        private void EssentialInformation(string ex)
        {
            CodesForDecompressFile = ex + "*" + BinaryCodes.Count + System.Environment.NewLine;
            for (int i = 0; i < BinaryCodes.Count; i++)
            {
                if (BinaryCodes.ElementAt(i).Key == "\n")
                {
                    i++;
                }
                CodesForDecompressFile += BinaryCodes.ElementAt(i).Key + "*" + BinaryCodes.ElementAt(i).Value + System.Environment.NewLine;
            }
            CodesForDecompressFile += System.Environment.NewLine;
        }

        private void CreateNewFile(string completePath, byte[] tempByte) //Create new file, set the first line with the Dictionary codes and original extension
        {
            FileInfo file = new FileInfo(completePath);
            string path = file.Directory.ToString();
            string fileName = Path.GetFileNameWithoutExtension(completePath);
            string NewFileName = path + "\\" + fileName + ".comp";
            File.WriteAllText(NewFileName + "D", CodesForDecompressFile);
            FileStream fs = new FileStream(NewFileName, FileMode.Create, FileAccess.Write);
            fs.Write(tempByte, 0, tempByte.Count());
            fs.Flush();
        }
        #endregion

        #region Compress.2

        #endregion

        public void UndoHuffman(string extension)
        {
            OrinilaExtenssion = extension;
            getLines(extension); //checked
            byte[] bytes = getbytes(extension); //checked
            ConvertFile(bytes);
            CreateF(extension);
        }

        #region Decompress
        private void CreateF(string pathorg)
        {
            FileInfo file = new FileInfo(pathorg);
            string path = file.Directory.ToString();
           // string fileName = Path.GetTempPath(file);
            string NewFileName = path + "\\" + OrinilaExtenssion +"fdgsd" ;
            File.WriteAllText(NewFileName, String.Join("", A.ToArray()));
            
        }
        private byte[] getbytes(string path)
        {     
            FileStream original = new FileStream(path + ".comp", FileMode.Open);
            BinaryReader lecturaBinaria = new BinaryReader(original);
            var bytes = lecturaBinaria.ReadBytes((int)original.Length);
            //File.Delete(path);
            return bytes;
        }
        private void getLines(string path) //get dictionary of codes
        {
            A = File.ReadLines(OrinilaExtenssion+".compD").ToList(); // document
            List<string> c = (A[0].Split(new string[] { "*" }, StringSplitOptions.None)).ToList();
            OrinilaExtenssion = c[0]; //extencion
            int diclength = int.Parse(c[1]);
            BinaryCodes = new Dictionary<string, string>();
            string[] key;
            for (int i = 1; i < diclength; i ++)
            {
                key = (A[i].Split(new string[] { "*" }, StringSplitOptions.None));
                BinaryCodes.Add(key[1], key[0]);
            }

            A.RemoveRange(0, diclength+1);


            #region Sol V
            //File.WriteAllLines(path, A);
            #endregion
        }

        private void ConvertFile(byte[] original)//Dictionary -> <CODE, ASCII>
        {
            A = new List<string>();
            for (int i = 0; i < original.Count(); i++)
            {
                A.Add(Convert.ToString(original[i], 2).PadLeft(8, '0'));
            }
            var result = String.Join("", A.ToArray());
            
            A = new List<string>();
            string code = string.Empty;
            for (int i = 0; i < result.Length; i++)
            {
                code = code + result[i].ToString();
                for (int k = 0; k < BinaryCodes.Count; k++)
                {
                    if (code.Equals(BinaryCodes.Keys.ElementAt(k)))
                    {
                        A.Add(BinaryCodes.Values.ElementAt(k));
                        code = string.Empty;
                    }
                }
            }
        }
        #endregion
    }
}
