using Microsoft.IdentityModel.Tokens;
using PsychologicalServices.Models.Common.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace PsychologicalServices.Web.Infrastructure.Services
{
    public class GoogleAuthTokenVerifier : IGoogleAuthTokenVerifier
    {
        private readonly IConfigurationService _configurationService = null;
        private readonly IGoogleAuthTokenSigningKeysProvider _tokenSigningKeysProvider = null;

        public GoogleAuthTokenVerifier(
            IConfigurationService configurationService,
            IGoogleAuthTokenSigningKeysProvider tokenSigningKeysProvider
        )
        {
            _configurationService = configurationService;
            _tokenSigningKeysProvider = tokenSigningKeysProvider;
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
            }

            principal = null;
            return false;
        }
    }
}