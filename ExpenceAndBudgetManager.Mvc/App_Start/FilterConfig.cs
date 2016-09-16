using System.Web;
using System.Web.Mvc;

namespace ExpenceAndBudgetManager.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
