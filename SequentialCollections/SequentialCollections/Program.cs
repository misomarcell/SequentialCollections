using System;
using System.Collections.Generic;

namespace SequentialCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<String> queue = new Queue<String>();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");

            while (queue.Count > 0)
            {
                object obj = queue.Dequeue();

                Console.WriteLine("From Queue: {0}", obj);           
            }


            Stack<String> stack = new Stack<String>();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            stack.Push("Fourth");

            while (stack.Count > 0)
            {
                object obj = stack.Pop();
                Console.WriteLine("From Stack: {0}", obj);
            }

            Console.ReadKey();
        }
    }
}