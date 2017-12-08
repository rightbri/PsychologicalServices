using System;
using System.Net.Http;
using System.Web.Http.Cors;

namespace PsychologicalServices.Api.Infrastructure.Filters
{
    public class CorsPolicyProviderFactory : ICorsPolicyProviderFactory
    {
        private readonly ICorsPolicyProvider _corsPolicyProvider = null;

        public CorsPolicyProviderFactory(
            ICorsPolicyProvider corsPolicyProvider
        )
        {
            _corsPolicyProvider = corsPolicyProvider;
        }

        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return _corsPolicyProvider;
        }
    }
}