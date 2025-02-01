using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Basics.DoubleLinkedList
{
    public class DoubleLinkedList
    {
        public Node? CreateLinkedList(int[] data)
        {
            Node? firstElement = new Node(data[0]);
            Node? head = firstElement;
            Node? current = firstElement;
            for(int i =1; i < data.Length; i++)
            {
                Node? nextElement = new Node(data[i]);
                current.next=nextElement;
                nextElement.previous = current;
                current = nextElement;
            }
            return head;
        }

        public void ReadAllNode(Node head)
        {
            Node? current = head;
            while (current != null) { 
             Console.WriteLine(current.info.ToString());
                current = current.next;
            }  
        }

        public void ReverseLinkedList(Node? head)
        {
            Node? current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            while (current != null)
            {
                Console.WriteLine(current.info.ToString());
                current = current.previous;
            }
        }
        public Node? InsertAtBegin(Node head, int data)
        {
            Node? firstElement = new Node(data);
            firstElement.next = head;
            return firstElement;

        }
        public Node? InsertAtEnd(Node head,int data)
        {
            Node? current = head;
            while(current.next != null)
            {
                current = current.next;
            }
            Node? lastElement = new Node(data);
                current.next = lastElement;
            lastElement.previous = current;
            return head;
        }
        public Node? InsertAtSpecificPosition(Node? head, int position,int data)
        {
            Node? current = head;
            int currentPosition = 1;
            while (currentPosition < position) {
                current = current.next;
                currentPosition++;
            }
            Node? specificNode = new Node(data);
            current.previous.next = specificNode;
            specificNode.previous = current.previous;
            specificNode.next = current;
            current.previous = specificNode;
            return head;
        }

        public Node? DeleteAtSpecificPosition(Node? head, int position) {
         Node? current = head;
            int currentPosition = 1;
            while (currentPosition < position) {
                current = current.next;
                currentPosition++;
            }
            current.previous.next = current.next;
            current.next.previous = current.previous;
            return head;
        }
    }
}
