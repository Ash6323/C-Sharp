using System;
using System.Text.RegularExpressions;

internal class CountLine
{
	private string inputString;
	internal void runCountLine()
	{
        Console.Write("Enter the String: ");
        inputString = Console.ReadLine();
        int lineCount = 0;

        for (int i = 0; i < inputString.Length; i++)
        {
            if (inputString[i] == '.' && inputString[i + 1] == ' ')
                lineCount++;

            else if (inputString[i] == '?' && inputString[i + 1] == ' ')
                lineCount++;

            else if (inputString[i] == '!' && inputString[i + 1] == ' ')
                lineCount++;

            else if (i == inputString.Length - 1)
            {
                if (inputString[i] == '.' || inputString[i] == '?' || inputString[i] == '!')
                    lineCount++;
            }
        }
        Console.Write("\nNumber of Lines: " + lineCount);
    }
}

//[!?.]+(?=$|\\s)
//(.*?)[\\!\\?\\.]\\s+