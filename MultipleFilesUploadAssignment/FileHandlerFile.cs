using System.Diagnostics;

namespace MultipleFilesUploadAssignment
{
    internal class FileUploaderClass
    {
        internal static void RunFileUploader()
        {
            List<string> pathOfFilesToUpload = ConstantStringsClass.CommaSeparatedPaths.Split(',').ToList();
            foreach (string file in pathOfFilesToUpload)
            {
                if(!File.Exists(file))
                {
                    Console.WriteLine($"{file} {ConstantStringsClass.FileDoesNotExist}");
                    return;
                }
            }
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Starting Upload...\n");
            try
            {
                IEnumerable<Task> tasks = pathOfFilesToUpload.Select(currentFile => UploadClass.UploadFile(currentFile));
                Task.WhenAll(tasks).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nAll Uploads Complete.");
            Console.WriteLine($"Elapsed Time: {sw.ElapsedMilliseconds} ms");
        }
    }
}
