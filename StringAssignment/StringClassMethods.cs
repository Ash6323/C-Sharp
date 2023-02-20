using System;
internal class StringClassMethods
{
    private string inputString;
	internal void runStringClassMethods()
	{
        Console.WriteLine("* * * * String Assignment * * * *\n\n1. Get Length of Given String");
        Console.WriteLine("2. Join 2 Given Strings Using Concat\n3. Compare 2 Given Strings for Equality");
        Console.WriteLine("4. Split a String into Substrings\n5. Replace Specified Character with Another in String");
        Console.WriteLine("6. Check Whether a String Contains a Substring\n7. Join Strings Using a Separator");
        Console.WriteLine("8. Remove Leading/Trailing White Spaces\n9. Get Position of Specified Character in String");
        Console.WriteLine("10. Convert String to Uppercase/Lowercase");
        int choice;
        while (true)
        {
            Console.Write("\nSelect Which Operation You Want to Perform: ");
            choice = Convert.ToInt32(Console.ReadLine());
            if (ValidationMethods.ValidateStringOperationChoice(choice))
                break;
            else
                Console.WriteLine(ConstantMessagesForOutput.wrongChoice);
        }

        if(choice == 1)
        {
            Console.Write("Enter the String: ");
            inputString = Console.ReadLine();
            Console.WriteLine("Length of String: " + inputString.Length);
        }
        else if(choice == 2)
        {
            Console.Write("Enter the String: ");
            inputString = Console.ReadLine();
            Console.Write("Enter the Second String: ");
            string inputString2 = Console.ReadLine();
            Console.WriteLine("Joined String is: "+ String.Concat(inputString, inputString2));
        }
        else if (choice == 3)
        {
            Console.Write("Enter the String: ");
            inputString = Console.ReadLine();
            Console.Write("Enter the Second String: ");
            string inputString2 = Console.ReadLine();
            Console.WriteLine("Are the Strings Same?: " + inputString.Equals(inputString2));
        }
        else if(choice == 4)
        {
            string[] splittedString;
            Console.Write("Enter the String: ");
            inputString = Console.ReadLine();
            splittedString = inputString.Split();
            Console.Write("Printing Array of String: ");
            for(int i = 0; i < splittedString.Length; i++)
                Console.Write(splittedString[i]+" ");
        }
        else if(choice == 5)
        {
            Console.Write("Enter the String: ");
            inputString = Console.ReadLine();
            Console.Write("\nEnter the Substring to be Replaced: ");
            string toBeReplaced = Console.ReadLine();
            Console.Write("\nEnter the Replacement Character: ");
            string replacementString = Console.ReadLine();
            Console.WriteLine("New String After Replacement: " + inputString.Replace(toBeReplaced, replacementString));
        }
        else if (choice==6)
        {
            Console.Write("Enter the String: ");
            inputString = Console.ReadLine();
            Console.Write("Enter Substring to be Checked: ");
            string toBeCheckedInString = Console.ReadLine();
            Console.WriteLine("Is the Substring Present in Given String?: " + inputString.Contains(toBeCheckedInString));
        }
        else if (choice == 7)
        {
            Console.Write("Enter Number of Strings to be Entered in Array: ");
            int numOfWords = Convert.ToInt16(Console.ReadLine());
            string[] stringArray = new string[numOfWords];
            Console.Write("Enter the String Array: ");
            for (int i = 0; i < numOfWords; i++)
                stringArray[i] = Console.ReadLine()+" ";
                
            Console.WriteLine("String After Joining: " + String.Join(" ", stringArray));
        }
        else if( choice == 8 )
        {
            Console.Write("Enter the String: ");
            inputString = Console.ReadLine();
            Console.WriteLine("String After Removing Leading/Trailing White Spcaes: " + inputString.Trim());
        }
        else if(choice == 9 )
        {
            Console.Write("Enter the String: ");
            inputString = Console.ReadLine();
            Console.Write("Enter the Character Whose Index is to be Found: ");
            char indexToBeFound = Convert.ToChar(Console.Read());
            Console.WriteLine($"Index of {indexToBeFound} is: {inputString.IndexOf(indexToBeFound)}");
        }
        else if( choice==10 )
        {
            Console.Write("Enter the String: ");
            inputString = Console.ReadLine();
            Console.WriteLine("Upper Case: " + inputString.ToUpper());
            Console.WriteLine("Lower Case: " + inputString.ToLower());
        }
    }
}
