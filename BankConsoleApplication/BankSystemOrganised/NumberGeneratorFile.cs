using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using InnerSystem;
internal class CardAndAccountNumberGenerator : BankSystem
{
	public string CreditCardGenerator()
	{

        Console.WriteLine("Hello");
        bool flagCreditCard = true;
        while (flagCreditCard)
        {
            Console.WriteLine("Inside while");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Inside 1st for");
                Random rnd = new Random();
                int num = rnd.Next(1000, 10000);
                string parsedNum = num.ToString();
                creditCardNumber += parsedNum;
            }
            Console.WriteLine("account counter: "+accountCounter);
            for (int j = 0; j < accountCounter; j++)
            {
                Console.WriteLine("Inside second for");
                if (String.Equals(existingCreditCardNumbers[j], creditCardNumber) == false)
                {
                    flagCreditCard = false;
                    existingCreditCardNumbers[accountCounter] = creditCardNumber;
                    break;
                }
            }
            Console.WriteLine("before if");
            if (flagCreditCard == false)
                break;
        }
        Console.WriteLine(creditCardNumber);
        return creditCardNumber;
    }
}
