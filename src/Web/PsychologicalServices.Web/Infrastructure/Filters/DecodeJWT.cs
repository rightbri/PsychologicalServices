using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using System.Web.Http.Filters;

namespace PsychologicalServices.Web.Infrastructure.Filters
{
    public class DecodeJWT : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //var firebaseAuthToken = "";

            //if (null != actionContext.Request.Headers.Authorization)
            //{
            //    firebaseAuthToken = actionContext.Request.Headers.Authorization.Parameter;
            //}
            //else
            //{
            //    throw new HttpException((int)HttpStatusCode.Unauthorized, "Unauthorized");
            //}

            //var secretKey = WebConfigurationManager.AppSettings["FirebaseSecret"];
            //try
            //{
            //    var jsonPayload = new X509Certificate2()

            //    //var jsonPayload = JWT.JsonWebToken.Decode(firebaseAuthToken, secretKey);
            //    //var decodedToken = JsonConvert.DeserializeObject<DecodedToken>(jsonPayload);
            //    // TODO: Check expiry of decoded token
            //}
            ////catch (JWT.SignatureVerificationException jwtEx)
            ////{
            ////    throw new HttpException((int)HttpStatusCode.Unauthorized, "Unauthorized");
            ////}
            //catch (Exception ex)
            //{
            //    throw new HttpException((int)HttpStatusCode.Unauthorized, "Unauthorized");
            //}

            base.OnActionExecuting(actionContext);
        }
    }
}