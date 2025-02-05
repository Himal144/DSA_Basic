using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA_Basics.BinaryTree;

namespace DSA_Basics.BinaryTree
{
    class Test
    {
        public static void Run()
        {
            var obj = new BinaryTreeOperation();
            TreeNode? root = obj.CreateBinaryTree(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            obj.PrintTree(root);
        }
    }
}
