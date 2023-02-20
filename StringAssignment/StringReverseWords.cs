using System;

internal class ReverseWords
{
    private string inputString;
	internal void runReverseWords()
	{
        Console.WriteLine("\nReverse Each Word in Given String-\n");
        Console.Write("Enter the String: ");
        inputString = Console.ReadLine();

        string[] wordArray = inputString.Split(" ");
        for (int i = 0; i < wordArray.Length; i++)
        {
            string reverseWords = "";
            for (int j = wordArray[i].Length-1; j>=0; j--)
                reverseWords += wordArray[i][j];
            
            Console.Write(reverseWords + " ");
        }
    }
}
