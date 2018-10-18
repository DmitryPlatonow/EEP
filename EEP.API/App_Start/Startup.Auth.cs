using EEP.API.Providers;
using EEP.DAL;
using EEP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

[assembly: OwinStartup(typeof(EEP.API.Startup))]

namespace EEP.API
{
    public partial class Startup
    {
        static Startup()
        {
            PublicClientId = "self";

            EEPDbContext dbContext = new EEPDbContext();
            UserManagerFactory = () => new UserManager<User>(new UserStore<User>(dbContext));

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId, UserManagerFactory),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };
        }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static Func<UserManager<User>> UserManagerFactory { get; set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication();
        }
    }
}

//public void Configuration(IAppBuilder app)
//{
//    HttpConfiguration config = new HttpConfiguration();

//    ConfigureOAuth(app);

//    WebApiConfig.Register(config);
//    app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
//    app.UseWebApi(config);

//}

//public void ConfigureOAuth(IAppBuilder app)
//{
//    OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
//    {
//        AllowInsecureHttp = true,
//        TokenEndpointPath = new PathString("/token"),
//        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
//        Provider = new ApplicationOAuthProvider()
//    };

//    // Token Generation
//    app.UseOAuthAuthorizationServer(OAuthServerOptions);
//    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

//}