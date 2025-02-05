using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Basics.BinaryTree
{
    public class BinaryTreeOperation
    {
        public TreeNode? CreateBinaryTree(int[] data)
        {
            if (data == null || data.Length == 0) return null;

            TreeNode? root = null;
            foreach (int value in data)
            {
                root = InsertNode(root, value);
            }

            return root;
        }

        private (int,int) CountChildOfTree(TreeNode rootNode)
        {
            int leftChildren = countChildren(rootNode.left);
            int rightChildren = countChildren(rootNode.right);
            return (leftChildren,rightChildren);
        }

        private int countChildren(TreeNode Node) { 
        if (Node == null) return 0;
            int leftChildren = countChildren(Node.left);
            int rightChildren = countChildren(Node.right);
            return 1+leftChildren + rightChildren;
        }

        //private void InsertNode(TreeNode Node,int data) {
        //    TreeNode rootNode = Node;
        // var (leftChildren, rightChildren) = CountChildOfTree(Node);
        //    if(leftChildren <= rightChildren)
        //    {
        //        InsertAtLeft(rootNode, data);
        //    }
        //    else
        //    {
        //        InsertAtRight(rootNode, data);
        //    }
        //}

        private void InsertAtLeft(TreeNode Node, int data) {
            TreeNode treeNode = new TreeNode(data);
            Node.left = treeNode;
        }

        private void InsertAtRight(TreeNode Node, int data) { 
        TreeNode treeNode = new TreeNode(data);
            Node.right = treeNode;
        }

        private int GetHeight(TreeNode? node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
        }


        private TreeNode InsertNode(TreeNode? node, int data)
        {
            if (node == null)
                return new TreeNode(data);

            int leftHeight = GetHeight(node.left);
            int rightHeight = GetHeight(node.right);

            if (leftHeight <= rightHeight)
            {
                node.left = InsertNode(node.left, data);
            }
            else
            {
                node.right = InsertNode(node.right, data);
            }

            return node;
        }

        public void PrintTree(TreeNode? node, int level = 0)
        {
            if (node == null) return;

            PrintTree(node.right, level + 1);
            Console.WriteLine(new string(' ', level * 4) + node.data);
            PrintTree(node.left, level + 1);
        }
    }
}
