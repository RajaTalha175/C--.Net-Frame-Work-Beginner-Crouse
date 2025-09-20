using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Intermidiate_Crouse
{
//    SingleNode newSingleNode = new SingleNode();
//            for (int b = 0; b <= 5; b++)
//            {
//                newSingleNode.insertSingle(b);
//            }
//newSingleNode.DisplaySingle();
//Console.WriteLine($"SingleList");

//DoubleNode newDubleNode = new DoubleNode();
//for (int b = 0; b <= 5; b++)
//{
//    newDubleNode.insertDouble(b);
//}
//newDubleNode.DisplayDouble();
//Console.WriteLine($"DoubleList");

public class Node
{
    public int data;
    public Node next;
        public Node previous;

    public Node(int data)
    {
        this.data = data;
        this.next = null;
            this.previous = null;

    }
}
public class DoubleNode
{
    Node head;
    public void insertDouble(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            var temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
                
            }
                temp.next = newNode;
                newNode.previous = temp;
        }
    }
    public void DisplayDouble()
    {
        Node temp = head;
        while (temp != null)
        {
                Console.Write(temp.data + " <-> ");
                temp = temp.next;
        }
        Console.WriteLine("null");
    }

}
    public class SingleNode
    {
        Node head;
        public void insertSingle(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;

                }
                temp.next = newNode;
            }
        }
        public void DisplaySingle()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " → ");
                temp = temp.next;
            }
            Console.WriteLine("null");
        }

    }
}