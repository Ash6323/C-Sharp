using System.Text.RegularExpressions;
using InnerSystem;

namespace BankSystemOrganised
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankSystem bankObj = new BankSystem();
            bankObj.run();
        }
    }

}