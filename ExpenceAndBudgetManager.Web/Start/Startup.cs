using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ExpenceAndBudgetManager.Web.Start;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Startup))]
namespace ExpenceAndBudgetManager.Web.Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(h =>
            {
                h.MapHttpAttributeRoutes();
            });

            RouteTable.Routes.MapMvcAttributeRoutes();
            builder.UseCors(CorsOptions.AllowAll);
        }
    }
}