using System.Text;

public class FileHandlingClass
{
    public void runFileHandler()
    {
        string filePath = @"E:\Work\IncubXperts\C-Sharp\PracticeProject\MyFile.txt";
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        Console.WriteLine($"\nFile has been created and the Path is {filePath}\n");
        byte[] writeData = Encoding.Default.GetBytes("Hello World!!!");
        fileStream.Write(writeData, 0, writeData.Length);
        Console.WriteLine("Successfully Wrote the Message onto File\n");
        fileStream.Close();
        Console.ReadKey();

        StreamWriter sw = new StreamWriter("E:\\Work\\IncubXperts\\C-Sharp\\PracticeProject\\MyFile.txt");
        Console.Write("Enter the Text that you want to write on File: ");
        string str = Console.ReadLine();
        sw.Write(str);
        Console.WriteLine("\nSuccessfully Wrote the Text onto File\n");
        sw.Flush();     // Clears all the buffers
        sw.Close();

        StreamReader sr = new StreamReader("E:\\Work\\IncubXperts\\C-Sharp\\PracticeProject\\MyFile.txt");
        Console.Write("Contents of the File- ");
        sr.BaseStream.Seek(0, SeekOrigin.Begin);
        str = sr.ReadLine();     // To read line from input stream

        while (str != null)     // To read the whole file line by line
        {
            Console.WriteLine(str);
            str = sr.ReadLine();
        }
        sr.Close();

        Console.Write("\nReading first 4 characters using TextReader- ");
        using (TextReader textReader = File.OpenText(filePath))
        {
            char[] ch = new char[4];
            textReader.ReadBlock(ch, 0, 4);
            Console.WriteLine(ch);
        }
        Console.Write("Reading full file using TextReader- ");
        using (TextReader textReader = File.OpenText(filePath))
        {
            Console.WriteLine(textReader.ReadToEnd());
        }

        //Writing A Sample Error Log Using BinaryWriter
        using (BinaryWriter writer = new BinaryWriter(File.Open("E:\\Work\\IncubXperts\\C-Sharp\\PracticeProject\\MyBinaryFile.bin", FileMode.Create)))
        {
            writer.Write("0x80234400");
            writer.Write("Windows Explorer Has Stopped Working");
            writer.Write(true);
        }
        Console.WriteLine("\nBinary File Created Using BinaryWriter!");
        using (BinaryReader reader = new BinaryReader(File.Open("E:\\Work\\IncubXperts\\C-Sharp\\PracticeProject\\MyBinaryFile.bin", FileMode.Open)))
        {
            Console.WriteLine("\nError Code : " + reader.ReadString());
            Console.WriteLine("Message : " + reader.ReadString());
            Console.WriteLine("Restart Explorer : " + reader.ReadBoolean());
        }

        //Writing string into StringWriter and StringReader
        string text = "Hello. This is First Line \nHello. This is Second Line \nHello. This is Third Line";
        StringBuilder stringBuilder = new StringBuilder();
        StringWriter stringWriter = new StringWriter(stringBuilder);
        stringWriter.WriteLine(text);
        stringWriter.Flush();
        stringWriter.Close();
        Console.WriteLine("\nWritten Data in StringBuilder using StringWriter");

        StringReader stringReader = new StringReader(stringBuilder.ToString());
        Console.WriteLine("Reading Data from StringBuilder using StringReader- ");
        while (stringReader.Peek() > -1)
            Console.WriteLine(stringReader.ReadLine());

        //FileInfo Implementation
        string path = @"E:\Work\IncubXperts\C-Sharp\PracticeProject\MyFile.txt";
        FileInfo fileInfo = new FileInfo(path);
        StreamWriter stringWriteFileInfo = fileInfo.CreateText();
        stringWriteFileInfo.WriteLine("Hello this is FileInfo");
        Console.WriteLine("\nFile has been created with text using FileInfo");
        stringWriteFileInfo.Close();

        //DirectoryInfo
        string directoryPath = @"E:\Work\IncubXperts\C-Sharp\PracticeProject";
        DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
        Console.WriteLine("\nUsing DirecotryInfo Class");
        try
        {
            if (directoryInfo.Exists)
            {
                Console.WriteLine("{0} Directory already exists", directoryPath);
                Console.WriteLine("Directory Name : " + directoryInfo.Name);
                Console.WriteLine("Path : " + directoryInfo.FullName);
                Console.WriteLine("Directory Created on : " + directoryInfo.CreationTime);
                Console.WriteLine("Directory Last Accessed: " + directoryInfo.LastAccessTime);
            }
        }
        catch (DirectoryNotFoundException d)
        {
            Console.WriteLine("Exception raised : " + d.Message);
            Console.ReadKey();
        }
    }
}