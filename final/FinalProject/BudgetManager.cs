using PersonalBudgetManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalBudgetManager.Services
{
    public class BudgetManager
    {
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public string GenerateReport()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("Budget Report");
            report.AppendLine("--------------");

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
    }
}
