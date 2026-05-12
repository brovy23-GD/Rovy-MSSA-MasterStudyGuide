// Program_StackDemo.cs
// Module 5 - Stack Demo Program
// Bobby Rovy | MSSA CAD
// Demonstrates integer and generic stack operations

using System;

class Program_StackDemo
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Integer Stack Demo ===");
        StackArray intStack = new StackArray(5);

        intStack.Push(10);
        intStack.Push(20);
        intStack.Push(30);

        Console.WriteLine("Top (Peek): " + intStack.Peek()); // 30
        Console.WriteLine("Popped: " + intStack.Pop());       // 30
        Console.WriteLine("Top after pop: " + intStack.Peek()); // 20

        Console.WriteLine("\nAll remaining elements:");
        intStack.Display();

        Console.WriteLine("\n=== Generic Stack Demo (strings) ===");
        StackArray<string> strStack = new StackArray<string>(5);

        strStack.Push("Alpha");
        strStack.Push("Bravo");
        strStack.Push("Charlie");

        Console.WriteLine("Top (Peek): " + strStack.Peek()); // Charlie
        Console.WriteLine("Popped: " + strStack.Pop());       // Charlie

        Console.WriteLine("\nAll remaining elements:");
        strStack.Display();

        Console.WriteLine("\n=== Missing Number Demo ===");
        // Approach 1: Sum formula  n*(n+1)/2
        int[] nums = { 1, 2, 4, 5, 6 };
        int n = nums.Length + 1; // expected count
        int expectedSum = n * (n + 1) / 2;
        int actualSum = 0;
        foreach (int num in nums) actualSum += num;
        Console.WriteLine("Missing number (Sum): " + (expectedSum - actualSum)); // 3

        // Approach 2: XOR
        int xorResult = 0;
        for (int i = 1; i <= n; i++) xorResult ^= i;
        foreach (int num in nums) xorResult ^= num;
        Console.WriteLine("Missing number (XOR): " + xorResult); // 3
    }
}
