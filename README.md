# Bobby Rovy — MSSA CAD Master Study Guide

**Program:** Microsoft Software & Systems Academy (MSSA) | CAD Cohort  
**Author:** Bobby Rovy | U.S. Army Veteran  
**Updated:** After every class session  

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=flat&logo=visualstudio&logoColor=white)

---

## Table of Contents
1. [Big O Notation Cheat Sheet](#big-o-notation-cheat-sheet)
2. [Module 4 — Linked Lists](#module-4--linked-lists)
3. [Module 5 — Stacks](#module-5--stacks)
4. [Module 5 — Missing Number (4 Approaches)](#module-5--missing-number-4-approaches)
5. [XOR Bit Manipulation](#xor-bit-manipulation)
6. [Common C# Errors & Fixes](#common-c-errors--fixes)
7. [Code Files Index](#code-files-index)

---

## Big O Notation Cheat Sheet

| Notation | Name | Example |
|---|---|---|
| O(1) | Constant | Array access by index |
| O(log n) | Logarithmic | Binary search |
| O(n) | Linear | Loop through array |
| O(n log n) | Log-linear | Array.Sort(), Merge Sort |
| O(n²) | Quadratic | Nested loops |
| O(2ⁿ) | Exponential | Recursive Fibonacci |

**Rule:** Always aim for the lowest Big O possible. O(1) is best, O(n²) is a red flag in interviews.

---

## Module 4 — Linked Lists

### Why Linked Lists? (Dynamic Memory — NOT continuous like arrays)

| Application | Why Linked List? |
|---|---|
| Tree Data Structure | Nodes point to children dynamically |
| Stack & Queue | Push/Pop from head in O(1) |
| Image Viewer | Doubly Linked List — go forward & back |
| Music Playlist | Next/Previous song navigation |
| GPS Navigation | Step-by-step destination routing |
| Graphs | Adjacency list representation |

### Types of Linked Lists

**Singly Linked List**
- Unidirectional — traverses head to tail only
- Each node has: `Data` + `Next pointer`
- Head != NULL check before traversal

**Doubly Linked List**
- Each node has: `Prev pointer` + `Data` + `Next pointer`
- Can traverse both directions
- Used for: image viewers, browser history

**Circular Linked List**
- Last node points BACK to first node
- No NULL assignment on any node
- Used for: round-robin scheduling, music loops

### Linked List Time & Space Complexity

| Operation | Singly | Doubly | Circular |
|---|---|---|---|
| Insert | O(1) | O(1) | O(1) |
| Delete | O(1) | O(1) | O(1) |
| Access | O(n) | O(n) | O(n) |
| Search | O(n) | O(n) | O(n) |

### Singly Linked List Logic
```
STEP 1: Create new node with Data + Next pointer
STEP 2: If list empty -> new node = head
         If list not empty -> traverse to end, attach
STEP 3: Display using loop until current node = null
```

### Advantages vs Disadvantages

| Advantages | Disadvantages |
|---|---|
| Dynamic memory allocation | Requires extra memory for pointer |
| Easy insertion & deletion | More complex than arrays |
| Reduced wasted memory | Cannot access elements directly |
| Easy traversal | |

### Key Operations
```csharp
// Add node at end
public void AddLast(int data)
{
    Node newNode = new Node(data);
    if (Head == null) { Head = newNode; return; }
    Node current = Head;
    while (current.Next != null) current = current.Next;
    current.Next = newNode;
}

// Remove first node
public void RemoveFirst()
{
    if (Head == null) return;
    Head = Head.Next;
}
```

---

## Module 5 — Stacks

### Basic Concepts
- **LIFO** — Last In, First Out
- Ordered list; elements added & removed from the **top**
- Linear data structure
- Real examples: plates, books, piles of coins, browser back button

### Stack Operations
| Operation | Description | Complexity |
|---|---|---|
| Push | Add element to top | O(1) |
| Pop | Remove & return top element | O(1) |
| Peek | View top element without removing | O(1) |
| IsEmpty | Check if stack has no elements | O(1) |
| IsFull | Check if stack is at capacity | O(1) |
| Display | Print all elements top to bottom | O(n) |

### Push Operation Rules
- `TOP = -1` when stack is empty
- `TOP + 1` on every Push
- **Stack Overflow** = pushing to a full stack (when `TOP == size - 1`)

### Stack Array Implementation (C#)
```csharp
public class StackArray
{
    private int[] data;
    private int top;

    public StackArray(int size) { data = new int[size]; top = -1; }

    public bool IsEmpty() => top == -1;
    public bool IsFull() => top == data.Length - 1;

    public void Push(int val)
    {
        if (IsFull()) { Console.WriteLine("Stack is full!"); return; }
        data[++top] = val;
    }

    public int Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty!");
        return data[top--];
    }

    public int Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty!");
        return data[top];
    }

    public void Display()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty!");
        for (int i = top; i >= 0; i--)
            Console.WriteLine(data[i]);
    }
}
```

### Generic Stack (Works with Any Type T)
```csharp
public class StackArray<T>
{
    private T[] data;
    private int top;

    public StackArray(int size = 50) { data = new T[size]; top = -1; }

    public bool IsEmpty() => top == -1;
    public bool IsFull() => top == data.Length - 1;

    public void Push(T val)
    {
        if (IsFull()) { Console.WriteLine("Stack is full!"); return; }
        data[++top] = val;
    }

    public T Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty!");
        return data[top--];
    }

    public T Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("Stack is empty!");
        return data[top];
    }
}
```

### Using Built-in Stack<T> in C#
```csharp
Stack<string> operations = new Stack<string>();
operations.Push("color change");
operations.Push("font change");
operations.Push("text bold");

foreach (var op in operations) Console.WriteLine(op);
Console.WriteLine("Popped: " + operations.Pop());
operations.Peek(); // view top without removing
```

---

## Module 5 — Missing Number (4 Approaches)

**Problem:** Given an array `[0..n]` with one number missing, find it.

### Approach Comparison

| # | Approach | Time | Space | Key Idea |
|---|---|---|---|---|
| 1 | Array.Sort | O(n log n) | O(1) | Sort, then check where `nums[i] != i` |
| 2 | HashSet | O(n) | O(n) | Store all nums, loop 0→n, return missing |
| 3 | Math (Gauss) | O(n) | O(1) | `expectedSum = n*(n+1)/2` minus actualSum |
| 4 | XOR (Bit) | O(n) | O(1) | XOR all indices AND all values — pairs cancel |

### Approach 1: Array.Sort
```csharp
Array.Sort(nums);
for (int i = 0; i < nums.Length; i++)
    if (nums[i] != i) return i;
return nums.Length;
// Time: O(n log n) | Space: O(1)
```

### Approach 2: HashSet
```csharp
HashSet<int> set = new HashSet<int>(nums);
for (int i = 0; i <= nums.Length; i++)
    if (!set.Contains(i)) return i;
return -1;
// Time: O(n) | Space: O(n)
```

### Approach 3: Math (Gauss Formula)
```csharp
int expectedSum = nums.Length * (nums.Length + 1) / 2;
int actualSum = 0;
foreach (int n in nums) actualSum += n;
return expectedSum - actualSum;
// Time: O(n) | Space: O(1)
```

### Approach 4: XOR (Best for Interviews)
```csharp
public static int MissingNumber(int[] nums)
{
    int missing = nums.Length; // start with n
    for (int i = 0; i < nums.Length; i++)
        missing = missing ^ i ^ nums[i]; // XOR index AND value
    return missing; // unpaired number = missing
}
// Time: O(n) | Space: O(1)
```

**Why it works:** Every index 0→n XOR'd with every array value. Since `x ^ x = 0`, matched pairs cancel, leaving only the missing number.

---

## XOR Bit Manipulation

### Rules
```
A ^ A = 0         (same value cancels out)
A ^ 0 = A         (XOR with 0 = itself)
Commutative: 1^2^3 == 3^1^2 == 2^3^1
```

### Examples
```
5 ^ 5 = 0
7 ^ 0 = 7
1 ^ 1 = 0
0 ^ 0 = 0
Same bits  = 0
Diff bits  = 1
```

### When to use XOR in interviews
- Finding missing numbers
- Finding the single non-duplicate in an array
- Swapping two variables without a temp variable
- Detecting if two values are equal

---

## Common C# Errors & Fixes

| Error Code | Message | Cause | Fix |
|---|---|---|---|
| CS0103 | `'isFull' does not exist in current context` | Called method that doesn't exist in scope | Make sure `IsFull()` is defined in the same class |
| CS1002 | `; expected` | Missing semicolon | Add `;` at end of statement (line 185) |
| CS0029 | `Cannot implicitly convert type` | Type mismatch | Cast explicitly or fix return type |
| CS0161 | `Not all code paths return a value` | Missing return in a branch | Add return or throw at end of all branches |

---

## Code Files Index

| File | Description | Module |
|---|---|---|
| `Module5/StackArray_Class1.cs` | Integer Stack Array implementation | Module 5 |
| `Module5/StackArray_Generic.cs` | Generic Stack Array `<T>` study version | Module 5 |
| `Module5/Program_StackDemo.cs` | Demo using built-in Stack<T> + custom StackArray | Module 5 |
| `Module5/Program_LinkedListDemo.cs` | Linked List AddLast + RemoveFirst demo | Module 5 |

---

*This guide is updated after every MSSA class session. Last updated: May 12, 2026.*
