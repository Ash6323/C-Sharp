using System;

internal class LongestCommonPrefix
{
	private string inputString;
	internal void runLongestCommonPrefix()
	{
		Console.WriteLine("\nLongest Common Prefix-\n");
		Console.Write("Enter the String: ");
		inputString = Console.ReadLine();
        string[] wordArray = inputString.Split(" ");

		List<string> repeatedPrefixes = new List<string>();
		for (int i = 0; i < wordArray.Count(); i++)
		{
			for (int j = i + 1; j < wordArray.Count(); j++)
			{
				int sizeOfSmallerWord = wordArray[i].Length < wordArray[j].Length ? wordArray[i].Length : wordArray[j].Length;
				string prefixCompare = "";
				for (int k = 0; k < sizeOfSmallerWord; k++)
				{
					if (wordArray[i][k] == wordArray[j][k])
                        prefixCompare += wordArray[i][k];
					else
						break;
				}
                repeatedPrefixes.Add(prefixCompare);
			}
		}
		Console.Write("\nRepeated Prefixes are: ");
		foreach(var s in repeatedPrefixes)
			Console.Write(s + " ");
		
		string longestCommonPrefix = "";
		foreach(var s in repeatedPrefixes)
        {
			if(longestCommonPrefix.Length < s.Length)
				longestCommonPrefix = s;
		}
		Console.WriteLine("\n\nLongest Common Prefix is: " + longestCommonPrefix);

		int longestCommonPrefixCount=0;
		foreach(var s in repeatedPrefixes)
		{
			if (s == longestCommonPrefix)
				longestCommonPrefixCount++;
		}
        Console.WriteLine("\nCount of Longest Common Prefix is: " + longestCommonPrefixCount);
    }
}
