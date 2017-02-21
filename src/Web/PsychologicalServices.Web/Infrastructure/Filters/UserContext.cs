using Microsoft.Practices.Unity;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace PsychologicalServices.Web.Infrastructure.Filters
{
    public class UserContext : ActionFilterAttribute
    {
        [Dependency]
        public IUserService UserService { private get; set; }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (null != actionContext.Request.Headers.Authorization)
            {
                //actionContext.RequestContext.

                //firebaseAuthToken = actionContext.Request.Headers.Authorization.Parameter;
            }

            base.OnActionExecuting(actionContext);
        }
    }
}