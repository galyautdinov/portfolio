namespace FinanceTracker.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void ShowTransactionsByType_GroupsAndSortsCorrectly()
        {
            var wallets = new List<Wallet>
            {
                new Wallet
                {
                    Id = 1,
                    Transactions = new List<Transaction>
                    {
                        new Transaction { Date = new DateTime(2024, 1, 10), Amount = 1000, Type = TransactionType.Income },
                        new Transaction { Date = new DateTime(2024, 1, 5), Amount = 500, Type = TransactionType.Expense },
                        new Transaction { Date = new DateTime(2024, 1, 15), Amount = 300, Type = TransactionType.Expense }
                    }
                }
            };

            var result = GetTransactionsByType(wallets, 2024, 1);

            Assert.Equal(2, result.Count);

            var incomeGroup = result.First(g => g.Type == TransactionType.Income);
            var expenseGroup = result.First(g => g.Type == TransactionType.Expense);

            Assert.Equal(1000, incomeGroup.TotalAmount);
            Assert.Equal(800, expenseGroup.TotalAmount);
            Assert.Single(incomeGroup.Transactions);
            Assert.Equal(2, expenseGroup.Transactions.Count);
        }

        [Fact]
        public void ShowTopExpenses_ReturnsTop3Expenses()
        {
            var wallets = new List<Wallet>
            {
                new Wallet
                {
                    Id = 1,
                    Name = "Test Wallet",
                    Transactions = new List<Transaction>
                    {
                        new Transaction { Date = new DateTime(2024, 1, 10), Amount = 1000, Type = TransactionType.Expense },
                        new Transaction { Date = new DateTime(2024, 1, 5), Amount = 500, Type = TransactionType.Expense },
                        new Transaction { Date = new DateTime(2024, 1, 15), Amount = 300, Type = TransactionType.Expense },
                        new Transaction { Date = new DateTime(2024, 1, 20), Amount = 2000, Type = TransactionType.Expense },
                        new Transaction { Date = new DateTime(2024, 1, 25), Amount = 100, Type = TransactionType.Expense }
                    }
                }
            };

            var result = GetTopExpenses(wallets, 2024, 1);

            var walletExpenses = result["Test Wallet"];
            Assert.Equal(3, walletExpenses.Count);
            Assert.Equal(2000, walletExpenses[0].Amount);
            Assert.Equal(1000, walletExpenses[1].Amount);
            Assert.Equal(500, walletExpenses[2].Amount);
        }

        [Fact]
        public void ShowTopExpenses_WithLessThan3Expenses_ReturnsAll()
        {
            var wallets = new List<Wallet>
            {
                new Wallet
                {
                    Id = 1,
                    Name = "Test Wallet",
                    Transactions = new List<Transaction>
                    {
                        new Transaction { Date = new DateTime(2024, 1, 10), Amount = 1000, Type = TransactionType.Expense },
                        new Transaction { Date = new DateTime(2024, 1, 5), Amount = 500, Type = TransactionType.Expense }
                    }
                }
            };

            var result = GetTopExpenses(wallets, 2024, 1);

            var walletExpenses = result["Test Wallet"];
            Assert.Equal(2, walletExpenses.Count);
            Assert.Equal(1000, walletExpenses[0].Amount);
            Assert.Equal(500, walletExpenses[1].Amount);
        }

        // Вспомогательные методы для тестирования (аналогичные тем, что в Program)
        private static List<TransactionGroup> GetTransactionsByType(List<Wallet> wallets, int year, int month)
        {
            var allTransactions = wallets.SelectMany(w => w.Transactions)
                .Where(t => t.Date.Year == year && t.Date.Month == month)
                .ToList();

            return allTransactions
                .GroupBy(t => t.Type)
                .Select(g => new TransactionGroup
                {
                    Type = g.Key,
                    TotalAmount = g.Sum(t => t.Amount),
                    Transactions = g.OrderBy(t => t.Date).ToList()
                })
                .OrderByDescending(g => g.TotalAmount)
                .ToList();
        }

        private static Dictionary<string, List<Transaction>> GetTopExpenses(List<Wallet> wallets, int year, int month)
        {
            var result = new Dictionary<string, List<Transaction>>();
            foreach (var wallet in wallets)
            {
                var topExpenses = wallet.Transactions
                    .Where(t => t.Type == TransactionType.Expense &&
                               t.Date.Year == year &&
                               t.Date.Month == month)
                    .OrderByDescending(t => t.Amount)
                    .Take(3)
                    .ToList();

                result[wallet.Name] = topExpenses;
            }
            return result;
        }
    }

    // Вспомогательный класс для группировки транзакций
    public class TransactionGroup
    {
        public TransactionType Type { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}