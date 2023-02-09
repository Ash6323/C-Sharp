
using ReadWrite;
using Properties;
using DataTypes;

internal class Program
{
    private static void Main (string[] args)
    {
        /*var objFirst = new MyReadWrite();
        objFirst.ReadWrite();

        var objSecond = new MyProperties();
        objSecond.Properties();*/

        var objThird = new MyDataTypes();
        objThird.DataTypes();

        Console.ReadKey();
    }
}