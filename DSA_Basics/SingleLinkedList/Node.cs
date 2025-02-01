using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Basics.SingleLinkedList
{ 
    public class Node
    {
        public Node? link;
        public int info;
        public Node(int info) { 
          this.info = info;
          link = null;
        }
    }
}
