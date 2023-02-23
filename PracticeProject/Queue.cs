using System;
using System.Collections;

public class QueueTest
{
    public void runQueue()
    {
        Queue queue = new Queue();
        queue.Enqueue(123);
        queue.Enqueue("Hello");
        queue.Enqueue("World");
        queue.Enqueue(3.14f);
        queue.Enqueue(true);
        queue.Enqueue(67.8);
        queue.Enqueue(67.8);
        queue.Enqueue('A');

        Console.Write("\nItems in Queue- ");
        foreach (var v in queue)
            Console.Write(v + " ");

        Console.WriteLine($"\n\nQueue Count Before Deletion: {queue.Count}");

        Console.WriteLine($"\nDeleted Element (Dequeue): {queue.Dequeue()}");

        Console.WriteLine($"\nQueue After Deletion: Count {queue.Count}\n");

        foreach (var v in queue)
            Console.Write($"{v} ");

        queue.Clear();

        Console.WriteLine($"\n\nueue After using Clear Operation: Count {queue.Count}");

        foreach (var v in queue)
            Console.Write($"{v} ");

        //Console.Write("Enter Number 1: ");
        //int num1 = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine();
        //Console.Write("Enter Number 2: ");
        //int num2 = Convert.ToInt32(Console.ReadLine());
        //try
        //{
        //    Console.WriteLine($"Division: {num1 / num2}");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"\nException is: {ex.Message}");
        //}
    }
}
 //1. Identifying areas where exception can come, 2. Catching them, 3. Handling them 
 //4. Types of arithmetic exceptions, system exceptions
 //5. 
