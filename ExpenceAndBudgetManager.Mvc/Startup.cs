using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(ExpenceAndBudgetManager.Mvc.Startup))]

namespace ExpenceAndBudgetManager.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseCors(CorsOptions.AllowAll);
        }
    }
}
