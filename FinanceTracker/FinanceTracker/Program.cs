namespace FinanceTracker
{
    class Program
    {
        static List<Wallet> wallets = new List<Wallet>();       
        static List<Transaction> transactions = new List<Transaction>();
        static Random random = new Random();

        static string[] incomeDescriptions = new[]
        {
            "Зарплата", "Премия", "Дивиденды", "Фриланс", "Продажа вещей",
            "Возврат долга", "Инвестиционный доход", "Подарок", "Бонус", "Проценты по вкладу"
        };

        static string[] expenseDescriptions = new[]
        {
            "Продукты", "Коммунальные услуги", "Транспорт", "Одежда", "Развлечения",
            "Рестораны", "Путешествия", "Здоровье", "Образование", "Техника",
            "Книги", "Подарки", "Ремонт", "Связь", "Страхование",
            "Такси", "Кино", "Фитнес", "Кофе", "Супермаркет"
        };

        static void Main(string[] args)
        {
            GenerateTestData();

            Console.Write("Введите год: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Введите месяц (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("\n=== Транзакции по типам ===");
            ShowTransactionsByType(year, month);

            Console.WriteLine("\n=== Топ-3 траты по кошелькам ===");
            ShowTopExpenses(year, month);

            Console.ReadLine();
        }

        static void GenerateTestData()
        {
            // Создаем 3 кошелька
            wallets.Add(new Wallet { Id = 0, Name = "Основной", Currency = "RUB", InitialBalance = 0 });
            wallets.Add(new Wallet { Id = 1, Name = "Запасной", Currency = "RUB", InitialBalance = 0 });
            wallets.Add(new Wallet { Id = 2, Name = "Инвестиционный", Currency = "RUB", InitialBalance = 0 });

            int transactionId = 0;
            DateTime startDate = new DateTime(2020, 9, 1);
            DateTime endDate = new DateTime(2025, 9, 30);

            // Проходим по всем месяцам в диапазоне
            for (DateTime date = startDate; date <= endDate; date = date.AddMonths(1))
            {
                foreach (var wallet in wallets)
                {
                    // Income транзакция в месяце
                    transactions.Add(new Transaction
                    {
                        Id = transactionId++,
                        WalletId = wallet.Id,
                        Date = new DateTime(date.Year, date.Month, random.Next(1, 28)),
                        Amount = (decimal)(random.Next(5000, 10000)),
                        Type = TransactionType.Income,
                        Description = incomeDescriptions[random.Next(incomeDescriptions.Length)]
                    });

                    // Expense транзакции в месяце
                    for (int i = 0; i < 3; i++)
                    {
                        transactions.Add(new Transaction
                        {
                            Id = transactionId++,
                            WalletId = wallet.Id,
                            Date = new DateTime(date.Year, date.Month, random.Next(1, 28)),
                            Amount = (decimal)(random.Next(100, 5000)),
                            Type = TransactionType.Expense,
                            Description = expenseDescriptions[random.Next(expenseDescriptions.Length)]
                        });
                    }
                }
            }

            // Добавляем транзакции в кошельки
            foreach (var transaction in transactions)
            {
                var wallet = wallets.First(w => w.Id == transaction.WalletId);
                wallet.Transactions.Add(transaction);
            }
        }

        static void ShowTransactionsByType(int year, int month)
        {
            var allTransactions = wallets.SelectMany(w => w.Transactions)
                .Where(t => t.Date.Year == year && t.Date.Month == month)
                .ToList();

            var groupedTransactions = allTransactions
                .GroupBy(t => t.Type)
                .Select(g => new
                {
                    Type = g.Key,
                    TotalAmount = g.Sum(t => t.Amount),
                    Transactions = g.OrderBy(t => t.Date).ToList()
                })
                .OrderByDescending(g => g.TotalAmount)
                .ToList();

            foreach (var group in groupedTransactions)
            {
                Console.WriteLine($"\n{group.Type} (Всего: {group.TotalAmount}):");

                foreach (var transaction in group.Transactions)
                {
                    Console.WriteLine($"  {transaction.Date:dd.MM.yyyy} - {transaction.Amount} - {transaction.Description}");
                }
            }
        }

        static void ShowTopExpenses(int year, int month)
        {
            foreach (var wallet in wallets)
            {
                var topExpenses = wallet.Transactions
                    .Where(t => t.Type == TransactionType.Expense &&
                               t.Date.Year == year &&
                               t.Date.Month == month)
                    .OrderByDescending(t => t.Amount)
                    .Take(3)
                    .ToList();

                Console.WriteLine($"\n{wallet.Name}:");

                if (topExpenses.Any())
                {
                    foreach (var expense in topExpenses)
                    {
                        Console.WriteLine($"  {expense.Amount} - {expense.Description} ({expense.Date:dd.MM.yyyy})");
                    }
                }
                else
                {
                    Console.WriteLine("  Нет трат за этот месяц");
                }
            }
        }
    }
}