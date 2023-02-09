using System;

namespace ReadWrite	
{
	public class MyFile1
	{
		public void ReadWrite()
        {
            Console.WriteLine("Using WriteLine()");
			Console.Write("Using ");
            Console.Write("Write()");
			Console.WriteLine(" ");

			String a;
            Console.Write("Enter a String: ");
            a = Console.ReadLine();
            Console.Write("Writing Value of String: ");
            Console.WriteLine(a);

            Console.Write("Enter an Integer: ");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"The entered Integer is: {c}");

            string value = "IncubXperts";
			Console.WriteLine(value);
			Console.WriteLine("Hello " + value);
			Console.WriteLine($"Hey {value}");

            Console.Write("Input Key: ");
            ConsoleKeyInfo b = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Key Pressed is: {b.KeyChar} and ASCII value is: {(int)b.KeyChar}");
        }


    }
}