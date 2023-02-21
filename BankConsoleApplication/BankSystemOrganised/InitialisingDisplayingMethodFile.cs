internal class InitialisingDisplayingMethod
{
    private protected string firstName, lastName, email, contact, gender, dob, spouseFirstName = "";
    private protected string spouseLastName = "", spouseContact, childrenStatus, maritalStatus, accountTypeChoice;
    private protected string accountType, panNumber, permAddress, commAddress, sameAddressChoice, creditCardChoice;
    private protected string creditCardType, creditCardNumber = "", debitCardNumber = "", accountNumber = "";
    private protected string[] childrenName;
    private protected string[] creditCardTypes = { "Silver", "Gold", "Platinum" };
    private protected string[] existingCreditCardNumbers = new string[5];
    private protected string[] existingDebitCardNumbers = new string[5];
    private protected string[] existingAccountNumbers = new string[5];
    private protected string choice = "yes";
    private protected int childCount, monthlyIncome, creditCardTypeChoice, accountCounter = 0, depositOrWithdrawChoice;
    private protected bool spousePresent=false, childrenPresent;

    internal void DisplayAccountInformation()
    {
        Console.WriteLine("\nCongratulations.. Your Account Has Been Created. The Details are:\n");
        Console.WriteLine("First Name is: " + firstName);
        Console.WriteLine("Last Name is: " + lastName);
        Console.WriteLine("Gender is: " + gender);
        Console.WriteLine("Email is: " + email);
        Console.WriteLine("Date of Birth is: " + dob);
        Console.WriteLine("Contact Number is: " + contact);
        if (maritalStatus == "yes" || maritalStatus == "y")
            Console.WriteLine("Marital Status is: Married");
        else if(maritalStatus == "D" || maritalStatus == "d")
            Console.WriteLine("Marital Status is: Divorced");
        else
            Console.WriteLine("Marital Status is: Unmarried");
        if (spousePresent)
        {
            Console.WriteLine("First Name of Spouse is: " + spouseFirstName);
            Console.WriteLine("Last Name of Spouse is: " + spouseLastName);
        }
        if (childrenPresent)
        {
            for (int i = 0; i < childCount; i++)
                Console.WriteLine($"Child {i + 1}'s Name: " + childrenName[i]);
        }
        Console.WriteLine("Credit Card Type is: " + creditCardType);
        Console.WriteLine("Credit Card Number is: " + creditCardNumber);
        Console.WriteLine("Account Number is: " + accountNumber);
        Console.WriteLine("Debit Card Number is: " + debitCardNumber);
    }
}
