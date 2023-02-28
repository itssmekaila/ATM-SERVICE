using System;
using System.Collections.Generic;
using System.Linq;

namespace ATMService
{
    class Program
    {
        class Records
        {
            public string AccountId;
            public string User;
            public decimal Balance;
        }

        private static List<Records> records = new List<Records>();

        private static void Main()
        {
            Console.WriteLine("***************Welcome to ATM Service*************** \n");
            Console.WriteLine("1. Create Account \n");
            Console.WriteLine("2. Log In Your Existing Account \n");
            Console.WriteLine("3. Shutdown System \n");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("Enter your Choice: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateAccount(records);
                    break;
                case "2":
                    AccountController(records);
                    break;
                case "3":
                    Console.WriteLine("All Data Has Been Erased. Goodbye.");
                    break;
            }
        }

        private static void CreateAccount(List<Records> records)
        {
            var random = new Random();
            Console.Write(" Enter your Name: ");
            var user = Console.ReadLine();

            var accountId = new string(Enumerable.Repeat("0123456789", 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            records.Add(new Records() { AccountId = accountId, User = user, Balance = 500.00m });
            Console.WriteLine("Account Created. Details: ");
            Console.WriteLine($"\tAccountId: {accountId} \n");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            // Clear The Console And Call Main Again.
            Console.Clear();
            Main();
        }


        private static void AccountController(List<Records> records)
        {
            var systemShutdown = false;
            while (!systemShutdown)
            {
                Console.WriteLine("Welcome to Bank Account!! ");
                Console.WriteLine("");
                Console.Write("Enter Bank AccountId: ");
                var input = Console.ReadLine();
                foreach (var account in records)
                {
                    if (input != null && input.Equals(account.AccountId))
                    {
                        Console.WriteLine($"Welcome {account.User}!!");
                        Console.WriteLine($"Your current Balance is: {account.Balance}");
                        var atmModeShouldClose = false;
                        while (!atmModeShouldClose)
                        {
                            Console.WriteLine("***************Welcome to ATM Service***************");
                            Console.WriteLine("Please choose from onee of the following options...\n");
                            Console.WriteLine("1. Deposit cash \n");
                            Console.WriteLine("2. Withdraw Cash \n");
                            Console.WriteLine("3. Check Balance \n");
                            Console.WriteLine("4. Quit \n");
                            Console.WriteLine("*****************************************************");
                            Console.WriteLine("Enter your Choice: ");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.Write("How much money would you like to deposit? ");
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("YOUR AMOUNT HAS BEEN DEPOSITED SUCCESSFULLY \n");
                                    if (decimal.TryParse(input, out var deposit))
                                    {
                                        account.Balance += deposit;
                                        Console.WriteLine($"Your new Balance is : {account.Balance}");
                                        break;
                                    }

                                    Console.Clear();
                                    Console.WriteLine("Please Specify Quantity For Deposit...");
                                    break;

                                case "2":
                                    Console.Write("How much your money would like to withdraw? ");
                                    input = Console.ReadLine();
                                    if (decimal.TryParse(input, out var withdraw))
                                    {
                                        if (withdraw <= account.Balance)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You're good to go! Thank you !!.");
                                            account.Balance -= withdraw;
                                            Console.WriteLine($"Your new Balance is : {account.Balance}");
                                            break;
                                        }

                                        Console.Clear();
                                        Console.WriteLine("Insufficient balance.");
                                        break;
                                    }

                                    Console.Clear();
                                    Console.WriteLine("Please Specify Quantity For Withdraw...");
                                    break;

                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Balance: {account.Balance}");
                                    break;
                                case "4":

                                    Console.Clear();
                                    Console.WriteLine("Logging out...");
                                    Console.WriteLine(" THANKS FOR USINFG ATM SERVICE. ");
                                    Console.WriteLine(" HAVE A NICE DAY! :)");
                                    atmModeShouldClose = true;
                                    break;
                                case "5":
                                    atmModeShouldClose = true;
                                    systemShutdown = true;
                                    Console.WriteLine("All Data Has Been Erased.");
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
