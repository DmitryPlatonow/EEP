using Autofac;
using Autofac.Integration.WebApi;
using EEP.API.Mappers;
using EEP.BL.Classes;
using EEP.DAL;
using EEP.DAL.Repository;
using EEP.DAL.Interfaces;
using EEP.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;
using EEP.DAL.UnitOfWork;

namespace EEP.API.App_Start
{
    public static class Bootstrapper//<TEntity> //where TEntity : class
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
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerApiRequest();

            // register repository
            containerBuilder.RegisterGeneric(typeof(GenericRepository<>)).As( typeof(IGenericRepository <>)).InstancePerApiRequest();

            // register services
            containerBuilder.RegisterType<UserService>().InstancePerApiRequest();
            containerBuilder.Register(c => new UserManager<User>(new UserStore<User>(new EEPDbContext())
            {
                /*Avoids UserStore invoking SaveChanges on every actions.*/
                //AutoSaveChanges = false
            })).As<UserManager<User>>().InstancePerApiRequest();

            // register controllers
            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            IContainer container = containerBuilder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}