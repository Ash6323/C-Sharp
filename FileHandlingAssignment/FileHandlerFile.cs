using System;
using System.IO;
using System.Reflection;

internal class FileHandlerClass : FileOperations
{
	private string uploadDirectoryPath = @"E:\\Work\\IncubXperts\\C-Sharp\\FileHandlingAssignment\\Uploaded Files\\";
    internal void RunFileHandler()
	{
        int uploadFilesCount;
        Console.WriteLine("* * * * File Handler Console Application * * * *");
        while(true)
        {
            Console.Write("\nHow Many Files do you want to Upload?: ");
            if (!int.TryParse(Console.ReadLine(), out uploadFilesCount))
                Console.WriteLine(ConstantMessagesForOutput.wrongInput);
            else
                break;
        }
		string[] filesToUpload = new string[uploadFilesCount];
        Console.WriteLine("\nEnter Files to Upload, One by One-");
        for(int i = 0; i < uploadFilesCount; i++)
		{
            while(true)
            {
                Console.Write($"Enter Path of File {i + 1}: ");
                string selectedFilePath = Console.ReadLine();
                FileInfo fileInfo = new FileInfo(selectedFilePath);
                if (filesToUpload.Contains(uploadDirectoryPath + fileInfo.Name))
                    Console.WriteLine(ConstantMessagesForOutput.fileAlreadySelected);
                else
                {                   
                    if (!File.Exists(selectedFilePath))
                        Console.WriteLine(ConstantMessagesForOutput.fileDoesNotExist);
                    else
                    {
                        filesToUpload[i] = uploadDirectoryPath + fileInfo.Name;
                        File.Copy(selectedFilePath, filesToUpload[i]);
                        break;
                    }                       
                }
            }
        }
        Console.WriteLine("\nFiles Uploaded...");
        int fileToEdit;
        while (true)
		{
            Console.WriteLine("\nUploaded Files are- ");
            int i = 1;
            foreach (string file in filesToUpload)
            {
                Console.WriteLine($"{i}. {Path.GetFileName(file)}");
                i++;
            }                    
            while(true)
            {
                Console.Write("\nSelect File to Edit (Press Any Other to Exit): ");
                if (!int.TryParse(Console.ReadLine(), out fileToEdit))
                    Console.WriteLine(ConstantMessagesForOutput.wrongInput);
                else
                    break;
            }           
            if (fileToEdit <= filesToUpload.Length)
            {
                FileInfo fileInfo = new FileInfo(filesToUpload[fileToEdit - 1]);
                if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png")
                    Console.WriteLine(ConstantMessagesForOutput.cannotEditFileType);

                else if (fileInfo.Extension == ".xls")
                    ExcelOperation(filesToUpload[fileToEdit - 1]);
                
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
                        while(true)
                        {
                            Console.Write("Your Choice: ");
                            if (!int.TryParse(Console.ReadLine(), out fileOperationChoice))
                                Console.WriteLine(ConstantMessagesForOutput.wrongInput);
                            else
                                break;
                        }
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
                        else if (fileOperationChoice == 4)
                            break;
                        //else if (fileOperationChoice == 5)
                        //{
                        //    MoveFile(filesToUpload[fileToEdit - 1]);
                        //    break;
                        //}
                        //else if (fileOperationChoice == 6)
                        //{
                        //    DeleteFile(filesToUpload[fileToEdit - 1]);
                        //    break;
                        //}
                        else
                            Console.WriteLine(ConstantMessagesForOutput.wrongInput);
                    }
                }
                else
                    Console.WriteLine(ConstantMessagesForOutput.wrongFileType);
            }
            else
                Environment.Exit(0);
        }
    }
}
