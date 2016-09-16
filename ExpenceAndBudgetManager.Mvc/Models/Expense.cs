using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenceAndBudgetManager.Mvc.Models
{
    public partial class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseGroupId { get; set; }

        public virtual ExpenseGroup ExpenseGroup { get; set; }
    }
}