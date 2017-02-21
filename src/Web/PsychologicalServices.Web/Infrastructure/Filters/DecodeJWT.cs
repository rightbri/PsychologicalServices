using Microsoft.IdentityModel.Tokens;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using PsychologicalServices.Models.Users;
using PsychologicalServices.Web.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        private const string FirebaseProjectId = "psychologicalservices-146622";

        [Dependency]
        public IFirebaseTokenSigningKeys SigningKeys { private get; set; }

        [Dependency]
        public IUserService UserService { private get; set; }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (null == SigningKeys)
            {
                SigningKeys = new FirebaseTokenSigningKeys();
            }

            var firebaseAuthToken = "";

            if (null != actionContext.Request.Headers.Authorization)
            {
                firebaseAuthToken = actionContext.Request.Headers.Authorization.Parameter;
            }
            else
            {
                throw new HttpException((int)HttpStatusCode.Unauthorized, "Unauthorized");
            }

            var secretKey = WebConfigurationManager.AppSettings["FirebaseSecret"];
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                if (tokenHandler.CanReadToken(firebaseAuthToken))
                {
                    var s = tokenHandler.ReadJwtToken(firebaseAuthToken);

                    //SecurityToken securityToken;

                    //var principal = tokenHandler.ValidateToken(firebaseAuthToken, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    //    {
                    //        ValidAudience = FirebaseProjectId,
                    //        ValidIssuer = string.Format("https://securetoken.google.com/{0}", FirebaseProjectId),

                    //        IssuerSigningKeys = SigningKeys.GetSecurityKeys(),
                    //    }, out securityToken);

                    //var jwt = (JwtSecurityToken)securityToken;

                    //if (jwt.Header.Alg != SecurityAlgorithms.RsaSha256)
                    //{
                    //    throw new SecurityTokenInvalidSignatureException(
                    //      "The token is not signed with the expected algorithm.");
                    //}
                }


                //var jsonPayload = new X509Certificate2()

                //var jsonPayload = JWT.JsonWebToken.Decode(firebaseAuthToken, secretKey);
                //var decodedToken = JsonConvert.DeserializeObject<DecodedToken>(jsonPayload);
                // TODO: Check expiry of decoded token
            }
            //catch (JWT.SignatureVerificationException jwtEx)
            //{
            //    throw new HttpException((int)HttpStatusCode.Unauthorized, "Unauthorized");
            //}
            catch (Exception ex)
            {
                throw new HttpException((int)HttpStatusCode.Unauthorized, "Unauthorized");
            }

            base.OnActionExecuting(actionContext);
        }
    }
}