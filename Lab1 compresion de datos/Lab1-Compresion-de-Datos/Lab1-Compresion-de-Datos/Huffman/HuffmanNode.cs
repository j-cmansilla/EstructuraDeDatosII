using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Compresion_de_Datos.Huffman
{
    class HuffmanNode : IComparable<HuffmanNode>
    {
        public string Character; //Symbol 
        public double Count; //number of times its in the file
        public HuffmanNode parentNode = null; // Parent node
        public HuffmanNode leftNode = null;
        public HuffmanNode righNode = null;
        public string binaryCode;
        public bool leaf;

        public int CompareTo(HuffmanNode otherNode)
        {
            return Count.CompareTo(otherNode.Count);
        }

        public void ChangeCount()
        {
            Count++;
        }

        public void CreateNode(HuffmanNode NodeA, HuffmanNode NodeB)
        {
            Character = NodeA.Character + NodeB.Character;
            Count = NodeA.Count + NodeB.Count;
            NodeA.parentNode = this;
            NodeB.parentNode = this;
            leftNode = NodeA;
            righNode = NodeB;
            leaf = false;
        }
    }
}
