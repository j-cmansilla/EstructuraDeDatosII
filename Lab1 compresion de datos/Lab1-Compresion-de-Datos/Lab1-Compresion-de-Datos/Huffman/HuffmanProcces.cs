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
                // char a = Convert.ToChar(t);
                byte a = (byte)t;
                listConverted.Add(a);
            }
            Console.WriteLine(listConverted[0].ToString());
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
            File.WriteAllText(NewFileName, CodesForDecompressFile);
            FileStream fs = new FileStream(NewFileName, FileMode.Append, FileAccess.Write);
            fs.Write(tempByte, 0, tempByte.Count());
            fs.Flush();

            //StringBuilder StringBuilder = new StringBuilder();
            //for (int i = 0; i < tempByte.Count(); i++)
            //{
            //    StringBuilder.Append(Convert.ToChar(tempByte[i]));
            //}
            //File.WriteAllText(NewFileName, StringBuilder.ToString());
           // System.IO.StreamWriter files = new System.IO.StreamWriter(completePath);
          //  files.WriteLine(StringBuilder.ToString()); // "sb" is the StringBuilder;


        }
        #endregion

        #region Compress.2

        #endregion

        public void UndoHuffman(string extension)
        {
            OrinilaExtenssion = extension;
            getLines();
            byte[] bytes = getbytes();
            ConvertFile(bytes);
            CreateF();
            //fill file....
        }

        #region Decompress
        private void CreateF()
        {
            FileInfo file = new FileInfo(OrinilaExtenssion);
            string path = file.Directory.ToString();
            string fileName = Path.GetFileNameWithoutExtension(OrinilaExtenssion);
            string NewFileName = path + "\\" + fileName + OrinilaExtenssion;
            File.WriteAllText(NewFileName, CodesForDecompressFile);
            
        }
        private byte[] getbytes()
        {
            List<byte[]> listConverted = new List<byte[]>();
            for (int i = 0; i < A.Count; i++)
            {
                listConverted.Add(Encoding.ASCII.GetBytes(A[i]))    ;
            }
            byte[] array = listConverted.SelectMany(a => a).ToArray();
            return array;
        }
        private void getLines() //get dictionary of codes
        {
            A = File.ReadLines(OrinilaExtenssion+".comp").ToList(); // document
            List<string> c = (A[0].Split(new string[] { "*" }, StringSplitOptions.None)).ToList();
            OrinilaExtenssion = c[0]; //extencion
            int diclength = int.Parse(c[1]);
            //c.RemoveAt(0);
            //List<string> c1 = (A[1].Split(new string[] { "*" }, StringSplitOptions.None)).ToList();
            //c1.RemoveAt(0);
            //c.AddRange(c1);
            //c.RemoveAt(c.Count - 1);


            BinaryCodes = new Dictionary<string, string>();
            string[] key;
            for (int i = 1; i < diclength; i ++)
            {
                key = (A[i].Split(new string[] { "*" }, StringSplitOptions.None));
                BinaryCodes.Add(key[1], key[0]);
            }
            //A.RemoveAt(0);
            //A.RemoveAt(0);
            A.RemoveRange(0, diclength+1);
        }

        private void ConvertFile(byte[] original)//Dictionary -> <CODE, ASCII>
        {
            A = new List<string>();
            for (int i = 0; i < original.Count(); i++)
            {
                A.Add(Convert.ToString(original[i], 2));
                
            }
            var result = String.Join("", A.ToArray());


        }
        #endregion
    }
}
