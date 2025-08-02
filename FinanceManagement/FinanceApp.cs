using FinanceManagement.Models;
using FinanceManagement.Processors;

namespace FinanceManagement
{
    public class FinanceApp
    {
        private readonly List<Transaction> _transactions = new();

        public void Run()
        {
            // Create account
            var savings = new SavingsAccount("SAV-12345", 1000);
            Console.WriteLine($"Initial balance: {savings.Balance:C}");

            // Create transactions
            var transactions = new List<Transaction>
            {
                new Transaction(1, DateTime.Now, 150.50m, "Groceries"),
                new Transaction(2, DateTime.Now, 75.25m, "Utilities"),
                new Transaction(3, DateTime.Now, 200.00m, "Entertainment")
            };

            // Create processors
            ITransactionProcessor mobileProcessor = new MobileMoneyProcessor();
            ITransactionProcessor bankProcessor = new BankTransferProcessor();
            ITransactionProcessor cryptoProcessor = new CryptoWalletProcessor();

            // Process transactions
            mobileProcessor.Process(transactions[0]);
            bankProcessor.Process(transactions[1]);
            cryptoProcessor.Process(transactions[2]);

            // Apply to account
            foreach (var t in transactions)
            {
                savings.ApplyTransaction(t);
                _transactions.Add(t);
            }
        }
    }
}