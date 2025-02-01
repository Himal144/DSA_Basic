using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Basics.DoubleLinkedList
{
    public class Node
    {
        public Node? previous;
        public Node? next;
        public int info;
        public Node(int info) { 
          this.info = info;
          previous = null;
          next = null;
        }
    }
}
