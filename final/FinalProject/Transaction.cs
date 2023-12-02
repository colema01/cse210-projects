using System;

namespace PersonalBudgetManager.Models
{
    public class Transaction
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual void Record()
        {
            
        }

        public string GetDetails()
        {
            return $"Amount: {Amount}, Date: {Date}, Description: {Description}";
        }
    }
}
