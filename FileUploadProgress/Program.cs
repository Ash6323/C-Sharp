namespace FileUploadProgress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileUploaderClass fileUploadObject = new();
            fileUploadObject.RunFileUploader();
        }
    }
}