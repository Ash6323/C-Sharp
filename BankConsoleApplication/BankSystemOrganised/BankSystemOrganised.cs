using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using DepositWithdrawalNamespace;

namespace InnerSystem
{
    internal class BankSystem : InitialisingDisplayingMethod
    {
        internal void RunBankSystem()
        {
            //CardAndAccountNumberGenerator obj = new CardAndAccountNumberGenerator();
            //while (choice == "yes" || choice == "y" || choice == "Y"|| choice == "YES" || choice == "Yes")
            //{
            accountCounter += 1;
            Console.WriteLine("* * * * Welcome to IX Bank * * * *\n");
            Console.WriteLine("Enter Your Personal Details Below:");

            //Personal Details
            while (true)
            {
                Console.Write("Enter First Name: ");
                firstName = Console.ReadLine();
                if (ValidationMethods.NameValidate(firstName))
                    Console.WriteLine(ConstantMessagesForOutput.Messages.invalidName);
                else
                    break;
            }

            while (true)
            {
                Console.Write("Enter Last Name: ");
                lastName = Console.ReadLine();
                if (ValidationMethods.NameValidate(lastName))
                    Console.WriteLine(ConstantMessagesForOutput.Messages.invalidName);
                else
                    break;
            }

            while (true)
            {
                Console.Write("Enter Gender (m/f/Male/Female/Other): ");
                gender = Console.ReadLine();
                if (ValidationMethods.GenderValidate(gender))
                    Console.WriteLine("Entered Gender is Invalid...Please Try Again");
                else
                    break;
            }

            while (true)
            {
                Console.Write("Enter Email Address: ");
                email = Console.ReadLine();
                if (ValidationMethods.EmailValidate(email))
                    Console.WriteLine("Entered Email is Invalid...Please Try Again.");
                else
                    break;
            }

            while (true)
            {
                Console.Write("Enter Date of Birth: ");
                dob = Console.ReadLine();
                if (ValidationMethods.DOBValidate(dob))
                    Console.WriteLine("Entered Date of Birth is invalid...Please Try Again.");
                else
                    break;
            }

            while (true)
            {
                Console.Write("Enter Contact Number: ");
                contact = Console.ReadLine();
                if (ValidationMethods.ContactValidate(contact))
                    Console.WriteLine("Entered Contact Number is Invalid...Please Try Again.");
                else
                    break;
            }

            //Family Details 
            while (true)
            {
                Console.Write("Are You Married? (yes/y/no/n, 'd' if Divorcee): ");
                maritalStatus = Console.ReadLine();
                if (ValidationMethods.MaritalStatusValidate(maritalStatus))
                {
                    Console.WriteLine("Entered Marital Status is Invalid...Please Enter Again.");
                }              
                else
                {
                    if (maritalStatus == "yes" || maritalStatus == "y")
                    {
                        if (maritalStatus == "d" || maritalStatus == "D")
                        {
                            goto LabelForDivorcee;
                        }
                        spousePresent = true;
                        while (true)
                        {
                            Console.Write("Enter First Name of Spouse: ");
                            spouseFirstName = Console.ReadLine();
                            if (ValidationMethods.NameValidate(spouseFirstName))
                                Console.WriteLine(ConstantMessagesForOutput.Messages.invalidName);
                            else
                                break;
                        }
                        while (true)
                        {
                            Console.Write("Enter Last Name of Spouse: ");
                            spouseLastName = Console.ReadLine();
                            if (ValidationMethods.NameValidate(spouseLastName))
                                Console.WriteLine(ConstantMessagesForOutput.Messages.invalidName);
                            else
                                break;
                        }
                        while (true)
                        {
                            Console.Write("Enter Contact Number of Spouse: ");
                            spouseContact = Console.ReadLine();
                            if (ValidationMethods.ContactValidate(spouseContact))
                                Console.WriteLine("Contact Number Invalid...");
                            else
                                break;
                        }
                        LabelForDivorcee:
                        //Children
                        while (true)
                        {
                            Console.Write("Do you have Children? (yes/no or y/n): ");
                            childrenStatus = Console.ReadLine();

                            if (childrenStatus == "yes" || childrenStatus == "y" || childrenStatus == "Yes" || childrenStatus == "Y")
                            {
                                childrenPresent = true;
                                Console.Write("How many children do you have?: ");
                                childCount = Convert.ToInt32(Console.ReadLine());
                                childrenName = new String[childCount];
                                for (int i = 0; i < childCount; i++)
                                {
                                    while (true)
                                    {
                                        Console.Write($"Enter Child {i + 1}'s Name: ");
                                        childrenName[i] = Console.ReadLine();
                                        if (ValidationMethods.NameValidate(childrenName[i]))
                                            Console.WriteLine(ConstantMessagesForOutput.Messages.invalidName);
                                        else
                                            break;
                                    }

                                }
                            }
                            else if (childrenStatus == "no" || childrenStatus == "n" || childrenStatus == "N" || childrenStatus == "NO")
                            {
                                Console.WriteLine();
                            }
                            else
                                Console.WriteLine(ConstantMessagesForOutput.Messages.wrongChoice);
                            break;
                        }
                    }
                    else if (maritalStatus == "no" || maritalStatus == "n")
                    {
                        Console.WriteLine();
                    }
                    break;
                }
            }

            //Account Type
            while (true)
            {
                Console.Write("Enter your Bank Account Type ('c' for Current,'s' for Savings): ");
                accountTypeChoice = Console.ReadLine().ToLower();
                switch (accountTypeChoice)
                {
                    case "c":
                        {
                            accountType = "Current";
                            goto fromHere;
                        }
                    case "s":
                        {
                            accountType = "Savings";
                            goto fromHere;
                        }
                }
                Console.WriteLine(ConstantMessagesForOutput.Messages.wrongChoice);
            }

        fromHere:
            while (true)
            {
                Console.Write("Enter PAN Number: ");
                panNumber = Console.ReadLine();
                if (ValidationMethods.PANCardValidate(panNumber))
                    Console.WriteLine("PAN Card Number Invalid...Please Try Again.");
                else
                    break;
            }
            //Address
            Console.Write("Enter your Permanent Address: ");
            permAddress = Console.ReadLine();

            while (true)
            {
                Console.Write("Is your Communication Address same as Permanent Address? (yes/no or y/n): ");
                sameAddressChoice = Console.ReadLine();
                if (sameAddressChoice == "yes" || sameAddressChoice == "y" || sameAddressChoice == "Y" || sameAddressChoice == "YES")
                {
                    commAddress = permAddress;
                    break;
                }
                else if (sameAddressChoice == "no" || sameAddressChoice == "n" || sameAddressChoice == "N" || sameAddressChoice == "NO")
                {
                    Console.Write("Enter your Communication Address: ");
                    commAddress = Console.ReadLine();
                    break;
                }
                else
                    Console.WriteLine(ConstantMessagesForOutput.Messages.wrongChoice);
            }
            // Credit Card
            bool creditCardEligible = true;
            Console.Write("Do you want a Credit Card (yes/no or y/n): ");
            creditCardChoice = Console.ReadLine();

            if (creditCardChoice == "yes" || creditCardChoice == "y")
            {
                while (true)
                {
                    Console.Write("What is your Monthly Income Amount?: ");
                    monthlyIncome = Convert.ToInt32(Console.ReadLine());
                    if (monthlyIncome >= 0 && monthlyIncome < 20000)
                    {
                        Console.WriteLine("Sorry, you are not eligible for a Credit Card.");
                        creditCardEligible = false;
                        break;
                    }
                    else if (monthlyIncome >= 20000 && monthlyIncome < 40000)
                    {
                        Console.WriteLine("Congrats, you are eligible for a Silver Credit Card");
                        creditCardType = creditCardTypes[0];
                        break;
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
                        break;
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
                        break;
                    }
                    else if (monthlyIncome < 0)
                    {
                        Console.WriteLine(ConstantMessagesForOutput.Messages.wrongChoice);
                    }
                    else
                    {
                        Console.WriteLine("Amount higher than Average. Please approach a Manager for more Benefits");
                        creditCardType = "Executive";
                        break;
                    }
                }
                //Generating Credit Card Number
                if (creditCardEligible)
                {
                    bool flagCreditCard = true;
                    while (flagCreditCard)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Random rnd = new Random();
                            int num = rnd.Next(1000, 10000);
                            string parsedNum = num.ToString();
                            creditCardNumber += parsedNum;
                        }
                        for (int i = 0; i < accountCounter; i++)
                        {
                            if (String.Equals(existingCreditCardNumbers[i], creditCardNumber) == false)
                            {
                                flagCreditCard = false;
                                existingCreditCardNumbers[accountCounter] = creditCardNumber;
                                break;
                            }
                        }
                        if (flagCreditCard == false)
                            break;
                    }
                    //creditCardNumber = obj.CreditCardGenerator();
                    //Console.WriteLine("Hello" +creditCardNumber);
                }
            }
            else if (creditCardChoice == "no" || creditCardChoice == "n")
                creditCardNumber = creditCardType = "N.A.";
            else
            {
                Console.WriteLine(ConstantMessagesForOutput.Messages.wrongChoice);
                Environment.Exit(0);
            }
            //Generating Account Number
            bool flagAccountNumber = true;
            while (flagAccountNumber)
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
            while (flagDebitCard)
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

            DisplayAccountInformation();

            DepositAndWithdrawal depositAndWithdrawal = new DepositAndWithdrawal();

            while (true)
            {
                Console.WriteLine("\n* * * * Menu * * * *\n1. Deposit\n2. Withdraw\n3. Check Balance\n4. Exit");
                Console.Write("\nWhat do you want to do?: ");
                //Double.TryParse(Console.ReadLine(), out depositOrWithdrawChoice);
                depositOrWithdrawChoice = Convert.ToInt32(Console.ReadLine());
                switch (depositOrWithdrawChoice)
                {
                    case 1:
                        {
                            try
                            {
                                depositAndWithdrawal.DepositAmount(accountNumber);
                            }
                            catch (DepositOrWithdrawalFailedException e)
                            {
                                Console.WriteLine("\n" + e.Message);
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                depositAndWithdrawal.WithdrawAmount(accountNumber);
                            }
                            catch (DepositOrWithdrawalFailedException e)
                            {
                                Console.WriteLine("\n" + e.Message);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\nBalance in Account is: " + depositAndWithdrawal.BalanceInAccount());
                            break;
                        }
                    case 4:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        Console.WriteLine(ConstantMessagesForOutput.Messages.wrongChoice);
                        break;
                }
            }

            //while (true)
            //{
            //    Console.Write("\nCreate Another Account? (yes/no or y/n): ");
            //    string createAnotherAccountChoice;
            //    createAnotherAccountChoice = Console.ReadLine();
            //    if (createAnotherAccountChoice == "yes" || createAnotherAccountChoice == "y" || createAnotherAccountChoice == "Y" || createAnotherAccountChoice == "YES")
            //    {
            //        choice = "yes";
            //        break;
            //    }
            //    else if (createAnotherAccountChoice == "no" || createAnotherAccountChoice == "n" || createAnotherAccountChoice == "N" || createAnotherAccountChoice == "NO")
            //        Environment.Exit(0);
            //    else
            //        Console.WriteLine(ConstantMessagesForOutput.Messages.wrongChoice);
            //}

            //}
        }    
    }
}
