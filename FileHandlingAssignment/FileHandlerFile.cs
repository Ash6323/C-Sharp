using System;
using System.IO;

internal class FileHandlerClass : FileOperations
{
	private string directoryPath = @"E:\\Work\\IncubXperts\\C-Sharp\\FileHandlingAssignment\\ResourceFiles\\";
    internal void RunFileHandler()
	{
        string[] filesInDirectory = Directory.GetFiles(directoryPath);
        Console.WriteLine("* * * * File Handler Console Application * * * *");
        Console.WriteLine("\nAvailable Files-");
        int j = 1;
        foreach (string file in filesInDirectory)
		{
			Console.WriteLine($"{j}. {Path.GetFileName(file)}");
			j++;
		}
        Console.Write("\nHow Many Files do you want to Upload?: ");
		int uploadFilesCount = Convert.ToInt32(Console.ReadLine());
		string[] filesToUpload = new string[uploadFilesCount];
		int fileSelection, fileToEdit;
        Console.WriteLine("\nSelect Files to Upload, One by One-");
        for(int i = 0; i < uploadFilesCount; i++)
		{
            Console.Write($"Choose File {i+1}: ");
			fileSelection = Convert.ToInt32(Console.ReadLine());
			filesToUpload[i] = filesInDirectory[fileSelection-1];
        }
		while(true)
		{
            Console.WriteLine("\n\nSelected Files are- ");
            foreach (string file in filesToUpload)
            {
                int i = 1;
                Console.WriteLine($"{i}. {Path.GetFileName(file)}");
                i++;
            }
            Console.Write("\nSelect File to Edit (Press Any Other to Exit): ");
            fileToEdit = Convert.ToInt32(Console.ReadLine());
            if (fileToEdit <= filesToUpload.Length)
            {
                FileInfo fileInfo = new FileInfo(filesToUpload[fileToEdit - 1]);
                if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png")
                {
                    Console.WriteLine(ConstantMessagesForOutput.cannotEditFileType);
                    break;
                }
                else if (fileInfo.Extension == ".xls")
                {
                    ExcelOperation(filesToUpload[fileToEdit - 1]);
                }
                else if(fileInfo.Extension == ".txt")
                {
                    Console.WriteLine("\nExisting Content in File- \n");
                    FileStream fileStream = new FileStream(filesToUpload[fileToEdit - 1], FileMode.Open, FileAccess.Read);
                    string data;
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        data = streamReader.ReadToEnd();
                    }
                    Console.WriteLine(data);
                    while (true)
                    {
                        Console.WriteLine("What do you want to do?- ");
                        Console.WriteLine("1. Append to File\n2. Overwrite File\n3. Copy File\n4. Exit");
                        int fileOperationChoice;
                        Console.Write("Your Choice: ");
                        fileOperationChoice = Convert.ToInt32(Console.ReadLine());
                        if (fileOperationChoice == 1)
                        {
                            AppendToFile(filesToUpload[fileToEdit - 1]);
                            break;
                        }
                        else if (fileOperationChoice == 2)
                        {
                            OverWriteFile(filesToUpload[fileToEdit - 1]);
                            break;
                        }
                        else if (fileOperationChoice == 3)
                        {
                            CopyFile(filesToUpload[fileToEdit - 1]);
                            break;
                        }
                        //else if (fileOperationChoice == 4)
                        //{
                        //    MoveFile(filesToUpload[fileToEdit - 1]);

                        //    break;
                        //}
                        //else if (fileOperationChoice == 4)
                        //{

                        //}
                        else if (fileOperationChoice == 4)
                            break;

                        else
                            Console.WriteLine(ConstantMessagesForOutput.wrongChoice);
                    }
                }
                else
                {
                    Console.WriteLine(ConstantMessagesForOutput.wrongFileType);
                }
            }
            else
                Environment.Exit(0);
        }
    }
}
