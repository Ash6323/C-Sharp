using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EmployeeSystemNamespace
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
            if (Regex.Match(str, "(?:y|n|yes|no|Yes|No|YES|NO|Y|N)$").Success)
                return false;
            else return true;
        }
        protected static bool PANCardValidate(string str)
        {
            if (Regex.Match(str, "[A-Z]{5}[0-9]{4}[A-Z]{1}").Success)
                return false;
            else return true;
        }

        protected double PaymentCutFromBasic(double amount)
        {
            if (amount >= 0 && amount < 20000)
            {
                amount = amount * 0.95;
                //break;
            }
            else if (amount >= 20000 && amount < 40000)
            {
                amount = amount * 0.90;
            }
            else if (amount >= 40000)
            {
                amount = amount * 0.80;
            }


            return amount;
        }

        protected double PaymentCutForBenefits(double amount, int choice)
        {
            if(choice==1)
            {
                amount = amount - 2000;
            }
            else if(choice==2)
            {
                amount = amount - 3000;
            }
            else if(choice==3)
            {
                amount = amount - 0;
            }
            else
            {
                Console.WriteLine(ConstantMessages.Messages.wrongInput);
                Environment.Exit(0);
            }

            return amount;

        }

        protected string EmployeeIdGeneration()
        {
                string employeeID="";

                Random rnd = new Random();
                int num = rnd.Next(1000, 10000);
                string parsedNum = num.ToString();
                employeeID += parsedNum;
            
            return employeeID; 
        }

    }

    public static class ConstantMessages
    {
        public static class Messages
        {
            public const string invalidName = "Name Invalid...";
            public const string wrongInput = "Wrong Input!! Exiting...";
        }
    }

    internal class EmployeeSystem : Processes
    {
        string firstName, lastName, gender, email, dob, contact, maritalStatus, selectMaritalStatus;
        string panNumber, designation, employeeID="";
        double monthlyPayment, paymentAfterCuts;
        int benefitsChoice;


        internal void run()
        {
            Console.WriteLine("* * * * Employee Registration System * * * *\n");
            Console.WriteLine("Enter the Personal Details of the Employee Below:");

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
            selectMaritalStatus = Console.ReadLine();
            if (MaritalStatusValidate(selectMaritalStatus) == true)
            {
                Console.WriteLine(ConstantMessages.Messages.wrongInput);
                Environment.Exit(0);
            }
            
            if (selectMaritalStatus == "yes" || selectMaritalStatus == "y"
                || selectMaritalStatus == "Yes" || selectMaritalStatus == "YES" || selectMaritalStatus == "Y")
            {
                maritalStatus = "Married";

            }
            else
            {
                maritalStatus = "Unmarried";
            }

            Console.Write("Enter the Designation of the Employee: ");
            designation = Console.ReadLine();


            Console.Write("Enter PAN Number: ");
            panNumber = Console.ReadLine();
            if (PANCardValidate(panNumber) == true)
            {
                Console.WriteLine("PAN Card Number Invalid...");
                Environment.Exit(0);
            }

            Console.Write("Enter the Monthly Payment: ");
            monthlyPayment = Convert.ToDouble(Console.ReadLine());
            if (monthlyPayment < 0 || monthlyPayment > 200000)
            {
                Console.WriteLine(ConstantMessages.Messages.wrongInput);
                Environment.Exit(0);
            }
            else
            {
                paymentAfterCuts = PaymentCutFromBasic(monthlyPayment);
            }

            Console.WriteLine("If there are additional benefits, please select: \n1. Transportation\n2. Special Healthcare Plan\n3. N.A.");
            Console.Write("Enter the Choice: ");
            benefitsChoice = Convert.ToInt16(Console.ReadLine());
            paymentAfterCuts = PaymentCutForBenefits(paymentAfterCuts, benefitsChoice);



            Console.WriteLine("\n\nBelow are the Employee Details: \n");
            Console.WriteLine("Employee First Name: "+firstName);
            Console.WriteLine("Employee Last Name: " + lastName);
            Console.WriteLine("Employee Gender: " + gender);
            Console.WriteLine("Employee Email Address: " + email);
            Console.WriteLine("Employee Date of Birth: " + dob);
            Console.WriteLine("Employee Contact Number: " + contact);
            Console.WriteLine("Employee Marital Status: " + maritalStatus);
            Console.WriteLine("Employee Designation: " + designation);
            Console.WriteLine("Employee PAN Number: " + panNumber);
            Console.WriteLine("Monthly Payment Before Cuts: " + monthlyPayment);
            Console.WriteLine("Monthly Payment After Cuts: " + paymentAfterCuts);
            Console.WriteLine("New Employee ID: " + EmployeeIdGeneration());


        }
    }

}
