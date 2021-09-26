using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuatToan
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    public class SinglyLinkedList
    {
        public Node head;
       
        public void InsertFront(SinglyLinkedList singlyList, int new_data)
        {
            Node new_node = new Node(new_data);
            new_node.next = singlyList.head;
            singlyList.head = new_node;
        }
        public Node GetLastNode(SinglyLinkedList singlyList)
        {
            Node temp = singlyList.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        public void InsertLast(SinglyLinkedList singlyList, int new_data)
        {
            
            Node new_node = new Node(new_data);
            if (singlyList.head == null)
            {
                singlyList.head = new_node;
                return;
            }
            Node lastNode = GetLastNode(singlyList);
            lastNode.next = new_node;
        }
        public int Count (SinglyLinkedList singlyList)
        {
            int count = 0;
            Node current = singlyList.head;
            Node temp = null;
            while(current != null)
            {
                temp = current.next;
                current = temp;
                count++;
            }
            return count;
        }
        public void BubbleSort(SinglyLinkedList singlyList)
        {
            Node current = null;
            bool Swapped = false;
            do
            {
                current = singlyList.head;
                Swapped = false;
                while (current != null && current.next != null)
                {
                    if (current.data > current.next.data)
                    {
                        Swapped = true;
                        current.data = current.data + current.next.data;
                        current.next.data = current.data - current.next.data;
                        current.data = current.data - current.next.data;
                    }
                    current = current.next;
                }
            } while (Swapped == true);
        }
    }
}
