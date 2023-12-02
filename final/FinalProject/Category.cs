using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonalBudgetManager.Models;

namespace PersonalBudgetManager.Models
{
    public class Category
    {
        public string Name { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public string GetCategorySummary()
        {
            StringBuilder summary = new StringBuilder();
            summary.AppendLine($"Category: {Name}");
            summary.AppendLine("Transactions:");
            
            foreach (var transaction in Transactions)
            {
                summary.AppendLine($" - {transaction.Date.ToShortDateString()}: {transaction.Description} - {transaction.Amount:C2}");
            }

            double total = Transactions.Sum(t => t.Amount);
            summary.AppendLine($"Total: {total:C2}");

            return summary.ToString();
        }
    }
}

