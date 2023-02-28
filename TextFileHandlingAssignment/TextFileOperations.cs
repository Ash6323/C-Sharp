using System;
using System.IO;

internal class TextFileOperations
{
	internal void CopyFile(string sourceFilePath)
	{
        string destinationFileName = "", destinationFolderPath = "", destinationFilePath = "";
        try
        {
            Console.Write("\nEnter the Destination Folder Path: ");
            destinationFolderPath = Console.ReadLine();
            Directory.SetCurrentDirectory(destinationFolderPath);
        }
        catch(DirectoryNotFoundException e)
        {
            Console.WriteLine("Directory not found: " + e.Message);
            Console.WriteLine(ConstantMessagesForOutput.exitingProgram);
            Environment.Exit(0);
        }
        while(true)
        {
            Console.Write("Enter the New File Name with Extension: ");
            destinationFileName = Console.ReadLine();
            FileInfo fileInfo = new FileInfo(destinationFileName);
            if (fileInfo.Extension != ".txt")
            {
                Console.WriteLine(ConstantMessagesForOutput.wrongFileType);
            }
            else
                break;
        }       
        destinationFilePath = destinationFolderPath + "\\" + destinationFileName;
        if (File.Exists(destinationFilePath))
        {
            Console.WriteLine(ConstantMessagesForOutput.fileAlreadyExists);
            Console.WriteLine(ConstantMessagesForOutput.exitingProgram);
            Environment.Exit(0);
        }
        File.Copy(sourceFilePath, destinationFilePath);
        Console.WriteLine("Data Copied to New File in Destination Folder...\n");
    }
    internal void DisplayFileContent(string sourceFilePath)
    {
        FileStream fileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read);
        string data;
        using (StreamReader streamReader = new StreamReader(fileStream))
        {
            data = streamReader.ReadToEnd();
        }
        Console.WriteLine("\nExisting Content in File- \n");
        Console.WriteLine(data);
    }
    internal void DisplayAndReplaceWord(string sourceFilePath)
    {
        string wordToBeReplaced;
        DisplayFileContent(sourceFilePath);
        while(true)
        {
            Console.Write("\nEnter the Word that is to be Replaced: ");
            wordToBeReplaced = Console.ReadLine();
            string textInFile = " " + File.ReadAllText(sourceFilePath) + " ";
            int indexOfWordInFile = textInFile.IndexOf(wordToBeReplaced);
            if (!File.ReadAllText(sourceFilePath).Contains(wordToBeReplaced))
            {
                Console.WriteLine(ConstantMessagesForOutput.wordNotPresent);
                continue;
            }
            else
                break;          
        }       
        Console.Write("Enter the New Word which will Replace Old Word: ");
        string replacingWord = Console.ReadLine();
        string text = File.ReadAllText(sourceFilePath);
        text = text.Replace(wordToBeReplaced, replacingWord);
        File.WriteAllText(sourceFilePath, text);
        Console.WriteLine("Content in File After Replacing Words-");
        DisplayFileContent(sourceFilePath);
    }
    internal void ReadLastLine(string sourceFilePath)
    {
        Console.WriteLine("\nLast Line of File is- ");
        Console.WriteLine(File.ReadLines(sourceFilePath).Last());
    }
}
