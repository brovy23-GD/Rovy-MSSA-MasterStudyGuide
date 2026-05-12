// Program_LinkedListDemo.cs
// Module 4 / Module 5 - Linked List Demo
// Bobby Rovy | MSSA CAD
// Demonstrates singly linked list operations in C#

using System;

// Node class: each node holds a value and a reference to the next node
public class Node
{
    public int Value;
    public Node Next;

    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}

// LinkedList class: manages a chain of nodes
public class LinkedList
{
    private Node head;

    // AddFirst: insert at the front of the list - O(1)
    public void AddFirst(int value)
    {
        Node newNode = new Node(value);
        newNode.Next = head;
        head = newNode;
    }

    // AddLast: insert at the end of the list - O(n)
    public void AddLast(int value)
    {
        Node newNode = new Node(value);
        if (head == null)
        {
            head = newNode;
            return;
        }
        Node current = head;
        while (current.Next != null)
            current = current.Next;
        current.Next = newNode;
    }

    // Remove: delete a node by value - O(n)
    public void Remove(int value)
    {
        if (head == null) return;
        if (head.Value == value)
        {
            head = head.Next;
            return;
        }
        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Value == value)
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    // Search: find a node by value - O(n)
    public bool Search(int value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Value == value) return true;
            current = current.Next;
        }
        return false;
    }

    // Display: print all node values - O(n)
    public void Display()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Value + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

class Program_LinkedListDemo
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Linked List Demo ===");
        LinkedList list = new LinkedList();

        list.AddLast(10);
        list.AddLast(20);
        list.AddLast(30);
        list.AddFirst(5);

        Console.Write("List: ");
        list.Display(); // 5 -> 10 -> 20 -> 30 -> null

        Console.WriteLine("Search 20: " + list.Search(20)); // True
        Console.WriteLine("Search 99: " + list.Search(99)); // False

        list.Remove(20);
        Console.Write("After removing 20: ");
        list.Display(); // 5 -> 10 -> 30 -> null
    }
}
