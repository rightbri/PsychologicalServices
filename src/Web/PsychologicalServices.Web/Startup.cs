using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(PsychologicalServices.Web.Startup))]

namespace PsychologicalServices.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);

            //UnityConfig.RegisterComponents();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
