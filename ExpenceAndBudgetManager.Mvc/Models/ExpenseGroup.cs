using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenceAndBudgetManager.Mvc.Models
{
    public partial class ExpenseGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExpenseGroup()
        {
            this.Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ExpenseGroupStatusId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ExpenseGroupStatu ExpenseGroupStatu { get; set; }
    }
}