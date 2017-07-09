using log4net;
using Microsoft.IdentityModel.Tokens;
using PsychologicalServices.Models.Common.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PsychologicalServices.Web.Infrastructure.Services
{
    public class GoogleAuthTokenVerifier : IGoogleAuthTokenVerifier
    {
        private readonly IConfigurationService _configurationService = null;
        private readonly IGoogleAuthTokenSigningKeysProvider _tokenSigningKeysProvider = null;
        private readonly ILog _log = null;

        public GoogleAuthTokenVerifier(
            IConfigurationService configurationService,
            IGoogleAuthTokenSigningKeysProvider tokenSigningKeysProvider,
            ILog log
        )
        {
            _configurationService = configurationService;
            _tokenSigningKeysProvider = tokenSigningKeysProvider;
            _log = log;
        }

        public bool Verify(string authToken, out ClaimsPrincipal principal)
        {
            if (!string.IsNullOrWhiteSpace(authToken))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                if (tokenHandler.CanReadToken(authToken))
                {
                    var jwt = tokenHandler.ReadJwtToken(authToken);

                    SecurityToken securityToken;

                    try
                    {
                        principal = tokenHandler.ValidateToken(
                        authToken,
                        new TokenValidationParameters
                        {
                            ValidAudience = _configurationService.AppSettingValue("AuthTokenAudience"),
                            ValidIssuers = _configurationService.AppSettingValue("AuthTokenValidIssuers").Split(','),
                            IssuerSigningKeys = _tokenSigningKeysProvider.GetSecurityKeys(jwt.ValidTo),
                        }, out securityToken);

                        return true;
                    }
                    //catch (SecurityTokenExpiredException ex)
                    //{

                    //}
                    catch (Exception ex)
                    {
                        _log.Error(
                            "An error occurred while attempting to verify the auth token",
                            ex);
                    }
                }
            }

            principal = null;
            return false;
        }
    }
}