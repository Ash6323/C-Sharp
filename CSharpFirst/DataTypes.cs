using System;

namespace DataTypes
{
    public class MyDataTypes
    {
        public void DataTypes()
        {
            //Char
            char ch = 'q';
            Console.WriteLine($"ASCII of {ch} is {(byte) ch}");
            Console.WriteLine($"Size of char is: {sizeof(char)} Byte");
            Console.WriteLine();

            //Byte
            byte number = 25;
            Console.WriteLine($"ASCII corresponding {number} is {(char)number}");
            Console.WriteLine($"Size of byte is: {sizeof(byte)} Byte");
            Console.WriteLine();

            //String
            string str = "Ashwin";
            Console.WriteLine($"Entered String: {str}");
            Console.WriteLine($"Size of entered string is: {str.Length * sizeof(char)} Byte");
            Console.WriteLine();

            //Int
            int integerNumber = 67;
            Console.WriteLine($"Entered Integer: {integerNumber}");
            Console.WriteLine($"Size of int: {sizeof(int)} Byte");
            Console.WriteLine($"Max Value of int: {int.MaxValue}");
            Console.WriteLine();

            //Pointer
            /*unsafe
            {
                int num = 25;

                int* ptr = &num;
                Console.WriteLine($"Value of num is: {num}");
                Console.WriteLine($"Address of num is: {(int)ptr}");
            }*/
        }
    }
}

