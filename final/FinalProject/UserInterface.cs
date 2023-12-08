using PersonalBudgetManager.Models;
using PersonalBudgetManager.Services;
using System;

namespace PersonalBudgetManager.UI
{
    public class UserInterface
    {
        private readonly BudgetManager _budgetManager;

        public UserInterface(BudgetManager budgetManager)
        {
            _budgetManager = budgetManager;
        }

        public void DisplayMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nPersonal Budget Manager");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. Generate Report");
                Console.WriteLine("3. Exit");
                Console.Write("Enter option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddTransactionUI();
                        break;
                    case "2":
                        GenerateReportUI();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void AddTransactionUI()
        {
            Console.WriteLine("\nAdd Transaction");
            Console.Write("Enter amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter date (yyyy-mm-dd): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            Console.Write("Enter category name: ");
            string categoryName = Console.ReadLine();

            var category = _budgetManager.Categories.Find(c => c.Name == categoryName);
            if (category == null)
            {
                category = new Category { Name = categoryName };
                _budgetManager.Categories.Add(category);
            }

            var transaction = new Transaction
            {
                Amount = amount,
                Date = date,
                Description = description
            };

            category.AddTransaction(transaction);
            Console.WriteLine("Transaction added successfully!");
        }

        private void GenerateReportUI()
        {
            string report = _budgetManager.GenerateReport();
            Console.WriteLine(report);
        }
    }
}


