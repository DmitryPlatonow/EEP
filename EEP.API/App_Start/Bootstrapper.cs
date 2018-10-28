using Autofac;
using Autofac.Integration.WebApi;
using EEP.API.Mappers;
using EEP.BL.Classes;
using EEP.DAL;
using EEP.DAL.Repository;
using EEP.DAL.Interfaces;
using EEP.DAL.UnitOfWork;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;

using EEP.Entities;

namespace EEP.API.App_Start
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            ConfigureAutofacContainer();
            AutoMapperConfiguration.Configure();
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

            // register repository
            containerBuilder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            // register DbContext
            containerBuilder.RegisterType(typeof(EEPDbContext)).AsSelf().InstancePerLifetimeScope();

            // register services
            containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();




            containerBuilder.Register(c => new UserManager(new UserStore<User>(EEPDbContext.Create())
            {
                /*avoids userstore invoking savechanges on every actions.*/
                //autosavechanges = false
            })).As<UserManager>().InstancePerLifetimeScope();

            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            IContainer container = containerBuilder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}
