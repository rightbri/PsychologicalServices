using PsychologicalServices.Api.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PsychologicalServices.Api.Infrastructure.Filters
{
    public class OptionsRequestHandler : DelegatingHandler
    {
        private readonly List<string> _allowedOrigins = null;
        private const string OriginHeader = "Origin";

        public OptionsRequestHandler(
            ICorsAllowedOrigins corsAllowedOrigins
        )
        {
            _allowedOrigins = corsAllowedOrigins.AllowedOrigins;
        }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken
        )
        {
            if (request.Method == HttpMethod.Options && request.Headers.Contains(OriginHeader))
            {
                var origin = request.Headers.GetValues(OriginHeader).First();

                if (_allowedOrigins.Contains(origin))
                {
                    var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

                    response.Headers.Add("Access-Control-Allow-Origin", origin);
                    response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization");
                    response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                    response.Headers.Add("Access-Control-Allow-Credentials", "true");

                    return response;
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}