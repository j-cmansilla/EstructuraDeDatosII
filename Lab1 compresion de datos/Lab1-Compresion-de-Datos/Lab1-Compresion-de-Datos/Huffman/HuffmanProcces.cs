using System;
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

        public void DoHuffman(byte[] bytes, string extension)
        {
            getMainList(bytes);
            CreateTree();
            getBinaryCodes(MainList.First(), null);
            ConvertHuffman(bytes);
            EssentialInformation(Path.GetExtension(extension)); //get extension
            CreateNewFile(CodesForDecompressFile, extension);
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
               string character =  Convert.ToChar(original[i]).ToString();
                A.Add(BinaryCodes[character]);
            }
        } 

        private void EssentialInformation(string ex) 
        {
            CodesForDecompressFile = ex + "//";
            for (int i = 0; i < BinaryCodes.Count; i++)
            {
                CodesForDecompressFile += BinaryCodes.ElementAt(i).Key + "//" + BinaryCodes.ElementAt(i).Value + "//";
            }
        }

        private void CreateNewFile(string firstline, string completePath) //Create new file, set the first line with the Dictionary codes and original extension
        {
            FileInfo file = new FileInfo(completePath);
            string path = file.Directory.ToString();
            string fileName = Path.GetFileNameWithoutExtension(completePath);
            string NewFileName = path + "\\" + fileName + "1.comp";
            File.WriteAllText(NewFileName, CodesForDecompressFile);
        }
    }
}
