// ============================================================
// MODULE 5 - STACK ARRAY IMPLEMENTATION (Integer Version)
// MSSA CAD Program | Bobby Rovy
// Class: Mod5StackArrayDemo
// ============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Mod5StackArrayDemo
{
    internal class StackArray
    {
        // Array to hold stack elements
        private int[] data;
        // Index of the top element in the stack
        private int top;

        // Constructor: initialize stack with a specific size
        public StackArray(int size)
        {
            data = new int[size];
            top = -1; // -1 means stack is empty
        }

        // Check if stack is empty
        public bool IsEmpty()
        {
            return top == -1;
        }

        // Check if stack is full
        public bool IsFull()
        {
            return top == data.Length - 1;
        }

        // Push: add an element to the top of the stack
        public void Push(int val)
        {
            if (IsFull()) // FIXED: correct method name (was isFull - CS0103 error)
            {
                Console.WriteLine("Stack is full!");
                return;
            }
            top++;
            data[top] = val;
        }

        // Pop: remove and return the top element
        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty!");
            int value = data[top];
            top--;
            return value;
        }

        // Peek: return the top element without removing it
        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty!");
            return data[top];
        }

        // Display: print all elements top to bottom
        public void Display()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty!");
            for (int i = top; i >= 0; i--) // loop from top down to 0
                Console.WriteLine(data[i]);
        }
    }
}
