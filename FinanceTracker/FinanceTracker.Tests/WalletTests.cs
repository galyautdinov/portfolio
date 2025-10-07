namespace FinanceTracker.Tests
{
    public class WalletTests
    {
        [Fact]
        public void CurrentBalance_WithNoTransactions_ReturnsInitialBalance()
        {
            var wallet = new Wallet { InitialBalance = 1000 };

            var result = wallet.CurrentBalance;

            Assert.Equal(1000, result);
        }

        [Fact]
        public void CurrentBalance_WithIncomeTransactions_CalculatesCorrectly()
        {
            var wallet = new Wallet { InitialBalance = 1000 };
            wallet.Transactions.Add(new Transaction
            {
                Amount = 500,
                Type = TransactionType.Income
            });

            var result = wallet.CurrentBalance;

            Assert.Equal(1500, result);
        }

        [Fact]
        public void CurrentBalance_WithExpenseTransactions_CalculatesCorrectly()
        {
            var wallet = new Wallet { InitialBalance = 1000 };
            wallet.Transactions.Add(new Transaction
            {
                Amount = 300,
                Type = TransactionType.Expense
            });

            var result = wallet.CurrentBalance;

            Assert.Equal(700, result);
        }

        [Fact]
        public void CurrentBalance_WithMixedTransactions_CalculatesCorrectly()
        {
            var wallet = new Wallet { InitialBalance = 1000 };
            wallet.Transactions.AddRange(new[]
            {
                new Transaction { Amount = 500, Type = TransactionType.Income },
                new Transaction { Amount = 300, Type = TransactionType.Expense },
                new Transaction { Amount = 200, Type = TransactionType.Income }
            });

            var result = wallet.CurrentBalance;

            Assert.Equal(1400, result);
        }

        [Fact]
        public void AddTransaction_WithSufficientBalance_ReturnsTrue()
        {
            var wallet = new Wallet { InitialBalance = 1000 };
            var transaction = new Transaction
            {
                Amount = 500,
                Type = TransactionType.Expense
            };

            var result = wallet.AddTransaction(transaction);

            Assert.True(result);
            Assert.Single(wallet.Transactions);
        }

        [Fact]
        public void AddTransaction_WithInsufficientBalance_ReturnsFalse()
        {
            var wallet = new Wallet { InitialBalance = 100 };
            var transaction = new Transaction
            {
                Amount = 500,
                Type = TransactionType.Expense
            };

            var result = wallet.AddTransaction(transaction);

            Assert.False(result);
            Assert.Empty(wallet.Transactions);
        }

        [Fact]
        public void AddTransaction_WithIncome_AlwaysReturnsTrue()
        {
            var wallet = new Wallet { InitialBalance = 100 };
            var transaction = new Transaction
            {
                Amount = 1000,
                Type = TransactionType.Income
            };

            var result = wallet.AddTransaction(transaction);

            Assert.True(result);
            Assert.Single(wallet.Transactions);
        }

        [Fact]
        public void GetMonthlyIncome_ReturnsCorrectSum()
        {
            var wallet = new Wallet();
            wallet.Transactions.AddRange(new[]
            {
                new Transaction { Date = new DateTime(2024, 1, 10), Amount = 1000, Type = TransactionType.Income },
                new Transaction { Date = new DateTime(2024, 1, 20), Amount = 2000, Type = TransactionType.Income },
                new Transaction { Date = new DateTime(2024, 2, 10), Amount = 3000, Type = TransactionType.Income },
                new Transaction { Date = new DateTime(2024, 1, 15), Amount = 500, Type = TransactionType.Expense }
            });

            var result = wallet.GetMonthlyIncome(2024, 1);

            Assert.Equal(3000, result);
        }

        [Fact]
        public void GetMonthlyExpense_ReturnsCorrectSum()
        {
            var wallet = new Wallet();
            wallet.Transactions.AddRange(new[]
            {
                new Transaction { Date = new DateTime(2024, 1, 10), Amount = 1000, Type = TransactionType.Expense },
                new Transaction { Date = new DateTime(2024, 1, 20), Amount = 2000, Type = TransactionType.Expense },
                new Transaction { Date = new DateTime(2024, 2, 10), Amount = 3000, Type = TransactionType.Expense },
                new Transaction { Date = new DateTime(2024, 1, 15), Amount = 500, Type = TransactionType.Income }
            });

            var result = wallet.GetMonthlyExpense(2024, 1);

            Assert.Equal(3000, result);
        }

        [Fact]
        public void GetMonthlyIncome_WithNoTransactions_ReturnsZero()
        {
            var wallet = new Wallet();

            var result = wallet.GetMonthlyIncome(2024, 1);

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetMonthlyExpense_WithNoTransactions_ReturnsZero()
        {
            var wallet = new Wallet();

            var result = wallet.GetMonthlyExpense(2024, 1);

            Assert.Equal(0, result);
        }
    }
}