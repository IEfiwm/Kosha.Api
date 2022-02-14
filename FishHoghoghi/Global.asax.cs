using FishHoghoghi.App_Start;
using FishHoghoghi.Models;
using Kosha.Core;
using Kosha.Core.Bussinus.Providers;
using System;
using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FishHoghoghi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "*");

            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "*");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.End();
            }

        }

        protected void Application_Start()
        {
            Directory.ExistOrNot($@"{AppDomain.CurrentDomain.BaseDirectory}GeneratedPdf");

            AreaRegistration.RegisterAllAreas();

            UnityConfig.RegisterComponents();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            SMSIRProvider.Initialization(ConfigurationManager.AppSettings["ApiKey"].ToString(),
                ConfigurationManager.AppSettings["SecretKey"].ToString());

            DependencyInjection.connectionStrings = ConfigurationManager.ConnectionStrings;
            DependencyInjection.Initialise();
        }
    }
}