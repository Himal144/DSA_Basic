
using DSA_Basics.DoubleLinkedList;


namespace DSA_Basic {
    public class Program
    {
        public static void Main(string[] args)
        {
            DoubleLinkedList? obj = new DoubleLinkedList();
            Node? head = obj.CreateLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            head = obj.DeleteAtSpecificPosition(head, 4);
            obj.ReverseLinkedList(head);

        }

    }
}





