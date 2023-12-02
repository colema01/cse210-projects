using PersonalBudgetManager.Services;
using PersonalBudgetManager.UI;

namespace PersonalBudgetManager
{
    class Program
    {
        static void Main(string[] args)
        {
            BudgetManager budgetManager = new BudgetManager();
            UserInterface ui = new UserInterface(budgetManager);

            ui.DisplayMenu();
        }
    }
}
