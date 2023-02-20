using System;
using System.Runtime.CompilerServices;

internal class RemoveDuplicateCharacter
{
    private string inputString;
	internal void runDuplicateCharacterRemover()
	{
        Console.WriteLine("\nRemove Duplicate Characters from Given String-\n");
        Console.Write("Enter the String: ");
        inputString = Console.ReadLine();
        string outputString = "";
        for(int i=0; i<inputString.Length; i++)
        {
            if (!outputString.Contains(inputString[i]) || (inputString[i] == ' '))
                outputString += inputString[i];
        }
        outputString = outputString.Replace("  ", " ");
        Console.WriteLine("String After Removing Duplicate Characters: " + outputString);
    }
}
