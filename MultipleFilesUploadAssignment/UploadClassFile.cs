namespace MultipleFilesUploadAssignment
{
    internal class UploadClass
    {
        public static async Task UploadFile(string path)
        {
            FileInfo fileInfo = new (path);
            await Task.Run(() => File.Copy(path, Path.Combine(ConstantStringsClass.UploadDirectoryPath, fileInfo.Name)));
            Console.WriteLine($"{fileInfo.Name} Uploaded");
        }
    }
}
