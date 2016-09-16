using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenceAndBudgetManager.Mvc.Models
{
    public partial class ExpenseGroupStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExpenseGroupStatu()
        {
            this.ExpenseGroups = new HashSet<ExpenseGroup>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpenseGroup> ExpenseGroups { get; set; }
    }
}