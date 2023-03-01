using System;

internal class TextFileHandlerClass : TextFileOperations
{
	internal void RunTextFileHandler()
	{
        string sourceDirectoryPath =  String.Empty, sourceFileName = String.Empty, sourceFilePath = String.Empty;
        Console.WriteLine("* * * * File Handler Console Application * * * *");
        try
        {
            Console.Write("Enter the Directory Path: ");
            sourceDirectoryPath = Console.ReadLine();
            if(!Directory.Exists(sourceDirectoryPath))
                throw new DirectoryNotFoundException();
            while (true)
            {
                Console.Write("Enter the File Name with Extension: ");
                sourceFileName = Console.ReadLine();
                sourceFilePath = Path.Combine(sourceDirectoryPath, sourceFileName);
                if(!File.Exists(sourceFilePath))
                    throw new FileNotFoundException();

                FileInfo fileInfo = new FileInfo(sourceFilePath);
                if (fileInfo.Extension != ".txt")
                    Console.WriteLine(ConstantMessagesForOutput.wrongFileType);
                else
                    break;
            }
            using (StreamReader reader = new StreamReader(sourceFilePath))
            {
                reader.ReadToEnd();
            }
        }
        catch(DirectoryNotFoundException e)
        {
            Console.WriteLine("Directory not found: " + e.Message);
            Console.WriteLine(ConstantMessagesForOutput.exitingProgram);
            Environment.Exit(0);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found: " + e.Message);
            Console.WriteLine(ConstantMessagesForOutput.exitingProgram);
            Environment.Exit(0);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception Occurred: " + e.Message);
            Console.WriteLine(ConstantMessagesForOutput.exitingProgram);
            Environment.Exit(0);
        }
        while(true)
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Copy Data from one File to Another\n2. Display Existing Text and Replace Specific Words");
            Console.WriteLine("3. Display Last Line of File and File Name\n4. Exit");
            int fileOperationChoice;
            while(true)
            {
                Console.Write("Your Choice: ");
                if (!int.TryParse(Console.ReadLine(), out fileOperationChoice))
                    Console.WriteLine(ConstantMessagesForOutput.wrongInput);
                else
                    break;
            }
            if (fileOperationChoice == 1)
                CopyFile(sourceFilePath);
            
            else if (fileOperationChoice == 2)
                DisplayAndReplaceWord(sourceFilePath);
            
            else if (fileOperationChoice == 3)
            {
                ReadLastLine(sourceFilePath);
                Console.Write($"Name of File is: {Path.GetFileName(sourceFilePath)}");
            }           
            else if (fileOperationChoice == 4)
                Environment.Exit(0);           
            else
                Console.WriteLine(ConstantMessagesForOutput.wrongInput);
        }      
    }
}
