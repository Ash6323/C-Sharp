using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace InnerSystem
{
    internal class Processes
    {
        protected static bool NameValidate(string str)
        {
            if (Regex.Match(str, "^[A-Z][a-zA-Z]*$").Success)
                return false;
            else return true;
        }
        protected static bool EmailValidate(string str)
        {
            if (Regex.Match(str, "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$").Success)
                return false;
            else return true;
        }
        protected static bool DOBValidate(string str)
        {
            if (Regex.Match(str, "(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]\\d{4}").Success)
                return false;
            else return true;
        }
        protected static bool ContactValidate(string str)
        {
            if (Regex.Match(str, "\\A[0-9]{10}\\z").Success)
                return false;
            else return true;
        }
        protected static bool GenderValidate(string str)
        {
            if (Regex.Match(str, "(?:m|M|male|Male|f|F|female|Female|FEMALE|MALE)$").Success)
                return false;
            else return true;
        }
        protected static bool MaritalStatusValidate(string str)
        {
            if (Regex.Match(str, "(?:y|n|yes|no|Yes|No|YES|NO)$").Success)
                return false;
            else return true;
        }
        protected static bool PANCardValidate(string str)
        {
            if (Regex.Match(str, "[A-Z]{5}[0-9]{4}[A-Z]{1}").Success)
                return false;
            else return true;
        }

    }
    public static class ConstantMessages
    {
        public static class Messages
        {
            public const string invalidName = "Name Invalid...";
            public const string wrongChoice = "Wrong Input!! Exiting...";
        }
    }

    internal class BankSystem : Processes
    {
        private string firstName, lastName, email, contact, gender, dob, spouseFirstName = "";
        private string spouseLastName = "", spouseContact, childrenStatus, maritalStatus, accountTypeChoice;
        private string accountType, panNumber, permAddress, commAddress, sameAddressChoice, creditCardChoice;
        private string creditCardType, creditCardNumber = "", debitCardNumber = "", accountNumber = "";
        private string[] childrenName;
        private string[] creditCardTypes = { "Silver", "Gold", "Platinum" };
        private string[] existingCreditCardNumbers = new string[5];
        private string[] existingDebitCardNumbers = new string[5];
        private string[] existingAccountNumbers = new string[5];
        private string choice = "yes";
        private int childCount, monthlyIncome, creditCardTypeChoice, accountCounter = 0;

        internal void run()
        {
            

            while (choice == "yes" || choice == "y" || choice == "Y")
            {
                accountCounter += 1;

                Console.WriteLine("* * * * Welcome to IX Bank * * * *\n");
                Console.WriteLine("Enter Your Personal Details Below:");

                //Personal Details 

                Console.Write("Enter First Name: ");
                firstName = Console.ReadLine();
                if (NameValidate(firstName) == true)
                {
                    Console.WriteLine(ConstantMessages.Messages.invalidName);
                    Environment.Exit(0);
                }

                Console.Write("Enter Last Name: ");
                lastName = Console.ReadLine();
                if (NameValidate(lastName) == true)
                {
                    Console.WriteLine(ConstantMessages.Messages.invalidName);
                    Environment.Exit(0);
                }

                Console.Write("Enter Gender (m/f/Male/Female): ");
                gender = Console.ReadLine();
                if (GenderValidate(gender) == true)
                {
                    Console.WriteLine("Gender Invalid...");
                    Environment.Exit(0);
                }

                Console.Write("Enter Email Address: ");
                email = Console.ReadLine();
                if (EmailValidate(email) == true)
                {
                    Console.WriteLine("Email Invalid...");
                    Environment.Exit(0);
                }

                Console.Write("Enter Date of Birth: ");
                dob = Console.ReadLine();
                if (DOBValidate(dob) == true)
                {
                    Console.WriteLine("Date of Birth Invalid...");
                    Environment.Exit(0);
                }

                Console.Write("Enter Contact Number: ");
                contact = Console.ReadLine();
                if (ContactValidate(contact) == true)
                {
                    Console.WriteLine("Contact Number Invalid...");
                    Environment.Exit(0);
                }

                //Family Details 

                Console.Write("Marital Status? (yes/no or y/n): ");
                maritalStatus = Console.ReadLine();
                if (MaritalStatusValidate(maritalStatus) == true)
                {
                    Console.WriteLine("Marital Status Invalid...");
                    Environment.Exit(0);
                }

                if (maritalStatus == "yes" || maritalStatus == "y")
                {
                    Console.Write("Enter First Name of Spouse: ");
                    spouseFirstName = Console.ReadLine();
                    if (NameValidate(spouseFirstName) == true)
                    {
                        Console.WriteLine(ConstantMessages.Messages.invalidName);
                        Environment.Exit(0);
                    }

                    Console.Write("Enter Last Name of Spouse: ");
                    spouseLastName = Console.ReadLine();
                    if (NameValidate(spouseLastName) == true)
                    {
                        Console.WriteLine(ConstantMessages.Messages.invalidName);
                        Environment.Exit(0);
                    }

                    Console.Write("Enter Contact Number of Spouse: ");
                    spouseContact = Console.ReadLine();
                    if (ContactValidate(spouseContact) == true)
                    {
                        Console.WriteLine("Contact Number Invalid...");
                        Environment.Exit(0);
                    }


                    //Children

                    Console.Write("Do you have Children? (yes/no or y/n): ");
                    childrenStatus = Console.ReadLine();

                    if (childrenStatus == "yes" || childrenStatus == "y")
                    {

                        Console.Write("How many children do you have?: ");
                        childCount = Convert.ToInt32(Console.ReadLine());
                        childrenName = new String[childCount];
                        for (int i = 0; i < childCount; i++)
                        {
                            Console.Write($"Enter Child {i + 1}'s Name: ");
                            childrenName[i] = Console.ReadLine();
                            if (NameValidate(childrenName[i]) == true)
                            {
                                Console.WriteLine(ConstantMessages.Messages.invalidName);
                                Environment.Exit(0);
                            }

                        }
                    }
                    else if (childrenStatus == "no" || childrenStatus == "n")
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine(ConstantMessages.Messages.wrongChoice);
                        Environment.Exit(0);
                    }

                }

                else if (maritalStatus == "no" || maritalStatus == "n")
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(ConstantMessages.Messages.wrongChoice);
                    Environment.Exit(0);
                }


                //Account Type

                Console.Write("Enter your Bank Account Type ('c' for Current,'s' for Savings): ");
                accountTypeChoice = Console.ReadLine();

                switch (accountTypeChoice)
                {
                    case "c":
                        {
                            accountType = "Current";
                            break;
                        }
                    case "s":
                        {
                            accountType = "Savings";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(ConstantMessages.Messages.wrongChoice);
                            Environment.Exit(0);
                            break;
                        }
                }

                Console.Write("Enter PAN Number: ");
                panNumber = Console.ReadLine();
                if (PANCardValidate(panNumber) == true)
                {
                    Console.WriteLine("PAN Card Number Invalid...");
                    Environment.Exit(0);
                }

                //Address

                Console.WriteLine("Enter your Permanent Address: ");
                permAddress = Console.ReadLine();

                Console.Write("Is your Communication Address same as Permanent Address? (yes/no or y/n): ");
                sameAddressChoice = Console.ReadLine();

                if (sameAddressChoice == "yes" || sameAddressChoice == "y")
                {
                    commAddress = permAddress;
                }
                else if (sameAddressChoice == "no" || sameAddressChoice == "n")
                {
                    Console.Write("Enter your Communication Address: ");
                    commAddress = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(ConstantMessages.Messages.wrongChoice);
                    Environment.Exit(0);
                }

                // Credit Card

                Console.Write("Do you want a Credit Card (yes/no or y/n): ");
                creditCardChoice = Console.ReadLine();

                bool creditCardEligible = true;

                if (creditCardChoice == "yes" || creditCardChoice == "y")
                {
                    Console.Write("What is your Monthly Income Amount?: ");
                    monthlyIncome = Convert.ToInt32(Console.ReadLine());

                    if (monthlyIncome >= 0 && monthlyIncome < 20000)
                    {
                        Console.WriteLine("Sorry, you are not eligible for a Credit Card.");
                        creditCardEligible = false;
                        //break;
                    }
                    else if (monthlyIncome >= 20000 && monthlyIncome < 40000)
                    {
                        Console.WriteLine("Congrats, you are eligible for a Silver Credit Card");
                        creditCardType = creditCardTypes[0];
                    }
                    else if (monthlyIncome >= 40000 && monthlyIncome < 70000)
                    {
                        Console.WriteLine("Congrats, you are eligible for Silver, Gold Credit Cards");
                        Console.Write("Press 1 for Silver, 2 for Gold Credit Card: ");
                        creditCardTypeChoice = Convert.ToInt16(Console.ReadLine());
                        switch (creditCardTypeChoice)
                        {
                            case 1:
                                creditCardType = creditCardTypes[0];
                                break;

                            case 2:
                                creditCardType = creditCardTypes[1];
                                break;
                        }
                    }
                    else if (monthlyIncome >= 70000 && monthlyIncome < 300000)
                    {
                        Console.WriteLine("Congrats, you are eligible for Silver, Gold and Platinum Credit Cards");
                        Console.Write("Press 1 for Silver, 2 for Gold Credit Card, 3 for Platinum: ");
                        creditCardTypeChoice = Convert.ToInt16(Console.ReadLine());
                        switch (creditCardTypeChoice)
                        {
                            case 1:
                                creditCardType = creditCardTypes[0];
                                break;

                            case 2:
                                creditCardType = creditCardTypes[1];
                                break;

                            case 3:
                                creditCardType = creditCardTypes[2];
                                break;
                        }
                    }
                    else if (monthlyIncome < 0)
                    {
                        Console.WriteLine(ConstantMessages.Messages.wrongChoice);
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Amount higher than Average. Please approach a Manager for Benefits");

                    }

                    //Generating Credit Card Number

                    //accountCounter+=1;
                    if (creditCardEligible == true)
                    {
                        bool flagCreditCard = true;
                        while (flagCreditCard == true)
                        {
                            //Console.WriteLine("Inside While loop");
                            for (int i = 0; i < 4; i++)
                            {
                                Random rnd = new Random();
                                int num = rnd.Next(1000, 10000);
                                string parsedNum = num.ToString();
                                creditCardNumber += parsedNum;
                            }
                            //Console.WriteLine("before for " + flag);

                            for (int i = 0; i < accountCounter; i++)
                            {
                                //Console.WriteLine("Inside for " + flag);
                                if (String.Equals(existingCreditCardNumbers[i], creditCardNumber) == false)
                                {
                                    flagCreditCard = false;
                                    //Console.WriteLine("Inside if " + flag);
                                    existingCreditCardNumbers[accountCounter] = creditCardNumber;
                                    break;
                                }
                            }

                            if (flagCreditCard == false)
                                break;

                        }
                    }

                }


                else if (creditCardChoice == "no" || creditCardChoice == "n")
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(ConstantMessages.Messages.wrongChoice);
                    Environment.Exit(0);
                }

                //Generating Account Number

                bool flagAccountNumber = true;
                while (flagAccountNumber == true)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Random rnd = new Random();
                        int num = rnd.Next(1000000, 10000000);
                        string parsedNum = num.ToString();
                        accountNumber += parsedNum;
                    }

                    for (int i = 0; i < accountCounter; i++)
                    {
                        if (String.Equals(existingAccountNumbers[i], accountNumber) == false)
                        {
                            flagAccountNumber = false;
                            existingAccountNumbers[accountCounter] = accountNumber;
                            break;
                        }
                    }

                    if (flagAccountNumber == false)
                        break;

                }

                //Generating Debit Card Number

                bool flagDebitCard = true;
                while (flagDebitCard == true)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Random rnd = new Random();
                        int num = rnd.Next(10000000, 100000000);
                        string parsedNum = num.ToString();
                        debitCardNumber += parsedNum;
                    }

                    for (int i = 0; i < accountCounter; i++)
                    {
                        if (String.Equals(existingDebitCardNumbers[i], debitCardNumber) == false)
                        {
                            flagDebitCard = false;
                            existingDebitCardNumbers[accountCounter] = debitCardNumber;
                            break;
                        }
                    }

                    if (flagDebitCard == false)
                        break;

                }


                Console.WriteLine();
                Console.WriteLine("First Name is: " + firstName);
                Console.WriteLine("Last Name is: " + lastName);
                Console.WriteLine("Gender is: " + gender);
                Console.WriteLine("Email is: " + email);
                Console.WriteLine("Date of Birth is: " + dob);
                Console.WriteLine("Contact Number is: " + contact);
                if (maritalStatus == "yes" || maritalStatus == "y")
                    Console.WriteLine("Marital Status is: Married");
                else Console.WriteLine("Marital Status is: Unmarried");

                Console.WriteLine("First Name of Spouse is: " + spouseFirstName);
                Console.WriteLine("Last Name of Spouse is: " + spouseLastName);

                Console.WriteLine("Credit Card No.: " + creditCardNumber);
                Console.WriteLine("Account Number is: " + accountNumber);
                Console.WriteLine("Debit Card Number is: " + debitCardNumber);


                Console.Write("Create Another Account?: (yes/no or y/n)");
                string createAnotherAccountChoice;
                createAnotherAccountChoice = Console.ReadLine();

                if (createAnotherAccountChoice == "yes" || createAnotherAccountChoice == "y" || createAnotherAccountChoice == "Y")
                {
                    choice = "yes";
                }
                else if (createAnotherAccountChoice == "no" || createAnotherAccountChoice == "n")
                {
                    choice = "no";
                }
                else
                {
                    Console.WriteLine(ConstantMessages.Messages.wrongChoice);
                    Environment.Exit(0);
                }

            }


        }
        
    }
}
