using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Basics.SingleLinkedList
{
    public class SingleLinkedList
    {
        private Node ? start;
        public SingleLinkedList() {
         start = null;
        }
        public Node? CreateLinkedList(int[] data)
        {
            if(data == null || data.Length == 0)
            {
                return null;
            }
            Node head = new Node(data[0]);
            Node current = head;
            for(int i =1; i < data.Length; i++)
            {
                current.link = new Node(data[i]);
                current = current.link;
            }
            return head;
        }

        public void ReadAllNode(Node head)
        {
            Node ? current = head;
            while(current != null){
                Console.WriteLine(current.info);
                current = current.link;
            }
            return;
        }

        public Node? InsertionAtEnd(Node head,int data)
        {
            Node ? current = head;
            while(current.link != null)
            {
                current = current.link;
            }
            Node lastNode = new Node(data);
            current.link = lastNode;
            return head;
        }
        public Node? InsertionAtBegin(Node head, int data) { 
         Node? firstNode = new Node(data);
            firstNode.link = head;
            return firstNode;
        }

        public Node? InsertionAtSpecificPosition(Node head, int data,int position) {
         Node specificNode = new Node(data);
            int i = 1;
            Node? current = head;
            while(i < position-1)
            {
                current = current.link;
                i++;
            }
            specificNode.link = current.link;
            current.link = specificNode;
            return head;
        }
        public Node? DeletionAtSpecificPosition(Node head, int position) {
            Node current = head;
            Node? previousNode = head;
            int i = 1;
            while(i < position)
            {
                previousNode = current;
                current = current.link;
                i++;
            }
            previousNode.link = current.link;
            return head;
        }

        public void CountAllNode(Node head)
        {
            Node? current = head;
            int count = 1;
            while(current.link != null)
            {
                current= current.link;
                count++;
            }
            Console.WriteLine("Number of element is the linked are {0}", count.ToString());
        }

        public void FindNode(Node head,int element) { 
         Node? current = head;
            while(current.link != null)
            {
                if(current.info == element)
                {
                    Console.WriteLine("Element found in linked list at position: {0}", element.ToString());
                    return;
                }
                current= current.link;

            }
            Console.WriteLine("{0} element is not present in linked list.",element.ToString());
        
        }

        //Leetcode easy
        public Node? MergeTwoSortedLinkedList(Node list1,Node list2)
        {
            if (list1 == null) return null;
            if (list2 == null) return null;
            var dummyNode = new Node(0);
            Node current = dummyNode;

            while(list1 != null && list2 != null)
            {
                if (list1.info <= list2.info)
                {
                    current.link = list1;
                    list1 = list1.link;
                }
                else
                {
                    current.link = list2;
                    list2 = list2.link;
                }
                current = current.link;
            }
            current.link = (list1 != null) ? list1 : list2;
            return dummyNode.link;
        }

        public Node? RemoveDuplicateNode(Node head)
        {
            if (head == null) return null;

            Node current = head;

            while (current != null && current.link != null)
            {
                if (current.info == current.link.info)
                {
                    current.link = current.link.link; // Skip duplicate
                }
                else
                {
                    current = current.link; // Move forward
                }
            }
            return head;
        }

        //Add two linked list node which are represented in reverse order
        public Node? AddTwoNumberInLinkedList(Node head1, Node head2)
        {
            Node? current1 = head1; 
            Node? current2 = head2;
            Node? dummyNode = new Node(0);
            Node current = dummyNode;
            int carry = 0;
            while (current1 != null || current2!= null || carry>0)
            {
                int num1 = 0;
                int num2 = 0;
                int reminder = 0;
               if(current1 != null)
                {
                    num1=current1.info;
                    current1 = current1.link;
                }
                if (current2 != null) { 
                num2 = current2.info;
                current2 = current2.link;   
                }
                int sum = num1+num2+carry;

                reminder = sum % 10;
                carry = sum / 10;

                Node? node = new Node(reminder);
                current.link = node;
                current = current.link;
            }
            return dummyNode.link;
        }

        public bool CycleExist(Node head) 
        {
            Node slowPtr = head, fastPtr = head;

            while (fastPtr != null && fastPtr.link != null) // FIXED CONDITION
            {
                slowPtr = slowPtr.link;
                fastPtr = fastPtr.link.link;

                if (slowPtr == fastPtr) // Cycle detected
                    return true;
            }

            return false; // No cycle
        }



    }
}
