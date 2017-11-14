using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Api.Infrastructure.Services;
using System.Web.Http;
using Unity.WebApi;
using System.Web.Http.Filters;
using PsychologicalServices.Api.Infrastructure.Filters;
using PsychologicalServices.Api.Infrastructure;
using Owin;
using Microsoft.Practices.ServiceLocation;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Infrastructure.Common.Utility;
using log4net;
using System.Web.Http.ExceptionHandling;

namespace PsychologicalServices.Api
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            return new UnityContainer();
        });

        /// <summary>
        /// Gets the Unity Containter
        /// </summary>
        private static IUnityContainer DefaultUnityContainer
        {
            get { return container.Value; }
        }

        public static void RegisterComponents()
        {
            var container = DefaultUnityContainer;
            
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default
            );

            container
                .RegisterType<IDataAccessAdapterFactory, SqlServerAdapterFactory>()
                .RegisterType<ICacheService, CacheService>(new InjectionConstructor(System.Runtime.Caching.MemoryCache.Default))
                .RegisterType<ILog>(new InjectionFactory(unityContainer => LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)))
                .RegisterType<ExceptionLogger, Log4NetExceptionLogger>()
                ;

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            var serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            //RegisterMvcComponents(container);
            RegisterWebApiComponents(container);
        }

        private static void RegisterMvcComponents(IUnityContainer container)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
        }

        private static void RegisterWebApiComponents(IUnityContainer container)
        {
            var config = GlobalConfiguration.Configuration;

            var defaultprovider = config.Services.GetFilterProviders().Single(i => i is ActionDescriptorFilterProvider);
            config.Services.Remove(typeof(IFilterProvider), defaultprovider);
            config.Services.Add(typeof(IFilterProvider), new UnityFilterProvider(container));

            var dependencyResolver = new UnityDependencyResolver(container);
            config.DependencyResolver = dependencyResolver;
        }
    }
}