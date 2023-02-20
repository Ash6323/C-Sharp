namespace StringAssignmentNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("* * * * String Assignment * * * *\n\n1. Get Longest Common Prefix in Given String");
            Console.WriteLine("2. Count Lines in Given String\n3. Demonstrate Usage of String Class Methods");
            Console.WriteLine("4. Reverse Words in Given Strings\n5. Remove Duplicate Characters from Given String");
            int choice;
            while (true)
            {
                Console.Write("\nSelect Which Program You Want to Run: ");
                choice = Convert.ToInt16(Console.ReadLine());
                if (ValidationMethods.ValidateChoice(choice))
                    break;
                else
                    Console.WriteLine(ConstantMessagesForOutput.wrongChoice);
            }
            switch (choice)
            {
                case 1:
                    LongestCommonPrefix stringObj1 = new LongestCommonPrefix();
                    stringObj1.runLongestCommonPrefix();
                    break;

                case 2:
                    CountLine stringObj2 = new CountLine();
                    stringObj2.runCountLine();
                    break;

                case 3:
                    StringClassMethods stringObj3 = new StringClassMethods();
                    stringObj3.runStringClassMethods();
                    break;

                case 4:
                    ReverseWords stringObj4 = new ReverseWords();
                    stringObj4.runReverseWords();
                    break;

                case 5:
                    RemoveDuplicateCharacter stringObj5 = new RemoveDuplicateCharacter();
                    stringObj5.runDuplicateCharacterRemover();
                    break;
            }
        }
    }
}