using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Web.Infrastructure.Services;
using System.Web.Http;
using Unity.WebApi;
using System.Web.Http.Filters;
using PsychologicalServices.Web.Infrastructure.Filters;
using PsychologicalServices.Web.Infrastructure;
using Owin;
using Microsoft.Practices.ServiceLocation;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Infrastructure.Common.Utility;

namespace PsychologicalServices.Web
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