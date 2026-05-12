// StackArray_Generic.cs
// Module 5 - Generic Stack Implementation using Array
// Bobby Rovy | MSSA CAD
// A generic stack that works with any data type T

using System;

public class StackArray<T>
{
    private T[] data;
    private int top;
    private int capacity;

    // Constructor: initialize with a given capacity
    public StackArray(int capacity)
    {
        this.capacity = capacity;
        data = new T[capacity];
        top = -1; // -1 means empty
    }

    // Push: add element to the top
    public void Push(T value)
    {
        if (top == capacity - 1)
            throw new InvalidOperationException("Stack is full!");
        data[++top] = value;
    }

    // Pop: remove and return the top element
    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty!");
        T value = data[top];
        top--;
        return value;
    }

    // Peek: return the top element without removing it
    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty!");
        return data[top];
    }

    // IsEmpty: check if the stack has no elements
    public bool IsEmpty()
    {
        return top == -1;
    }

    // Size: return number of elements
    public int Size()
    {
        return top + 1;
    }

    // Display: print all elements top to bottom
    public void Display()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty!");
        for (int i = top; i >= 0; i--)
            Console.WriteLine(data[i]);
    }
}

// -----------------------------------------------
// Usage Example (can be moved to Program.cs):
// var stack = new StackArray<string>(5);
// stack.Push("Alpha");
// stack.Push("Bravo");
// stack.Push("Charlie");
// Console.WriteLine(stack.Pop()); // Charlie
// Console.WriteLine(stack.Peek()); // Bravo
// stack.Display();
// -----------------------------------------------
