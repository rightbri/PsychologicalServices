using Microsoft.Practices.Unity;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Web.Infrastructure.Services;
using System.Web.Http;
using Unity.WebApi;

namespace PsychologicalServices.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default
            );

            container.RegisterType<IDataAccessAdapterFactory, SqlServerAdapterFactory>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}