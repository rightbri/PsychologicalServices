using Microsoft.Practices.Unity;
using PsychologicalServices.Api.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Api.Infrastructure.Services;

namespace PsychologicalServices.Api.Infrastructure.Filters
{
    public class RightAuthorizeAttribute : AuthorizationFilterAttribute
    {
        [Dependency]
        public IUserLookupService UserLookupService { private get; set; }
        
        private StaticRights Right { get; set; }

        public RightAuthorizeAttribute(
            StaticRights right
        )
        {
            Right = right;
        }

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            var authorized = false;

            var principal = actionContext.RequestContext.Principal as UserPrincipal;

            if (null != principal)
            {
                authorized = 
                    principal.Info.IsActive &&
                    principal.Info.HasRight(Right);
            }
            
            if (!authorized)
            {
                var message = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Unauthorized" };

                throw new HttpResponseException(message);
            }
        }
    }
}