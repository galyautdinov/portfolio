namespace FinanceTracker
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal InitialBalance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public decimal CurrentBalance
        {
            get
            {
                var totalIncome = Transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount);
                var totalExpense = Transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);
                return InitialBalance + totalIncome - totalExpense;
            }
        }

        public bool AddTransaction(Transaction transaction)
        {
            if (transaction.Type == TransactionType.Expense && transaction.Amount > CurrentBalance)
            {
                return false;
            }

            Transactions.Add(transaction);
            return true;
        }

        public decimal GetMonthlyIncome(int year, int month)
        {
            return Transactions
                .Where(t => t.Date.Year == year && t.Date.Month == month && t.Type == TransactionType.Income)
                .Sum(t => t.Amount);
        }

        public decimal GetMonthlyExpense(int year, int month)
        {
            return Transactions
                .Where(t => t.Date.Year == year && t.Date.Month == month && t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);
        }
    }
}