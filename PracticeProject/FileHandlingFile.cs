using System;
using System.Text;
using System.Xml.Linq;

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
    }
}
