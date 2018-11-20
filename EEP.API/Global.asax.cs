using EEP.API.App_Start;
using EEP.DAL;
using EEP.DAL.Migrations;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;



namespace EEP.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bootstrapper.Configure();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EEPDbContext, Configuration>());



        }
        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
                Response.Headers.Add("Access-Control-Allow-Headers", "Origin, Content-Type, X-Auth-Token");
                Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PATCH, PUT, DELETE, OPTIONS");
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");
  
                Response.End();
            }
        }
    }
}
