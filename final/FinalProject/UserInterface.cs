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
                Console.WriteLine("Personal Budget Manager");
                Console.WriteLine("--------------------------");
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
 
        }

        private void GenerateReportUI()
        {
            string report = _budgetManager.GenerateReport();
            Console.WriteLine(report);
        }
    }
}

