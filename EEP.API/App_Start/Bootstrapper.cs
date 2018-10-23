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
            containerBuilder.RegisterType<DAL.UnitOfWork.UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerApiRequest();

            // register repository
            containerBuilder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerApiRequest();

            containerBuilder.RegisterType<UserStore>().InstancePerApiRequest();
          //  containerBuilder.RegisterType<RoleStore>().As<RoleStore<Role, Guid, UserRole>>().InstancePerApiRequest();
            containerBuilder.RegisterType<UserManager>().InstancePerApiRequest();
            //  containerBuilder.RegisterType<RoleManager>();
            containerBuilder.RegisterType<EEPDbContext>().InstancePerApiRequest();

            containerBuilder.RegisterType<OperationResult>().As<IOperationResult>().AsImplementedInterfaces().InstancePerApiRequest();
            // register services
            containerBuilder.RegisterType<UserService>().UsingConstructor(typeof(UserManager)).InstancePerApiRequest();



            //containerBuilder.Register(c => new UserManager(new UserStore(EEPDbContext.Create())
            //{
            //    /*Avoids UserStore invoking SaveChanges on every actions.*/
            //    //AutoSaveChanges = false
            //})).As<UserManager<User, Guid>>().InstancePerApiRequest();

            // register controllers
            // containerBuilder.RegisterApiControllers(typeof(ApiController).Assembly);
            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            IContainer container = containerBuilder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}