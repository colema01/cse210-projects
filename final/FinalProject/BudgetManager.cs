using PersonalBudgetManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PersonalBudgetManager.Services
{
    public class BudgetManager
    {
        private const string FilePath = "transactions.txt";
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
            SaveTransactionToFile(transaction);
        }

        private void SaveTransactionToFile(Transaction transaction)
        {
            var line = $"{transaction.Date:yyyy-MM-dd},{transaction.Amount},{transaction.Description},{FindCategoryName(transaction)}";
            File.AppendAllText(FilePath, line + Environment.NewLine);
        }

        private string FindCategoryName(Transaction transaction)
        {
            foreach (var category in Categories)
            {
                if (category.Transactions.Contains(transaction))
                {
                    return category.Name;
                }
            }
            return "Uncategorized";
        }

        public string GenerateReport()
        {
            LoadTransactionsFromFile();

            StringBuilder report = new StringBuilder();
            report.AppendLine("Budget Report");
            report.AppendLine("=============");

            foreach (var category in Categories)
            {
                report.AppendLine($"Category: {category.Name}");
                double total = category.Transactions.Sum(t => t.Amount);
                report.AppendLine($"Total: {total:C2}");
                report.AppendLine("Transactions:");
                foreach (var transaction in category.Transactions)
                {
                    report.AppendLine($" - {transaction.Date.ToShortDateString()}: {transaction.Description} - {transaction.Amount:C2}");
                }
                report.AppendLine();
            }

            double grandTotal = Transactions.Sum(t => t.Amount);
            report.AppendLine($"Grand Total: {grandTotal:C2}");

            return report.ToString();
        }

        private void LoadTransactionsFromFile()
        {
            if (!File.Exists(FilePath))
                return;

            Transactions.Clear();
            Categories.Clear();

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    var transaction = new Transaction
                    {
                        Date = Convert.ToDateTime(parts[0]),
                        Amount = Convert.ToDouble(parts[1]),
                        Description = parts[2]
                    };

                    var categoryName = parts[3];
                    var category = Categories.FirstOrDefault(c => c.Name == categoryName);
                    if (category == null)
                    {
                        category = new Category { Name = categoryName };
                        Categories.Add(category);
                    }

                    category.AddTransaction(transaction);
                    Transactions.Add(transaction);
                }
            }
        }
    }
}

