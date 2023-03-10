
namespace FileUploadProgress
{
    public class FileUploadClass
    {
        public static async Task UploadFile(string inputFile, string destinationPath)
        {
            await Task.Run(() =>
            {
            int bufferSize = 1024 * 512;
            try
            {
                using (FileStream fileStreaminput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream filestreamoutput = new FileStream(destinationPath, FileMode.Open, FileAccess.Write))
                    {
                        var sizeOfFile = fileStreaminput.Length;
                        int bytesRead = -1;
                        var totalReads = 0;
                        byte[] bytes = new byte[bufferSize];
                        int lastPercentageDone = 0;
                        while ((bytesRead = fileStreaminput.Read(bytes, 0, bufferSize)) > 0)
                        {
                            filestreamoutput.Write(bytes, 0, bytesRead);
                            totalReads += bytesRead;
                            int percentage = Convert.ToInt32(((decimal)totalReads / (decimal)sizeOfFile) * 100);
                            if (percentage != lastPercentageDone)
                            {
                                ConsoleUtility.WriteProgressBar(percentage, true);
                                lastPercentageDone = percentage;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            
            });
        }
    }
}
