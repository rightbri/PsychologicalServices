using System;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using PsychologicalServices.Api.Infrastructure.Services;

namespace PsychologicalServices.Api.Infrastructure.Filters
{
    public class CorsPolicyProvider : Attribute, ICorsPolicyProvider
    {
        private readonly CorsPolicy _policy = null;

        public CorsPolicyProvider(
            ICorsAllowedOrigins corsAllowedOrigins
        )
        {
            _policy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                //do not allow any origin
                AllowAnyOrigin = false,
                SupportsCredentials = true,
            };

            //specify allowed origins
            var allowedOrigins = corsAllowedOrigins.AllowedOrigins;

            allowedOrigins.ForEach(_policy.Origins.Add);
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}