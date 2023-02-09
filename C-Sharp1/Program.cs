
using ReadWrite;
using Properties;

internal class Program
{
    private static void Main (string[] args)
    {
        var obj1 = new MyFile1();
        //obj1.ReadWrite();
        
        var obj2 = new MyFile2();
        obj2.Properties();
     
    }
}