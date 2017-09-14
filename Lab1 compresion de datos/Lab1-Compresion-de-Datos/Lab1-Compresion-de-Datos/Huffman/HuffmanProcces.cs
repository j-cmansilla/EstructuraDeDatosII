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
        public List<HuffmanNode> MainList;

        public List<HuffmanNode> getMainList(FileStream FS) //Create the mainlist of characters
        {
            for (int i = 0; i < FS.Length; i++)
            {
                MainList = new List<HuffmanNode>();
                string r = Convert.ToChar( FS.ReadByte()).ToString();
                if (MainList.Exists(x => x.Character == r)) // check if element is already in list 
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
            return MainList;
        }

        public void CreateTree()//The list is in order, theres no need to search.
        {
            int listCount = MainList.Count;
            for (int i = 0; i < listCount-1; i++)
            {
                HuffmanNode NodeA = MainList.First();
                MainList.RemoveAt(0);
                HuffmanNode NodeB = MainList.First();
                MainList.RemoveAt(0);
                HuffmanNode NewNode = new HuffmanNode(); //create new node from
                NewNode.CreateNode(NodeA, NodeB);
                MainList.Add(NewNode);
                MainList.Sort();
                listCount = MainList.Count();
            }
        }
        public void getBinaryCodes(HuffmanNode root, int LR)
        {
            if (root != null)
            {
                root.binaryCode += LR;
                getBinaryCodes(root.leftNode, 0);
                getBinaryCodes(root.righNode, 1);
            }
        }

    }
}
