using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Basics.BinaryTree
{
    public class TreeNode
    {
        public int data;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }
}
