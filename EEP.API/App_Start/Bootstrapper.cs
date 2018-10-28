using Autofac;
using Autofac.Integration.WebApi;
using EEP.API.Mappers;
using EEP.BL.Classes;
using EEP.DAL;
using EEP.DAL.Repository;
using EEP.DAL.Interfaces;
using EEP.DAL.UnitOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;
using EEP.DAL.UnitOfWork;
using System;
using EEP.Entities;
using EEP.API.Controllers;
using System.Reflection;
using System.Data.Entity;

namespace EEP.API.App_Start
{
    public static class Bootstrapper
    {

        public static void Configure()
        {
            ConfigureAutofacContainer();
          //  AutoMapperConfiguration.Configure();
        }

        public static void ConfigureAutofacContainer()
        {
            var webApiContainerBuilder = new ContainerBuilder();
            ConfigureWebApiContainer(webApiContainerBuilder);
        }

        public static void ConfigureWebApiContainer(ContainerBuilder containerBuilder)
        {
            // register unit of work
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            //// register repository
            containerBuilder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

           
          containerBuilder.RegisterType(typeof(EEPDbContext)).AsSelf().InstancePerLifetimeScope();


          //  containerBuilder.RegisterType<UserStore<User>>().As<IUserStore<IdentityUser>>().InstancePerLifetimeScope();

            //  containerBuilder.RegisterType<UserService>, MyUserManagerService>();
            containerBuilder.RegisterType<User>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<UserManager>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<RoleManager>();
            containerBuilder.RegisterType<UserStore<User>>().As<IUserStore<User>>().InstancePerRequest();
           

            // register services

            //   containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();




            //containerBuilder.Register(c => new UserManager(new UserStore<User>(EEPDbContext.Create())
            //{
            //    /*avoids userstore invoking savechanges on every actions.*/
            //    //autosavechanges = false
            //})).As<UserManager>().InstancePerLifetimeScope();

            // register controllers
            // containerBuilder.RegisterApiControllers(typeof(ApiController).Assembly);
            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            IContainer container = containerBuilder.Build();

           
            GlobalConfiguration.Configuration.DependencyResolver  = new AutofacWebApiDependencyResolver(container);
        }

    }
}
