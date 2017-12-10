using Microsoft.Practices.Unity;
using PsychologicalServices.Models.Users;
using PsychologicalServices.Api.Infrastructure.Services;
using PsychologicalServices.Api.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Filters;

namespace PsychologicalServices.Api.Infrastructure.Filters
{
    public class VerifyAuthToken : AuthorizationFilterAttribute
    {
        [Dependency]
        public IGoogleAuthTokenVerifier GoogleAuthTokenVerifier { private get; set; }

        [Dependency]
        public IUserLookupService UserLookupService { private get; set; }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            var authorized = false;
            
            if (null != actionContext.Request.Headers.Authorization)
            {
                var authToken = actionContext.Request.Headers.Authorization.Parameter;

                ClaimsPrincipal principal;

                authorized = GoogleAuthTokenVerifier.Verify(authToken, out principal);

                if (null != principal)
                {
                    const string emailClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";

                    var email = principal.Claims.FirstOrDefault(c => c.Type == emailClaimType);
                    if (null != email && !string.IsNullOrWhiteSpace(email.Value))
                    {
                        var user = UserLookupService.GetUserByEmail(email.Value);
                        if (null != user && user.IsActive)
                        {
                            actionContext.RequestContext.Principal = new UserPrincipal(user);
                        }
                    }
                }
            }

            if (!authorized)
            {
                var message = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Unauthorized" };

                throw new HttpResponseException(message);
            }
        }
    }
}