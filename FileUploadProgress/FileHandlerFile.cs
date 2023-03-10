using System;

namespace FileUploadProgress
{
    internal class FileUploaderClass
    {
        internal void RunFileUploader()
        {
            string filePath;
            while (true)
            {
                Console.Write("Enter the Path of File to be Uploaded: ");
                filePath = Console.ReadLine();
                if (!File.Exists(filePath))
                    Console.WriteLine(ConstantStringsClass.FileDoesNotExist);
                else
                    break;
            }
            Task task = FileUploadClass.UploadFile(filePath, ConstantStringsClass.UploadDirectory);
            Task.WhenAll(task).Wait();
        }
    }
}
