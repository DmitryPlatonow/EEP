﻿
using EEP.BL.Classes;
using EEP.DAL;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;



namespace EEP.API
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            //HttpConfiguration httpConfig = new HttpConfiguration();

            //ConfigureOAuthTokenGeneration(app);

            //ConfigureWebApi(httpConfig);

            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //app.UseWebApi(httpConfig);
            ConfigureAuth(app);

        }

        //private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        //{
        //    // Configure the db context and user manager to use a single instance per request
        //    app.CreatePerOwinContext(EEPDbContext.Create);
        //    app.CreatePerOwinContext<UserManager>(UserManager.Create);

        //    // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here

        //}

        //private void ConfigureWebApi(HttpConfiguration config)
        //{
        //    config.MapHttpAttributeRoutes();

        //    var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
        //    jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        //}
    }
}