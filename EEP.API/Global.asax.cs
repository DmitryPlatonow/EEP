using EEP.API.App_Start;
using EEP.DAL;
using System.Data.Entity;
using System.Web.Http;

using Configuration = EEP.DAL.Migrations.Configuration;

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
    }
}
