using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadProgressNew
{
    internal class FileUploaderClass
    {
        public void RunFileUploader()
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
            Task task = UploadFile(filePath, "D:\\Folder");
            Task.WhenAll(task).Wait();
        }
        public static async Task UploadFile(string inputFile, string destinationPath)
        {
            await Task.Run(() =>
            {
                int bufferSize = 1024 * 512;
                using (FileStream fileStreaminput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream filestreamoutput = new FileStream(destinationPath, FileMode.Open, FileAccess.Write))
                    {
                        var sizeOfFile = fileStreaminput.Length;
                        int bytesRead = -1;
                        var totalReads = 0;
                        byte[] bytes = new byte[bufferSize];
                        //int lastPercentageDone = 0;
                        while ((bytesRead = fileStreaminput.Read(bytes, 0, bufferSize)) > 0)
                        {
                            filestreamoutput.Write(bytes, 0, bytesRead);
                            totalReads += bytesRead;
                            //int percent = Convert.ToInt32(((decimal)totalReads / (decimal)sizeOfFile) * 100);
                            //if (percent != lastPercentageDone)
                            //{
                            //    WriteProgressBar(percent, true);
                            //    lastPercentageDone = percent;
                            //}
                            //using (var progress = new ProgressBar())
                            //{
                            //    for (int i = 0; i <= 100; i++)
                            //    {
                            //        progress.Report((double)i / 100);
                            //        Thread.Sleep(20);
                            //    }
                            //}
                        }
                    }
                }
            });

        }
    }
}
