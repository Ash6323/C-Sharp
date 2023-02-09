
using ReadWrite;
using Properties;

internal class Program
{
    private static void Main (string[] args)
    {
        var objFirst = new MyReadWrite();
        objFirst.ReadWrite();
        
        var objSecond = new MyProperties();
        objSecond.Properties();
     
        Console.ReadKey();
    }
}