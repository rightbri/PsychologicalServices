using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using PsychologicalServices.Api.Infrastructure.Filters;
using System.Web.Http.Filters;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Cors;
using PsychologicalServices.Api.Infrastructure.Services;

namespace PsychologicalServices.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.MessageHandlers.Add(
                new OptionsRequestHandler(
                    (ICorsAllowedOrigins)config.DependencyResolver.GetService(typeof(ICorsAllowedOrigins))
                )
            );

            config.SetCorsPolicyProviderFactory(
                (ICorsPolicyProviderFactory)config.DependencyResolver.GetService(typeof(ICorsPolicyProviderFactory))
            );
            config.EnableCors();

            config.Filters.Add(
                (IFilter)config.DependencyResolver.GetService(typeof(VerifyAuthToken))
            );
            config.Filters.Add(
                (IFilter)config.DependencyResolver.GetService(typeof(RightAuthorizeAttribute))
            );

            config.Services.Add(typeof(IExceptionLogger), GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ExceptionLogger)));

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
