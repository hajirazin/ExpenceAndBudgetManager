//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenceAndBudgetManager.Web.Model
{
    using System;
    using System.Collections.Generic;
    
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
