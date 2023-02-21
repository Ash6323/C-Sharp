using System;
namespace DepositWithdrawalNamespace
{
    internal class DepositAndWithdrawal
    {
        static double balance = 0;
        static double totalAmountDeposited = 0;
        static double totalAmountWithdrawn = 0;
        internal void DepositAmount(string accountNumber)
        {
            double depositAmount;
            Console.WriteLine($"\nAccount Number: {accountNumber}");
            while(true)
            {
                Console.Write("Enter the Amount to be Deposited: ");
                depositAmount = Convert.ToDouble(Console.ReadLine());
                if (depositAmount < 0)
                    Console.WriteLine(ConstantMessagesForOutput.Messages.wrongChoice);
                else
                    break;
            }
            balance += depositAmount;
            totalAmountDeposited += depositAmount;
            if (totalAmountDeposited > 100000)
            {
                balance -= depositAmount;
                totalAmountDeposited -= depositAmount;
                throw new DepositOrWithdrawalFailedException("Daily Deposit Limit of Rs. 1,00,000 Exceeded");
            }
            Console.WriteLine($"Balance in Account after Depositing {depositAmount} is: Rs. {balance}");
        }
        internal void WithdrawAmount(string accountNumber)
        {
            if(balance == 0)
                throw new DepositOrWithdrawalFailedException("Not Enough Balance. Please Check the Amount.");

            double withdrawalAmount;
            Console.WriteLine($"\nAccount Number: {accountNumber}");
            while(true )
            {
                Console.Write("Enter the Amount to be Withdrawn: ");
                withdrawalAmount = Convert.ToDouble(Console.ReadLine());
                if (withdrawalAmount < 0)
                    Console.WriteLine(ConstantMessagesForOutput.Messages.wrongChoice);
                else
                    break;
            }
            balance -= withdrawalAmount;
            totalAmountWithdrawn += withdrawalAmount;
            if (totalAmountWithdrawn > 50000)
            {
                balance += withdrawalAmount;
                totalAmountWithdrawn -= withdrawalAmount;
                throw new DepositOrWithdrawalFailedException("Daily Withdrawal Limit of Rs. 50,000 Exceeded");
            }
            if (balance < 0)
            {
                balance += withdrawalAmount;
                totalAmountWithdrawn -= withdrawalAmount;
                throw new DepositOrWithdrawalFailedException("Not Enough Balance. Please Check the Amount.");
            }
            Console.WriteLine($"Balance in Account after Withdrawing {withdrawalAmount} is: Rs. {balance}");
        }
        internal double BalanceInAccount()
        {
            return balance;
        }
    }
    public class DepositOrWithdrawalFailedException : Exception
    {
    public DepositOrWithdrawalFailedException(string message)
        : base(message)
        {

        }
    }
}
