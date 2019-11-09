using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();
            stack.Push(1);
            stack.Push(5);
            stack.Push(8);
            Console.WriteLine($"Count={stack.Count}");
            stack.Pop();
            stack.Push(5);
            stack.Push(8);
            stack.Clear();
            stack.Push(14);
            stack.Push(5);
            stack.Push(8);
            stack.Push(5);
            stack.Push(")");
            stack.Push(")");
            stack.Push(8);
            stack.Pop();
            stack.Pop();
            Console.WriteLine($"Top={stack.Top()}");
            stack.Pop();
            
        }
    }
}
