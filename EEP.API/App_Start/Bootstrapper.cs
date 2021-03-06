﻿using Autofac;
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
            // register DbContext
            containerBuilder.RegisterType(typeof(EEPDbContext))
                            .AsSelf()
                            .InstancePerLifetimeScope();

            // register repository
            containerBuilder.RegisterGeneric(typeof(GenericRepository<>))
                            .As(typeof(IGenericRepository<>))
                            .InstancePerLifetimeScope();

            // register unit of work
            containerBuilder.RegisterType<UnitOfWork>()
                            .As<IUnitOfWork>()
                            .InstancePerLifetimeScope();

            // register services
            //containerBuilder.RegisterGeneric(typeof(ICRUDService<,>))
            //                .AsSelf()
            //                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<UserService>()
                            .As<IUserService>()
                            .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ProjectService>()
                            .As<IProjectService>()
                            .InstancePerLifetimeScope();

            //containerBuilder.RegisterType<EmployeeService>()
            //                .As<IEmployeeService>()
            //                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<ProjectParticipationHistoryService>()
                            .As<IProjectParticipationHistoryService>()
            .AsImplementedInterfaces()
                            
                            .InstancePerLifetimeScope();


            // register UserManager
            containerBuilder.Register(c => new UserManager(new UserStore(EEPDbContext.Create())))
                            .As<UserManager>()
                            .InstancePerLifetimeScope();

            // register Controllers
            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());

            IContainer container = containerBuilder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}

