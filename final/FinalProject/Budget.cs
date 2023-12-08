using PersonalBudgetManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonalBudgetManager.Services
{
    public class Budget
    {
        public Dictionary<Category, double> CategoryLimits { get; set; } = new Dictionary<Category, double>();

        public void SetLimit(Category category, double limit)
        {
            CategoryLimits[category] = limit;
        }

        public bool CheckLimit(Category category)
        {
            if (CategoryLimits.TryGetValue(category, out double limit))
            {
                double totalSpent = category.Transactions.Sum(t => t.Amount);
                return totalSpent > limit;
            }
            
            return false;
        }
    }
}

